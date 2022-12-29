using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJAPLibrary
{
    public class JobRepoAsync : IJobRepoAsync
    {
        IJAPDBEntities ent = new IJAPDBEntities();

        public async Task<List<Job>> GetAllJobsAsync()
        {
            List<Job> jobs = await ent.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<Job> GetJobByIdAsync(string jobid)
        {
            try
            {
                Job job = await (from e in ent.Jobs where e.JobId == jobid select e).FirstAsync();
                return job;
            }
            catch (Exception)
            {
                throw new Exception("No such job id");
            }
        }
    }
}
