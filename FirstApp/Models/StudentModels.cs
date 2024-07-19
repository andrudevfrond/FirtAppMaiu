namespace FirstApp.Models
{
    public class StudentModels
    {
        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public abstract class DataBaseModels {
        public int Id { get; set; }
    }
}
