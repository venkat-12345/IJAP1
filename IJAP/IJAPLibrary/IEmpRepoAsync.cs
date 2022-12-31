using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJAPLibrary
{
    public interface IEmpRepoAsync
    {
        Task<List<Employee>> GetAllEmpAsync();
        Task<Employee> GetEmpById(string EmpID);
        Task<List<Employee>> GetEmpByJobId(string JID);
    }
}
