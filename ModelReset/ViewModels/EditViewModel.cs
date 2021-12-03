using System.ComponentModel;
using System.Threading.Tasks;
using Catel;
using Catel.Fody;
using Catel.Logging;
using Catel.MVVM;
using ModelReset.Models;

namespace ModelReset.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public EditViewModel(Part part)
        {
            Argument.IsNotNull(() => part);

            Part = part;
            Reset = new Command(OnResetModel);

            Part.PropertyChanged += Part_PropertyChanged;
            PropertyChanged += MainWindowViewModel_PropertyChanged;
        }

        public Command Reset { get; set; }


        [Model] [Expose("Description")] public Part Part { get; set; }

        private void MainWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Log.Debug($"MainWindowViewModel_PropertyChanged fired for {e.PropertyName}");
        }

        private void Part_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Log.Debug($"Part_PropertyChanged fired for {e.PropertyName}");
        }

        private void OnResetModel()
        {
            ResetModel(nameof(Part), ModelCleanUpMode.CancelEdit);
        }
        
        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}