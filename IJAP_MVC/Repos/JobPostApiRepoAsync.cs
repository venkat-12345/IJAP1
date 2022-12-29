using JobPostLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IJAP_MVC.Repos
{
    public class JobPostApiRepoAsync
    {

        static public HttpClient webApi;
        string token;

        public JobPostApiRepoAsync()
        {
            webApi = new HttpClient();
            webApi.BaseAddress = new Uri("http://localhost:50013/api/JobPost/");
        }
        public async void GetToken(string userName, string roleName)
        {
            token = await webApi.GetStringAsync("http://localhost:62642/api/Auth/?userName=" + userName + "&role=" + roleName + "&key=my_secret_key_12345");
            webApi.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        }
        public async Task DeleteJobPostAsync(int eid)
        {
            await webApi.DeleteAsync("" + eid);
        }
        public async Task<List<JobPost>> GetAllJobPostsAsync()
        {
            HttpResponseMessage response = await webApi.GetAsync("");
            string str = await response.Content.ReadAsStringAsync();
            List<JobPost> jobPosts = JsonConvert.DeserializeObject<List<JobPost>>(str);
            return jobPosts;
        }
        public async Task<JobPost> GetAllEmployeePostByIdAsync(int id)
        {
            HttpResponseMessage response = await webApi.GetAsync("" + id);
            string str = await response.Content.ReadAsStringAsync();
            JobPost jobPosts = JsonConvert.DeserializeObject<JobPost>(str);
            return jobPosts;
        }

        public async Task InsertEmployeeAsync(JobPost jobPost)
        {
            var json = JsonConvert.SerializeObject(jobPost);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PostAsync("", data);
        }
        public async Task UpdateEmployeeAsync(int jid, JobPost jobPost)
        {
            var json = JsonConvert.SerializeObject(jobPost);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webApi.PutAsync("" + jid, data);
        }
    }
}