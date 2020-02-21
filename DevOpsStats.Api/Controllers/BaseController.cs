using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected string Api = "_apis";

        protected abstract string ResourceName { get; }
         
    }
}
