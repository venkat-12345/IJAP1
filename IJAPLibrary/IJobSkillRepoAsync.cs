using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJAPLibrary
{
    public interface IJobSkillRepoAsync
    {
        Task<List<JobSkill>> GetAllJobSkillsAsync();
        Task<List<JobSkill>> GetByJobIdAsync(string JobId);
        Task<List<JobSkill>> GetBySkillIdAsync(string SkillId);
    }
}
