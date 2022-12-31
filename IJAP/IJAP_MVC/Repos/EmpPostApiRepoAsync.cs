using EmpPostLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IJAP_MVC.Repos
{
    public class EmpPostApiRepoAsync
    {
        public HttpClient webApi;

        public EmpPostApiRepoAsync()
        {
            webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:50000/api/EmployeePost/");
        }
        public async Task DeleteEmployeePostAsync(int eid)
        {
            await webApi.DeleteAsync("" + eid);
        }
        public async Task<List<EmployeePost>> GetAllEmployeePostsAsync()
        {
            HttpResponseMessage response = await webApi.GetAsync("");
            string str = await response.Content.ReadAsStringAsync();
            List<EmployeePost> employeePosts = JsonConvert.DeserializeObject<List<EmployeePost>>(str);
            return employeePosts;
        }
        public async Task<EmployeePost> GetEmployeePostByIdAsync(int id)
        {
            HttpResponseMessage response = await webApi.GetAsync("" + id);
            string str = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(str);
            EmployeePost employeePosts = JsonConvert.DeserializeObject<EmployeePost>(str);
            return employeePosts;
        }

        public async Task InsertEmployeeAsync(EmployeePost emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PostAsync("", data);
        }
        public async Task UpdateEmployeeAsync(int eid, EmployeePost emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PutAsync("" + eid, data);
        }
    }
}