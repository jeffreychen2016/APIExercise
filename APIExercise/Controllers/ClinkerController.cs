using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIExercise.DataAccess;
using APIExercise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
        private Prison _prison;

        public ClinkerController()
        {
            _prison = new Prison();
        }

        [HttpGet("AllClinkers")]
        public ActionResult<IEnumerable<Clinker>> GetAllClinkers()
        {
            return _prison.ClinkerPrison;
        }

        [HttpPost("AddToPrison")]
        public void AddClinkerToPrison()
        {
            _prison.Add(new Clinker { Name = "Tom", IsLonely = true });
        }
    }
}