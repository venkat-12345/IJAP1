using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpSkillLibrary
{
    public interface IEmpSkillRepoAsync
    {
        Task<List<EmpSkill>> GetByEmployeeIdAsync(string eid);
        Task<List<EmpSkill>> GetBySkillIdAsync(string SkillId);

        Task<List<EmpSkill>> GetBySkillIdAndEmpIdAsync(string EmpId, string SkillId);
        Task<List<EmpSkill>> GetAllEmpSkillsAsync();
        Task InsertEmpSkill(EmpSkill skill);
        Task DeleteEmployeeSkillbyId(string eid, string skillId);

        Task<List<Employee>> GetAllEmpIds();

        Task<List<Skill>> GetAllSkillIds();

    }
}
