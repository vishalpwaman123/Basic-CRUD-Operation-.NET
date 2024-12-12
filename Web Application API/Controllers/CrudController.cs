using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Application_API.Data;
using Web_Application_API.Model;
using Web_Application_API.Repository;

namespace Web_Application_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        public readonly ICrudRepository _crudRepository;
        public CrudController(ICrudRepository crudRepository) { _crudRepository = crudRepository; }

        [HttpPost]
        public async Task<IActionResult> Post(InsertRequest request)
        {

            BasicResponse response = new BasicResponse();
            try
            {
                response = await _crudRepository.Insert(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _crudRepository.Update(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int Id)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _crudRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CrudDetail> response = new List<CrudDetail>();
            try
            {
                response = await _crudRepository.Get();
            }
            catch (Exception ex)
            {
            }

            return Ok(response);
        }
    }
}
