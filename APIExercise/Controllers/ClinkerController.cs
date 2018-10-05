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
        private Network _network;

        public ClinkerController()
        {
            _prison = new Prison();
            _network = new Network();
        }

        [HttpGet("AllClinkers")]
        public ActionResult<IEnumerable<Clinker>> GetAllClinkers()
        {
            return _prison.ClinkerPrison;
        }

        [HttpPost("AddToPrison")]
        public void AddClinkerToPrison(Clinker clinker)
        {
             _prison.Add(clinker);
        }

        [HttpPost("JoinNetwork")]
        public IActionResult JoinClickerNewwork(Clinker clinker)
        {
            if (clinker.IsLonely)
            {
                _network.JoinNetwork(clinker);
                return Content("A new clinker join the network");
            }
            else
            {
                return Content("You are not lonely,so...FUCK OFF!");
            }
        }
    }
}