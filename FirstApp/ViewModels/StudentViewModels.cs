using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace FirstApp.ViewModels
{
    [QueryProperty("Name", "Name")]
    [QueryProperty("LastName", "LastName")]
    [QueryProperty("Id", "Id")]
    partial class StudentViewModels : ObservableValidator
    {
        #region Private Properties
        private readonly IStudents _students;
        #endregion

        #region Full Properties

        public ObservableCollection<string> Errors { get; set; } = new();

        [ObservableProperty]
        private string result = "";

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEnabled))]
        private bool isVisible;
        public bool IsEnabled => !IsVisible;
        [ObservableProperty]
        private int id;

        private string name = "";

        [Required(ErrorMessage = "Campo {0} es requerido")]
        [MaxLength(30)]
        public string Name { 
            get => name; 
            set => SetProperty(ref name, value, true);
        }

        private string lastName ="";
        [Required(ErrorMessage = "Campo {0} es requerido")]
        [MaxLength(30)]
        public string LastName {
            get => lastName;
            set => SetProperty(ref lastName, value, true);
        }
        #endregion

        #region Contructor
        public StudentViewModels()
        {
            _students = App.Current._services.GetRequiredService<IStudents>();
        }
        #endregion

        #region Commands
        [RelayCommand]
        public async Task SaveStudent(StudentModels student) {

            try
            {
                IsBusy = true;
                IsVisible = false;

                ValidateAllProperties();

                Errors.Clear();

                GetErrors(nameof(Name)).ToList().ForEach(e => Errors.Add(e.ErrorMessage!));
                GetErrors(nameof(LastName)).ToList().ForEach(e => Errors.Add(e.ErrorMessage!));

                IsBusy = false;
                if (Errors.Count > 0) return;

                IsBusy = true;
                if (Id == 0)
                {
                    var res = await _students.SaveItem(new StudentModels { Name = this.Name, LastName = this.LastName });
                    Id = res.Id;
                }
                if (Id > 0)
                {
                    var res = await _students.UpdateItem(new StudentModels { Name = this.Name, LastName = this.LastName, Id = this.Id });
                }

                Result = $"Registro Id: {this.Id}";
                IsBusy = false;
                IsVisible = true;

                await Task.Delay(2000);
                await Shell.Current.Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

    }
}
