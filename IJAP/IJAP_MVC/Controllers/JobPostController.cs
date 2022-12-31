using JobPostLibrary;
using EmpPostLibrary;
using EmpPostSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IJAP_MVC.Repos;
namespace IJAP_MVC.Controllers
{
    public class JobPostController : Controller
    {

        // GET: JobPost
        JobPostApiRepoAsync  jobRepo = new JobPostApiRepoAsync();
        EmpPostApiRepoAsync empRepo = new EmpPostApiRepoAsync();
        
        public async Task<ActionResult> Index()
        {
           /* jobRepo.GetToken(User.Identity.Name,"Admin");*/
            
            List<JobPostLibrary.JobPost> jobposts = await jobRepo.GetAllJobPostsAsync();
            
            return View(jobposts);
        }
        public async Task<ActionResult> Requests()
        {
            //jobRepo.GetToken(User.Identity.Name, "Admin");

            List<EmployeePost> empposts = await empRepo.GetAllEmployeePostsAsync();

            return View(empposts);
        }

        // GET: JobPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobPost/Create
        [HttpPost]
        public ActionResult Create(JobPostLibrary.JobPost jobPost)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobPost/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            JobPostLibrary.JobPost jobpost = await jobRepo.GetAllEmployeePostByIdAsync(id);
            return View(jobpost);
        }

        // POST: JobPost/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, JobPostLibrary.JobPost jobPost)
        {
            try
            {
                // TODO: Add update logic here
                await jobRepo.UpdateEmployeeAsync(id, jobPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobPost/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            JobPostLibrary.JobPost jobpost = await jobRepo.GetAllEmployeePostByIdAsync(id);
            return View(jobpost);
        }

        // POST: JobPost/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, JobPostLibrary.JobPost jobPost)
        {
            try
            {
                // TODO: Add delete logic here
                await jobRepo.DeleteJobPostAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public async Task<ActionResult> Accept(int id)
        {
            EmployeePost employeePost = await empRepo.GetEmployeePostByIdAsync(id);
            employeePost.ApplicationStatus = "Accepted";
           
            // TODO: Add update logic here
            await empRepo.UpdateEmployeeAsync(id, employeePost);
            Requests();
            return RedirectToAction("Requests");
            
            
        }
        public async Task<ActionResult> Reject(int id)
        {
            EmployeePost employeePost = await empRepo.GetEmployeePostByIdAsync(id);
            employeePost.ApplicationStatus = "Rejected";

            // TODO: Add update logic here
            await empRepo.UpdateEmployeeAsync(id, employeePost);
            Requests();
            return RedirectToAction("Requests");


        }


        /*[HttpPost]
        public async Task<ActionResult> Accept(int id, EmployeePost empPost)
        {
            try
            {
                // TODO: Add update logic here
                await empRepo.UpdateEmployeeAsync(id, empPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
