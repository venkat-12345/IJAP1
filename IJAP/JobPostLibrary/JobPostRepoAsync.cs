using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostLibrary
{
    public class JobPostRepoAsync : IJobPostRepoAsync
    {
        JobPostDBEntities1 ent = new JobPostDBEntities1();
        public async Task DeleteJobPost(int pId)
        {
            JobPost post2del = await GetJobPostByPostId(pId);
            ent.JobPosts.Remove(post2del);
            ent.SaveChangesAsync();
        }

        public async Task<List<JobPost>> GetAllJobPosts()
        {
            List<JobPost> jobPosts = await ent.JobPosts.ToListAsync();
            return jobPosts;
        }

        public async Task<JobPost> GetJobPostByPostId(int pId)
        {
            try
            {
                JobPost jobPost = await ent.JobPosts.FindAsync(pId);
                return jobPost;
            }
            catch (Exception)
            {
                throw new Exception("No such Jobpost with Post ID " + pId);
            }
        }

        public async Task<List<JobPost>> GetJobPostsByJobId(string jId)
        {

            List<JobPost> jobPosts = await (from jobpost in ent.JobPosts where jobpost.JobId == jId select jobpost).ToListAsync();
            return jobPosts;
        }

        public async Task InsertJobPost(JobPost jobp)
        {
            ent.JobPosts.Add(jobp);
            ent.SaveChangesAsync();
        }

        public async Task UpdateJobPost(int pId, JobPost jobp)
        {
            JobPost jobp2edit = await GetJobPostByPostId(pId);
            jobp2edit.LastDateToApply = jobp.LastDateToApply;
            jobp2edit.JobId = jobp.JobId;
            jobp2edit.Vacancies = jobp.Vacancies;
            ent.SaveChangesAsync();
        }
        public async Task DecVacancies(int pId)
        {
            JobPost jobp2edit = await GetJobPostByPostId(pId);
            jobp2edit.Vacancies -= 1;
            ent.SaveChangesAsync();
        }
    }
}
