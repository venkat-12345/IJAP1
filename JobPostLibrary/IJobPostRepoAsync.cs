using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostLibrary
{
    public interface IJobPostRepoAsync
    {
        Task InsertJobPost(JobPost jobp);
        Task UpdateJobPost(int pId, JobPost jobp);
        Task DeleteJobPost(int pId);
        Task<List<JobPost>> GetAllJobPosts();
        Task<List<JobPost>> GetJobPostsByJobId(string jId);
        Task<JobPost> GetJobPostByPostId(int pId);

        Task DecVacancies(int pId);
    }
}
