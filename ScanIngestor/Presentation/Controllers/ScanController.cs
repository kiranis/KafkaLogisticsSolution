using Microsoft.AspNetCore.Mvc;
using ScanIngestor.Application.Services;
using ScanIngestor.Domain.Entities;
using System.Threading.Tasks;

namespace ScanIngestor.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScanController : ControllerBase
    {
        private readonly ScanIngestionService _ingestionService;

        public ScanController(ScanIngestionService ingestionService)
        {
            _ingestionService = ingestionService;
        }

        [HttpPost]
        public async Task<IActionResult> IngestScan([FromBody] ScanEvent scanEvent)
        {
            if (string.IsNullOrEmpty(scanEvent.PackageId) || string.IsNullOrEmpty(scanEvent.Location))
            {
                return BadRequest("PackageId and Location are required.");
            }

            await _ingestionService.IngestScanAsync(scanEvent);
            return Ok("Scan event published successfully.");
        }
    }
}