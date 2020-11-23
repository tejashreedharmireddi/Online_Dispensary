using Medicine.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _repo;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MedicineController));
        public MedicineController(IMedicineRepository repo)
        {
            this._repo = repo;
        } 
        [HttpGet]
        [Route("GetDetails/{Name}")]
        public async Task<IActionResult> GetDetails(string Name)
        {
            try
            {
                _log4net.Info("Get MedicineListDetails by  medicine name");
                var details = await _repo.GetName(Name);
                if (details == null)
                {

                    return BadRequest();

                }

                return Ok(details);
            }
            catch
            {
                _log4net.Error("Error in Getting Medicine Details");
                return new NoContentResult();
            }

        }
    }
}
