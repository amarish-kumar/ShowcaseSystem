﻿namespace Showcase.Services.Data
{
    using System;

    using Showcase.Data.Common.Repositories;
    using Showcase.Data.Models;
    using Showcase.Services.Data.Contracts;

    public class VisitsService : IVisitsService
    {
        private readonly IUsersService users;

        private readonly IProjectsService projects;

        private readonly IRepository<Visit> visits;

        public VisitsService(IRepository<Visit> visits, IUsersService users, IProjectsService projects)
        {
            this.visits = visits;
            this.users = users;
            this.projects = projects;
        }

        public void VisitProject(int projectId, string username)
        {
            var visit = new Visit
            {
                CreatedOn = DateTime.Now,
                ProjectId = projectId
            };

            this.visits.Add(visit);
            this.visits.SaveChanges();
        }
    }
}