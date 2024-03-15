using JobPortalAPI.Model;
using JobPortalAPI.Repository;
using JobPortalAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IEmployerReg _employerReg;
        private readonly IJobReg _jobReg;
        public RegistrationController(IEmployerReg employerReg,IJobReg jobReg)
        {
            _employerReg = employerReg;
            _jobReg = jobReg;
        }
        [HttpPost]
        public IActionResult JobseekerReg([FromBody] Jobseekers jobseekers) 
        {
            bool inserted=_jobReg.InsertJobseekers(jobseekers);
            if (inserted)
            {
                return Ok();
            }
            return BadRequest("ServerError: Inserting Jobseeker");
        }
        [HttpPost]
        [Route("InsertEmployer")]
        public IActionResult EmployerReg([FromBody]EmployerDetails employerDetails) 
        {
            bool inserted = _employerReg.AddEmployer(employerDetails);
            if (inserted)
            {
                return Ok();
            }
            return BadRequest("ServerError:Inserting Employer");
        }
    }
}
