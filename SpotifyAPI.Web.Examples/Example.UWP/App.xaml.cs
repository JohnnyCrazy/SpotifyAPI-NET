using System;
using MvvmCross;
using MvvmCross.Platforms.Uap.Core;
using MvvmCross.Platforms.Uap.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Example.UWP
{
  public abstract class ExampleApp : MvxApplication<MvxWindowsSetup<CoreApp>, CoreApp>
  {
  }

  /// <summary>
  /// Provides application-specific behavior to supplement the default Application class.
  /// </summary>
  public sealed partial class App
  {
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
      InitializeComponent();
    }

    protected override void OnActivated(IActivatedEventArgs args)
    {
      if (args.Kind == ActivationKind.Protocol)
      {
        ProtocolActivatedEventArgs eventArgs = args as ProtocolActivatedEventArgs;
        var publisher = Mvx.IoCProvider.Resolve<ITokenPublisherService>();
        publisher.ReceiveToken(eventArgs.Uri);
      }
    }
  }
}
