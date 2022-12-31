using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using JobPostLibrary;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace JobPostWebApi.Controllers
{
    
    public class JobPostController : ApiController
    {
        IJobPostRepoAsync jpRepo = new JobPostRepoAsync();
        // GET: api/JobPost
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<JobPost> jps = await jpRepo.GetAllJobPosts();
            return Ok(jps);
        }
                
        // GET: api/JobPost/5
        [HttpGet]
        [Route("api/JobPost/{pid}")]
        public async Task<IHttpActionResult> Get(int pid)
        {
            JobPost jp = await jpRepo.GetJobPostByPostId(pid);
            return Ok(jp);
        }
        private void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(eventData);
            channel.BasicPublish(exchange: "jobpost", routingKey: integrationEvent, basicProperties: null, body: body);
        }


        // POST: api/JobPost
        [HttpPost]

        public async Task<IHttpActionResult> Insert(JobPost jp)
        {
            try
            {
                await jpRepo.InsertJobPost(jp);
                var integrationEventData = JsonConvert.SerializeObject(new { PostId = jp.PostId });
                PublishToMessageQueue("jobpost.add", integrationEventData);
                return Ok(jp);
            }
            catch(Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        // PUT: api/JobPost/5
        [HttpPut]
        [Route("api/JobPost/{pid}")]
        public async Task<IHttpActionResult> Update(int pid, JobPost jp)
        {
            await jpRepo.UpdateJobPost(pid, jp);          
            return Ok(jp);
        }

        // DELETE: api/JobPost/5
        [HttpDelete]
        [Route("api/JobPost/{pid}")]
        public async Task<IHttpActionResult> Delete(int pid)
        {
            await jpRepo.DeleteJobPost(pid);
            return Ok("Deleted Successfully");
        }
    }
}
