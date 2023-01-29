using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Application.Contracts;
using PersonManagement.Application.Interfaces;
using PersonManagement.WebApi.FIlters;
using System.Data;

namespace PersonManagement.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PersonRelationController : ControllerBase
    {
        private readonly IPersonRelationService _personRelationService;
        private readonly ILogger<PersonRelationController> _logger;
        public PersonRelationController(IPersonRelationService personRelationService, ILogger<PersonRelationController> logger)
        {
            _personRelationService = personRelationService;
            _logger = logger;
        }

        [RequestValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]PersonRelationModel personRelationModel)
        {           
            try
            {
                await _personRelationService.Add(personRelationModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [RequestValidationFilter]
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _personRelationService.Delete(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonRelationReport()
        {
            try
            {
                var result = await _personRelationService.GetPersonRelationReport();
                return Ok(result);   
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
