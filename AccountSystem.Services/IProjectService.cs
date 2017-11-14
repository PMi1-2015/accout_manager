using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Services
{
    public interface IProjectService
    {
        void SaveProject(Project project);
    }
}
