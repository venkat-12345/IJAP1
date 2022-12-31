using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EmpSkillLibrary;
using Newtonsoft.Json;

namespace EmpSkillMVC.Models
{
    public class EmpSkillApiRepoAsync
    {
        public static  HttpClient webApi;
        public EmpSkillApiRepoAsync()
        {
            webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:50047/api/Empskill/");
        }
        public async Task DeleteEmpSkillAsync(string eid,string sid)
        {
            await webApi.DeleteAsync("" + eid+"/"+sid);
        }
        public async Task<EmpSkill> GetBySkillIdAndEmpId(string eid, string sid)
        {
            HttpResponseMessage response = await webApi.GetAsync("GetByEmpIdAndSkillId" + "/" + eid + "/" + sid);
            string str = await response.Content.ReadAsStringAsync();
             EmpSkill employees = JsonConvert.DeserializeObject<EmpSkill>(str);
            return employees;
        }
        public async Task<List<EmpSkill>> GetAllEmpSkillsAsync()
        {
            HttpResponseMessage response = await webApi.GetAsync("");
            string str = await response.Content.ReadAsStringAsync();
            List<EmpSkill> employees = JsonConvert.DeserializeObject<List<EmpSkill>>(str);
            return employees;
        }
        public async Task<List<Employee>> GetAllEmpIdsAsync()
        {
            HttpResponseMessage response = await webApi.GetAsync("GetAllEmpIds");
            string str = await response.Content.ReadAsStringAsync();
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(str);
            return employees;
        }
        public async Task<List<Skill>> GetAllSkillIdsAsync()
        {
            HttpResponseMessage response = await webApi.GetAsync("GetAllSkillIds");
            string str = await response.Content.ReadAsStringAsync();
            
            List<Skill> skills = JsonConvert.DeserializeObject<List<Skill>>(str);
            
            return skills;
        }
        public async Task InsertEmployeeAsync(EmpSkill empskl)
        {
            var json = JsonConvert.SerializeObject(empskl);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PostAsync("", data);
        }
        public async Task<List<EmpSkill>> GetSkillByEmpIdAsync(string eid)
        {
            HttpResponseMessage response = await webApi.GetAsync("?eid=" + eid);
            string str = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<EmpSkill> emp = JsonConvert.DeserializeObject<List<EmpSkill>>(str);
                return emp;
            }
            else
            {
                throw new Exception(str);
            }
        }
        public async Task<List<EmpSkill>> GetSkillBySkillIdAsync(string sid)
        {
            HttpResponseMessage response = await webApi.GetAsync("?sid=" + sid);
            string str = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<EmpSkill> emp = JsonConvert.DeserializeObject<List<EmpSkill>>(str);
                return emp;
            }
            else
            {
                throw new Exception(str);
            }
        }
    }
}