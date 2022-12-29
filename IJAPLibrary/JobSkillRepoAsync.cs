using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJAPLibrary
{
    public class JobSkillRepoAsync
    {
        IJAPDBEntities ent = new IJAPDBEntities();
        public async Task<List<JobSkill>> GetAllJobSkillsAsync()
        {
            List<JobSkill> jobskills = await ent.JobSkills.ToListAsync();
            return jobskills;
        }

        public async Task<List<JobSkill>> GetByJobIdAsync(string JobId)
        {
            List<JobSkill> jobskillsbyJId = await (from j in ent.JobSkills where j.JobId == JobId select j).ToListAsync();
            return jobskillsbyJId;
        }

        public async Task<List<JobSkill>> GetBySkillIdAsync(string SkillId)
        {
            List<JobSkill> jobskillsbySID = await (from j in ent.JobSkills where j.SkillId == SkillId select j).ToListAsync();
            return jobskillsbySID;
        }
    }
}
