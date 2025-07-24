using ETAConsumer.Application.Services;
using ETAConsumer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETAConsumer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ETAPredictionController : ControllerBase
    {
        private readonly ETAPredictionAppService _appService;

        public ETAPredictionController(ETAPredictionAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Gets the ETA prediction for a package.
        /// </summary>
        /// <param name="packageId">The ID of the package.</param>
        /// <param name="scanTimestamp">The scan timestamp.</param>
        /// <param name="location">The location of the scan.</param>
        /// <returns>The ETA prediction.</returns>
        [HttpGet("{packageId}")]
        public IActionResult GetPrediction(string packageId, [FromQuery] long scanTimestamp, [FromQuery] string location)
        {
            var package = new Package
            {
                PackageId = packageId,
                Location = location,
                ScanTimestamp = scanTimestamp
            };

            var prediction = _appService.Predict(package);
            return Ok(prediction);
        }
    }
}