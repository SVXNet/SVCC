using CodeCamp.Core.Services;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace CodeCamp.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.HomeViewModel>();
        }
    }
}
