using AccountSystem.Data.models;

namespace AccountSystem.Data.impl
{
    class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AccountSystemContext context) : base(context) { }
    }
}
