using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EmpSkillLibrary
{
    public class EmpSkillRepoAsync : IEmpSkillRepoAsync
    {
        EmpSkillDBEntities1 db = new EmpSkillDBEntities1();
        public async Task DeleteEmployeeSkillbyId(string eid, string skillId)
        {
            EmpSkill skills = await (from e in db.EmpSkills where e.SkillId == skillId && e.EmpId == eid select e).FirstAsync();
            db.EmpSkills.Remove(skills);

            await db.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmpIds()
        {
            List<Employee> emps = await db.Employees.ToListAsync();
            return emps;
        }

        public async Task<List<EmpSkill>> GetAllEmpSkillsAsync()
        {
            List<EmpSkill> employee = await db.EmpSkills.ToListAsync();
            return employee;
        }

        public async Task<List<Skill>> GetAllSkillIds()
        {
            List<Skill> skills = await db.Skills.ToListAsync();
            return skills;
        }

        public async Task<List<EmpSkill>> GetByEmployeeIdAsync(string eid)
        {

            try
            {
                List<EmpSkill> emp = await (from e in db.EmpSkills where e.EmpId == eid select e).ToListAsync();
                return emp;
            }
            catch (Exception)
            {
                throw new Exception("No such emp id");
            }
        }

        public async Task<List<EmpSkill>> GetBySkillIdAndEmpIdAsync(string EmpId, string SkillId)
        {
            List<EmpSkill> emp = await (from e in db.EmpSkills where e.SkillId == SkillId && e.EmpId == EmpId select e).ToListAsync();
            return emp;
        }

        public async Task<List<EmpSkill>> GetBySkillIdAsync(string SkillId)
        {
            try
            {
                List<EmpSkill> emp = await (from e in db.EmpSkills where e.SkillId == SkillId select e).ToListAsync();
                return emp;
            }
            catch (Exception)
            {
                throw new Exception("No such emp id");
            }
        }

        public async Task InsertEmpSkill(EmpSkill skill)
        {
            db.EmpSkills.Add(skill);
            await db.SaveChangesAsync();
        }
    }
}