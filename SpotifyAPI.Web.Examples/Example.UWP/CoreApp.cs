using Example.UWP.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace Example.UWP
{
  public class CoreApp : MvxApplication
  {
    public override void Initialize()
    {
      CreatableTypes()
          .EndingWith("Service")
          .AsInterfaces()
          .RegisterAsLazySingleton();

      RegisterAppStart<LoginViewModel>();
    }
  }
}
