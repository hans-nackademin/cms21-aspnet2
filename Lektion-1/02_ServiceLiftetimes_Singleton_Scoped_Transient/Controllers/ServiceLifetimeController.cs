using _02_ServiceLiftetimes_Singleton_Scoped_Transient.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02_ServiceLiftetimes_Singleton_Scoped_Transient.Controllers
{
    public class ServiceLifetimeController : Controller
    {
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;

        public ServiceLifetimeController(ISingletonService singletonService, IScopedService scopedService, ITransientService transientService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
        }

        public IActionResult Singleton()
        {
            return View(_singletonService);
        }

        public IActionResult Scoped()
        {
            return View(_scopedService);
        }

        public IActionResult Transient()
        {
            return View(_transientService);
        }
    }
}
