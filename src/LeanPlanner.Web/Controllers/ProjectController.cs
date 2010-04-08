using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeanPlanner.Data;
using LeanPlanner.Domain.Entities;
using LeanPlanner.Web.ViewModels.Project;

namespace LeanPlanner.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IRepository _repository;

        public ProjectController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<Project>,IEnumerable<ProjectListViewModel>>(_repository.All<Project>());
            return View(viewModel);
        }
    }
}
