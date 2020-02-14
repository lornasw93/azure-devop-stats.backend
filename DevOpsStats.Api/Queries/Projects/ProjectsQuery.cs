﻿using System.Threading.Tasks;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Services;
using DevOpsStats.Api.Services.Count;

namespace DevOpsStats.Api.Queries.Projects
{
    public class ProjectsQuery : IProjectsQuery
    {
        private readonly IDevOpsService _devOpsService;
        private readonly ICountService<ListCount> _countService;

        public ProjectsQuery(IDevOpsService devOpsService, ICountService<ListCount> countService)
        {
            _devOpsService = devOpsService;
            _countService = countService;
        }

        public Task<object> Execute()
        {
            return _devOpsService.GetProjects();
        }

        public Task<ListCount> Count()
        {
            return _countService.Count("_apis/projects");
        }
    }
}
