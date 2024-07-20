namespace FirstApp.Models
{
    [Table("students")]
    public class StudentModels : DataBaseModels
    {
        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
        [MaxLength(30)]
        public string Name { get; set; } = "";
        [MaxLength(30)]
        public string LastName { get; set; } = "";
    }

    public abstract class DataBaseModels {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
