
namespace FirstApp.Services
{
    public class DialogService : IDialogService
    {
        public Task<string> ShowActionAsync(string title, string message, string destruction, params string[] buttons)
        {
            return  App.Current.MainPage.DisplayActionSheet(title, message, destruction, buttons);
        }

        public Task<bool> ShowAlertAsync(string title, string message, string accept, string cancel)
        {
            return App.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public Task<bool> ShowConfirmAsync(string title, string message)
        {
            return App.Current.MainPage.DisplayAlert(title, message, "Ok", "No");
        }
    }
}
