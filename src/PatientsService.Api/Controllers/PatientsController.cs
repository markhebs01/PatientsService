using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientsService.Application.Queries;
using System.Threading.Tasks;

namespace PatientsService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(IMediator mediator, ILogger<PatientsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }



        /// <summary>
        /// Get Patient by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPatientById(int id)
        {

            _logger.LogInformation("Fetching patient with ID {PatientId}", id);

            //GET PATIENT FOR ID
            var patient = await _mediator.Send(new GetPatientByIdQuery(id));
            
            if (patient == null)
            {
                //HANDLE NOT FOUND
                _logger.LogWarning("Patient with ID {PatientId} not found", id);
                return NotFound(new { Message = $"Patient with ID {id} not found." });
            }

            _logger.LogInformation($"Successfully retrieved patient {patient.Name} ({patient.Id})");
            return Ok(patient);
        }
    }
}
