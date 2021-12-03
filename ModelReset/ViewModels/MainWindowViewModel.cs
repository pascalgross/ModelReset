using System.Diagnostics;
using System.Linq;
using Catel.MVVM;
using System.Threading.Tasks;
using Catel;
using Catel.Fody;
using Catel.IoC;
using Catel.Logging;
using Catel.Services;
using ModelReset.Contracts;
using ModelReset.Models;

namespace ModelReset.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IUnitOfWorkFactory unitOfWorkFactory)
        {
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => unitOfWorkFactory);
            _uiVisualizerService = uiVisualizerService;
            _unitOfWorkFactory = unitOfWorkFactory;

            OpenEditWindow = new TaskCommand(OnOpenEditWindow);
        }

        public TaskCommand OpenEditWindow { get; set; }

        private async Task OnOpenEditWindow()
        {

            using (var uow = _unitOfWorkFactory.Create())
            {
                var part = uow.GetRepository<Part>().GetAll().FirstOrDefault();

                var typeFactory = this.GetTypeFactory();
                var editViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<EditViewModel>(part);
                
                await _uiVisualizerService.ShowDialogAsync(editViewModel);
            }
        }

        public override string Title { get { return "Welcome to ModelReset"; } }
        

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            using (var uow = _unitOfWorkFactory.Create())
            {
                var category = await uow.GetRepository<Category>().Add(new Category());
                await uow.GetRepository<Part>().Add(new Part()
                {
                    Category = category
                });
                await uow.SaveChanges();
            }
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
