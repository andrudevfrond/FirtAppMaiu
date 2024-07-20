using FirstApp.Db;

namespace FirstApp.Services
{
    public class StudentsService : BaseRepository<StudentModels>, IStudents
    {
        public StudentsService(IPath path) 
        : base(path)
        {
            
        }
    }
}
