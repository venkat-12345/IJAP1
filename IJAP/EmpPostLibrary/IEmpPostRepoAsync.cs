using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpPostLibrary
{
    public interface IEmpPostRepoAsync
    {
        Task<List<EmployeePost>> GetALLEmpPostAsync();
        Task<EmployeePost> GetEmpPostByIdAsync(int empId);
        Task InsertEmpPostAsync(EmployeePost empPost);
        Task DeleteEmpPostAsync(int empId);
        Task UpdateEmpPostAsync(int empId, EmployeePost empPost);
    }
}
