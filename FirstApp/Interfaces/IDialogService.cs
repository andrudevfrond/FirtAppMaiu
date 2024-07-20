namespace FirstApp.Interfaces
{
    public interface IDialogService
    {
        Task<string> ShowActionAsync(string title, string message, string destruction, params string[] buttons);
        Task<bool> ShowAlertAsync(string title, string message, string accept, string cancel);
        Task<bool> ShowConfirmAsync(string title, string message);
    }
}
