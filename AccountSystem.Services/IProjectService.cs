using AccountSystem.Data.models;
using System;
using System.Collections.Generic;

namespace AccountSystem.Services
{
    public interface IProjectService
    {
        void SaveProject(Project project);

        void UpdateProject(Project project);

        void DeleteProject(Project project);

        List<Project> SearchProject(String name, DateTime? startDate, DateTime? endDate);
    }
}
