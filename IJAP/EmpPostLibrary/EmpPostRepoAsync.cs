using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpPostLibrary
{
    public class EmpPostRepoAsync : IEmpPostRepoAsync
    {
        static EmpPostDBEntities2 db = new EmpPostDBEntities2();
        public static void AddJobPost(int pId)
        {
            JobPost jobPost = new JobPost() { PostId = pId };
            db.JobPosts.Add(jobPost);
            db.SaveChanges();
        }
        public async Task DeleteEmpPostAsync(int empId)
        {
            EmployeePost empPost = await GetEmpPostByIdAsync(empId);
            db.EmployeePosts.Remove(empPost);
            await db.SaveChangesAsync();
        }

        public async Task<List<EmployeePost>> GetALLEmpPostAsync()
        {
            return await db.EmployeePosts.ToListAsync();
        }

        public async Task<EmployeePost> GetEmpPostByIdAsync(int empId)
        {
            try
            {
                EmployeePost empPost = await (from c in db.EmployeePosts where empId == c.PostId select c).FirstAsync();
                return empPost;
            }
            catch (Exception)
            {
                throw new Exception("NO such post id");
            }
        }

        public async Task InsertEmpPostAsync(EmployeePost empPost)
        {
            db.EmployeePosts.Add(empPost);
            await db.SaveChangesAsync();
        }

        public async Task UpdateEmpPostAsync(int empId, EmployeePost empPost)
        {
            EmployeePost oldEmpPost = await GetEmpPostByIdAsync(empId);
            oldEmpPost.AppliedDate = empPost.AppliedDate;
            oldEmpPost.ApplicationStatus = empPost.ApplicationStatus;
            await db.SaveChangesAsync();
        }
    }
}


