using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FirstApp.ViewModels
{
    partial class TestViewModel : ObservableObject
    {
        private readonly IFunctions _functions;
        #region Properties
        [ObservableProperty]
        string text = "";
        [ObservableProperty]
        int count;
        #endregion

        #region Contructors
        public TestViewModel()
        {
           _functions = App.Current._services.GetRequiredService<IFunctions>();
        }
        #endregion

        #region Commands
        [RelayCommand]
        public void CambiarTexto() {
            Count++;
            Text = _functions.CambiarTexto("Andres ", Count);
        }
        #endregion
    }
}
