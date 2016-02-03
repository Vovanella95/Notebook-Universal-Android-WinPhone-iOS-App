using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Notebook.Services;

namespace Notebook.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.FirstViewModel>();
            Mvx.RegisterType<INoteDataService, NoteDataService>();
        }
    }
}
