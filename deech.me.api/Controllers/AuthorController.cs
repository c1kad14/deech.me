using deech.me.data.entities;
using deech.me.logic.abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace deech.me.api.Controllers
{
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> logger;
        private readonly IReadDataService<Person> readDataService;

        public AuthorController(ILogger<AuthorController> logger, IReadDataService<Person> readDataService)
        {
            this.logger = logger;
            this.readDataService = readDataService;
        }

        
    }
}