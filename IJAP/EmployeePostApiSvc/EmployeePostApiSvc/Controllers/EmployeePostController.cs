using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EmployeePostLibrary;


namespace EmployeePostApi.Controllers
{
    public class EmployeePostController : ApiController
    {
        IEmpPostRepoAsync empRepo = new EmpPostRepoAsync();
        // GET: api/EmployeePost

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<EmployeePost> empPosts = await empRepo.GetALLEmpPostAsync();
            return Ok<List<EmployeePost>>(empPosts);
        }

        [Route("api/EmployeePost/{eno}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetOne(string eno)
        {
            try
            {
                EmployeePost empPost = await empRepo.GetEmpPostByIdAsync(eno);
                return Ok<EmployeePost>(empPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST: api/EmployeePost
        [HttpPost] 
        public async Task<IHttpActionResult> Insert(EmployeePost empPost)
        {
            await empRepo.InsertEmpPostAsync(empPost);
            return Created<EmployeePost>("api/EmployeePost", empPost);
        }

        // PUT: api/EmployeePost/5
        [Route("api/EmployeePost/{eno}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(string eno, EmployeePost empPost)
        {
            await empRepo.UpdateEmpPostAsync(eno, empPost);
            return Ok<EmployeePost>(empPost);
        }
        // DELETE: api/EmployeePost/5
        [Route("api/EmployeePost/{eno}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string eno)
        {
            await empRepo.DeleteEmpPostAsync(eno);
            return Ok();
        }
    }
}



