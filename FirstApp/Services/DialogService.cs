
namespace FirstApp.Services
{
    public class DialogService : IDialogService
    {
        public Task<string> ShowActionAsync(string title, string message, string destruction, params string[] buttons)
        {
            return  Application.Current.MainPage.DisplayActionSheet(title, message, destruction, buttons);
        }

        public Task<bool> ShowAlertAsync(string title, string message, string accept, string cancel)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public Task<bool> ShowConfirmAsync(string title, string message)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, "Ok", "No");
        }
    }
}
