using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EmpSkillLibrary;
namespace EmpSkillWebApi.Controllers
{
    public class EmpSkillController : ApiController
    {
        IEmpSkillRepoAsync emprepo = new EmpSkillRepoAsync();
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<EmpSkill> empskills = await emprepo.GetAllEmpSkillsAsync();
            return Ok(empskills);
        }
        /*[Route("api/EmpSkill/GetAllEmpIds")]
        [HttpGet]*/
        /*public async Task<IHttpActionResult> GetAllEmpIds()
        {
            List<Employee> empIds = await emprepo.GetAllEmpIds();
            return Ok(empIds);
        }*/
        [Route("api/EmpSkill/GetByEmpIdAndSkillId/{eid}/{sid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByEmpIdAndSkillId(string eid, string sid)
        {
            EmpSkill empIds = await emprepo.GetBySkillIdAndEmpIdAsync(eid, sid);
            return Ok(empIds);
        }
        /*[Route("api/EmpSkill/GetAllSkillIds")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllSkillIds()
        {
            List<Skill> skillIds = await emprepo.GetAllSkillIds();
            return Ok(skillIds);
        }*/
        [Route("api/EmpSkill/GetBySkill/{SkillId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBySkillId(string SkillId)
        {
            try
            {
                List<EmpSkill> empskills = await emprepo.GetBySkillIdAsync(SkillId);
                return Ok(empskills);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/EmpSkill/GetByEmp/{EmpId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetByEmpId(string EmpId)
        {
            try
            {
                List<EmpSkill> empskills = await emprepo.GetByEmployeeIdAsync(EmpId);
                return Ok(empskills);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insert(EmpSkill empskl)
        {
            await emprepo.InsertEmpSkill(empskl);
            return Created<EmpSkill>("api/EmpSKill", empskl);
        }
        [Route("api/EmpSkill/{eid}/{sid}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string eid, string sid)
        {
            await emprepo.DeleteEmployeeSkillbyId(eid, sid);
            return Ok();
        }
    }
}
