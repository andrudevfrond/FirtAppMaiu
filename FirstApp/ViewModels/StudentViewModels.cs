using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace FirstApp.ViewModels
{
    partial class StudentViewModels : ObservableValidator
    {

        public ObservableCollection<string> Errors { get; set; } = new();

        private string name;
        [Required(ErrorMessage = "Campo {0} es requerido")]
        [MaxLength(30)]
        public string Name { 
            get => name; 
            set => SetProperty(ref name, value, true);
        }

        
        private string lastName;
        [Required(ErrorMessage = "Campo {0} es requerido")]
        [MaxLength(30)]
        public string LastName {
            get => lastName;
            set => SetProperty(ref lastName, value, true);
        }

        [RelayCommand]
        public async Task SaveStudent() {
            ValidateAllProperties();
            Errors.Clear();
            GetErrors(nameof(Name)).ToList().ForEach(e=> Errors.Add(e.ErrorMessage!));
            GetErrors(nameof(LastName)).ToList().ForEach(e=> Errors.Add(e.ErrorMessage!));
        }

    }
}
