using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Example.UWP.ViewModels;
using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Example.UWP.Views
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  [MvxViewFor(typeof(PlaylistsListViewModel))]
  [MvxPagePresentation]
  public sealed partial class PlaylistsListView : PlaylistsListViewPage
  {
    public PlaylistsListView()
    {
      InitializeComponent();
    }
  }

  public abstract class PlaylistsListViewPage : MvxWindowsPage<PlaylistsListViewModel>
  {
  }
}
