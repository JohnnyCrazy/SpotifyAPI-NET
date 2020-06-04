using Example.UWP.ViewModels;
using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Example.UWP.Views
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  [MvxViewFor(typeof(LoginViewModel))]
  [MvxPagePresentation]
  public sealed partial class LoginView : LoginViewPage
  {
    public LoginView()
    {
      InitializeComponent();
    }
  }

  public abstract class LoginViewPage : MvxWindowsPage<LoginViewModel>
  {
  }
}
