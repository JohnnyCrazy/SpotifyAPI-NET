using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace SpotifyAPI.Local
{
    internal static class VolumeMixerControl
    {
        private const string SpotifyProcessName = "spotify";

        internal static float GetSpotifyVolume()
        {
            ISimpleAudioVolume volume = GetSpotifyVolumeObject();

            if (volume == null)
            {
                throw new COMException("Volume object creation failed");
            }

            volume.GetMasterVolume(out float level);
            Marshal.ReleaseComObject(volume);
            return level * 100;
        }

        internal static bool IsSpotifyMuted()
        {
            ISimpleAudioVolume volume = GetSpotifyVolumeObject();

            if (volume == null)
            {
                throw new COMException("Volume object creation failed");
            }

            volume.GetMute(out bool mute);
            Marshal.ReleaseComObject(volume);
            return mute;
        }

        internal static void SetSpotifyVolume(float level)
        {
            ISimpleAudioVolume volume = GetSpotifyVolumeObject();

            if (volume == null)
            {
                throw new COMException("Volume object creation failed");
            }

            Guid guid = Guid.Empty;
            volume.SetMasterVolume(level / 100, ref guid);
            Marshal.ReleaseComObject(volume);
        }

        internal static void MuteSpotify(bool mute)
        {
            ISimpleAudioVolume volume = GetSpotifyVolumeObject();

            if (volume == null)
            {
                throw new COMException("Volume object creation failed");
            }

            Guid guid = Guid.Empty;
            volume.SetMute(mute, ref guid);
            Marshal.ReleaseComObject(volume);
        }

        private static ISimpleAudioVolume GetSpotifyVolumeObject()
        {
            var audioVolumeObjects = from p in Process.GetProcessesByName(SpotifyProcessName)
                                     let vol = GetVolumeObject(p.Id)
                                     where vol != null
                                     select vol;
            return audioVolumeObjects.FirstOrDefault();
        }

        private static ISimpleAudioVolume GetVolumeObject(int pid)
        {
            // get the speakers (1st render + multimedia) device
            IMmDeviceEnumerator deviceEnumerator = (IMmDeviceEnumerator) new MMDeviceEnumerator();
            deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.ERender, ERole.EMultimedia, out IMmDevice speakers);

            speakers.GetId(out string defaultDeviceId);

            ISimpleAudioVolume volumeControl = GetVolumeObject(pid, speakers);
            Marshal.ReleaseComObject(speakers);

            if (volumeControl == null)
            {
                // If volumeControl is null, then the process's volume object might be on a different device.
                // This happens if the process doesn't use the default device.
                // 
                // As far as Spotify is concerned, if using the "--enable-audio-graph" command line argument,
                // a new option becomes available in the Settings that makes it possible to change the playback device.

                deviceEnumerator.EnumAudioEndpoints(EDataFlow.ERender, EDeviceState.Active, out IMmDeviceCollection deviceCollection);

                deviceCollection.GetCount(out int count);
                for (int i = 0; i < count; i++)
                {
                    deviceCollection.Item(i, out IMmDevice device);
                    device.GetId(out string deviceId);

                    try
                    {
                        if (deviceId == defaultDeviceId)
                            continue;

                        volumeControl = GetVolumeObject(pid, device);
                        if (volumeControl != null)
                            break;
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(device);
                    }
                }
            }
            
            Marshal.ReleaseComObject(deviceEnumerator);
            return volumeControl;
        }

        private static ISimpleAudioVolume GetVolumeObject(int pid, IMmDevice device)
        {
            // activate the session manager. we need the enumerator
            Guid iidIAudioSessionManager2 = typeof(IAudioSessionManager2).GUID;
            device.Activate(ref iidIAudioSessionManager2, 0, IntPtr.Zero, out object o);
            IAudioSessionManager2 mgr = (IAudioSessionManager2) o;

            // enumerate sessions for on this device
            mgr.GetSessionEnumerator(out IAudioSessionEnumerator sessionEnumerator);
            sessionEnumerator.GetCount(out int count);

            // search for an audio session with the required name
            // NOTE: we could also use the process id instead of the app name (with IAudioSessionControl2)
            ISimpleAudioVolume volumeControl = null;
            for (int i = 0; i < count; i++)
            {
                sessionEnumerator.GetSession(i, out IAudioSessionControl2 ctl);
                ctl.GetProcessId(out int cpid);

                if (cpid == pid)
                {
                    volumeControl = (ISimpleAudioVolume) ctl;
                    break;
                }
                Marshal.ReleaseComObject(ctl);
            }
            Marshal.ReleaseComObject(sessionEnumerator);
            Marshal.ReleaseComObject(mgr);
            return volumeControl;
        }

        [ComImport]
        [Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
        private class MMDeviceEnumerator
        {
        }

        private enum EDataFlow
        {
            ERender,
            ECapture,
            EAll,
            EDataFlowEnumCount
        }

        private enum ERole
        {
            EConsole,
            EMultimedia,
            ECommunications,
            ERoleEnumCount
        }

        [Flags]
        private enum EDeviceState
        {
            Active = 0x00000001,
            Disabled = 0x00000002,
            NotPresent = 0x00000004,
            UnPlugged = 0x00000008,
            All = 0x0000000F
        }

        [Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMmDeviceEnumerator
        {
            [PreserveSig]
            int EnumAudioEndpoints(EDataFlow dataFlow, EDeviceState stateMask, [Out] out IMmDeviceCollection deviceCollection);

            [PreserveSig]
            int GetDefaultAudioEndpoint(EDataFlow dataFlow, ERole role, out IMmDevice ppDevice);
        }

        [Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMmDevice
        {
            [PreserveSig]
            int Activate(ref Guid iid, int dwClsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);

            int OpenPropertyStore_NotImpl();

            [PreserveSig]
            int GetId([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppstrId);
        }

        [Guid("0BD7A1BE-7A1A-44DB-8397-CC5392387B5E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMmDeviceCollection
        {
            [PreserveSig]
            int GetCount(out int deviceCount);

            [PreserveSig]
            int Item(int deviceIndex, [Out] out IMmDevice device);
        }

        [Guid("77AA99A0-1BD6-484F-8BC7-2C654C9A9B6F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IAudioSessionManager2
        {
            int NotImpl1();

            int NotImpl2();

            [PreserveSig]
            int GetSessionEnumerator(out IAudioSessionEnumerator sessionEnum);
        }

        [Guid("E2F5BB11-0570-40CA-ACDD-3AA01277DEE8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IAudioSessionEnumerator
        {
            [PreserveSig]
            int GetCount(out int sessionCount);

            [PreserveSig]
            int GetSession(int sessionCount, out IAudioSessionControl2 session);
        }

        [Guid("87CE5498-68D6-44E5-9215-6DA47EF883D8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface ISimpleAudioVolume
        {
            [PreserveSig]
            int SetMasterVolume(float fLevel, ref Guid eventContext);

            [PreserveSig]
            int GetMasterVolume(out float pfLevel);

            [PreserveSig]
            int SetMute(bool bMute, ref Guid eventContext);

            [PreserveSig]
            int GetMute(out bool pbMute);
        }

        [Guid("bfb7ff88-7239-4fc9-8fa2-07c950be9c6d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IAudioSessionControl2
        {
            [PreserveSig]
            int NotImpl0();

            [PreserveSig]
            int GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

            [PreserveSig]
            int SetDisplayName([MarshalAs(UnmanagedType.LPWStr)]string value, [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

            [PreserveSig]
            int GetIconPath([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

            [PreserveSig]
            int SetIconPath([MarshalAs(UnmanagedType.LPWStr)] string value, [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

            [PreserveSig]
            int GetGroupingParam(out Guid pRetVal);

            [PreserveSig]
            int SetGroupingParam([MarshalAs(UnmanagedType.LPStruct)] Guid Override, [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

            [PreserveSig]
            int NotImpl1();

            [PreserveSig]
            int NotImpl2();

            [PreserveSig]
            int GetSessionIdentifier([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

            [PreserveSig]
            int GetSessionInstanceIdentifier([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

            [PreserveSig]
            int GetProcessId(out int pRetVal);

            [PreserveSig]
            int IsSystemSoundsSession();

            [PreserveSig]
            int SetDuckingPreference(bool optOut);
        }
    }
}