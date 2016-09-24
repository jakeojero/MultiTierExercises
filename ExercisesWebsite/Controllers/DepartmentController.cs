using System;
using System.Web.Http;
using ExercisesViewModels;

namespace ExercisesWebsite
{
    public class DepartmentController : ApiController
    {
        [Route("api/departments/{id}")]
        
        public IHttpActionResult Get(string id)
        {
            try
            {
                DepartmentViewModel dep = new DepartmentViewModel();
                dep.Id = id;
                dep.GetById();
                return Ok(dep);

            }
            catch (Exception ex)
            {
                return BadRequest("Retrieve failed - " + ex.Message);
            }
        }
    }
}