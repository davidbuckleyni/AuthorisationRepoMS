using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthorisationRepoMS.Controllers {
    [Authorize(Roles = "manager")]
    public class TestController : Controller {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }
        
    }
}
