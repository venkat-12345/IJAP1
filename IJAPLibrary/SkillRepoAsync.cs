using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJAPLibrary
{
    class SkillRepoAsync : ISkillRepoAsync
    {
        IJAPDBEntities ent = new IJAPDBEntities();
        public async Task<List<Skill>> GetAllSkillsAsync()
        {
            List<Skill> skills = await ent.Skills.ToListAsync();
            return skills;
        }

        public async Task<Skill> GetSkillByIdAsync(string skillId)
        {
            try
            {
                Skill skill = await (from e in ent.Skills where e.SkillId == skillId select e).FirstAsync();
                return skill;
            }
            catch (Exception)
            {
                throw new Exception("No such job id");
            }
        }
    }
}
