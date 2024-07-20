using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Interfaces
{
    public interface IPath
    {
        string GetDatabasePath(string filename = "students.db");
    }
}
