using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJAPLibrary
{
    public class EmpRepoAsync
    {
        IJAPDBEntities1 ent = new IJAPDBEntities1();
        public async Task<List<Employee>> GetAllEmpAsync()
        {
            List<Employee> emps = await ent.Employees.ToListAsync();
            return emps;
        }

        public async Task<Employee> GetEmpById(string EmpID)
        {
            Employee emp = await (from e in ent.Employees where e.EmpId == EmpID select e).FirstAsync();
            return emp;
        }

        public async Task<List<Employee>> GetEmpByJobId(string JID)
        {
            List<Employee> empByJID = await (from e in ent.Employees where e.JobId == JID select e).ToListAsync();
            return empByJID;
        }
    }
}
