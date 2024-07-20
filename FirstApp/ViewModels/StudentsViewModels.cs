using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace FirstApp.ViewModels
{
    partial class StudentsViewModels: ObservableObject
    {
        #region Properties
        private readonly IStudents _studentsService;
        private readonly IDialogService _dialogService;
        public ObservableCollection<StudentModels> Students { get; set; } = new();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsReady))]
        private bool isLoading;

        [ObservableProperty]
        private bool isRefreshing;
        public bool IsReady => !IsLoading;
        #endregion

        #region Constructor
        public StudentsViewModels()
        {
            _studentsService = App.Current._services.GetRequiredService<IStudents>();
            _dialogService = App.Current._services.GetRequiredService<IDialogService>();
            Task.Run(async () => await GetStudents());
        }
        #endregion

        #region Commands
        [RelayCommand]
        public async Task GetStudents() {
            IsLoading = true;
            Students.Clear();

            var list = await _studentsService.GetItems();
            foreach (var student in list) Students.Add(student);

            IsLoading = false;
            IsRefreshing = false;
        }

        [RelayCommand]
        public async Task EditStudent(StudentModels student) {
            string url = $"{nameof(StudentPage)}?Id={student.Id}&Name={student.Name}&LastName={student.LastName}";
            await Shell.Current.GoToAsync(url, false);
        }

        [RelayCommand]
        public async Task DeleteStudent(StudentModels student) {
            IsLoading = true;
            var res = await _dialogService.ShowAlertAsync("Eliminar", $"Desea eliminar el registro {student.Id}", "Aceptar", "Cancelar");
            if (!res) return;
            await _studentsService.DeleteItem(student.Id);
            await GetStudents();
        }

        [RelayCommand]
        public async Task AddNew() {
            await Shell.Current.Navigation.PushAsync(new StudentPage(), false);
        }
        #endregion
    }
}
