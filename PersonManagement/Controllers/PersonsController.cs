using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Application.Contracts;
using PersonManagement.Application.Interfaces;
using PersonManagement.Domain.Entities;
using PersonManagement.WebApi.FIlters;
using PersonManagement.WebApi.Validations;

namespace PersonManagement.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonsController> _logger;

        public PersonsController(IPersonService personService, ILogger<PersonsController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [RequestValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreatePersonModel person)
        {     
            try
            {
                await _personService.Add(person);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [RequestValidationFilter]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdatePersonModel person)
        {

            try
            {
                await _personService.Update(person);
                return Ok();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [RequestValidationFilter]
        [HttpPost]
        public async Task<IActionResult> UploadImage(PersonImageModel personImageModel)
        {
            try
            {
                await _personService.UploadPersonImage(personImageModel);
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
                await _personService.Delete(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [RequestValidationFilter]
        [HttpGet]
        public async Task<IActionResult> GetPersonDetails(int id)
        {
            try
            {
                var result = await _personService.GetPersonDetails(id);
                return Ok(result);
            }
            catch (Exception ex )
            {
                return StatusCode(500, ex.Message);
            }            
        }
             
        [RequestValidationFilter]
        [HttpPost]
        public async Task<IActionResult> GetPersonFilteredList([FromBody]PersonFilter personFilter)
        {
            try
            {
               var result =  await _personService.GetPersonFilteredList(personFilter);
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
