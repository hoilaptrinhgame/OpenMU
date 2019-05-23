using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.Models
{
    public class TestModel : BindableBase
    {
        private string message;

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }
    }
}