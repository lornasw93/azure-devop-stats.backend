using System.Linq; 
using DevOpsStats.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers
{
    public abstract class AbstractController<T> : ControllerBase
    {
        public abstract IQueryable<Result> Execute();
        public abstract int ExecuteCount();
        public abstract Chart ExecuteChart();
    }
}
