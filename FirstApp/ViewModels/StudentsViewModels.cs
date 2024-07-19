using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace FirstApp.ViewModels
{
    partial class StudentsViewModels: ObservableObject
    {
        public ObservableCollection<StudentModels> Students { get; set; } = new();

        [RelayCommand]
        public async Task GetStudends() {
            Students.Clear();
            Students.Add(new StudentModels { Name = "Andres",LastName = "Galindo"});
            Students.Add(new StudentModels { Name = "Diana",LastName = "Galindo"});
            Students.Add(new StudentModels { Name = "Felipe",LastName = "Galindo"});
            Students.Add(new StudentModels { Name = "Emily",LastName = "Galindo"});
            Students.Add(new StudentModels { Name = "Sofia",LastName = "Galindo"});

        }
    }
}
