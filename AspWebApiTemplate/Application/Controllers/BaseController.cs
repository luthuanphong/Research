using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public abstract class BaseController<T> : ControllerBase
    {
        /// <summary>
        /// Logger
        /// </summary>
        private protected readonly ILogger<T> _logger;

        /// <summary>
        /// Base Controller constructor
        /// </summary>
        /// <param name="logger">Logger instance</param>
        protected BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
