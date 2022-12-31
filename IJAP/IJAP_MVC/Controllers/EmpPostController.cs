using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmpPostLibrary;
using IJAP_MVC.Repos;
namespace IJAP_MVC.Controllers
{
    public class EmpPostController : Controller
    {
        // GET: EmployeePost
        EmpPostApiRepoAsync empRepo = new EmpPostApiRepoAsync();
        public async Task<ActionResult> Index()
        {
            List<EmployeePost> employees = await empRepo.GetAllEmployeePostsAsync();
            return View(employees);
        }

        // GET: EmployeePost/Details/5
        public async Task<ActionResult> Details(int id)
        {
            EmployeePost emp = await empRepo.GetEmployeePostByIdAsync(id);
            return View(emp);
        }

        // GET: EmployeePost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeePost/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmployeePost empPost)
        {
            try
            {
                /*List<EmployeePost> employeePosts = await empRepo.GetAllEmployeePostsAsync();
                ViewBag.Accounts = new SelectList(employeePosts);
               */ 
                EmployeePost newEmpPost = empPost;
                newEmpPost.ApplicationStatus = "Reviewing";
                DateTime todaysDate = DateTime.Now;
                newEmpPost.AppliedDate = todaysDate;
                await empRepo.InsertEmployeeAsync(newEmpPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeePost/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            EmployeePost empPost = await empRepo.GetEmployeePostByIdAsync(id);
            return View(empPost);
        }

        // POST: EmployeePost/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EmployeePost empPost)
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
        }

        // GET: EmployeePost/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            EmployeePost empPost = await empRepo.GetEmployeePostByIdAsync(id);
            return View(empPost);
        }

        // POST: EmployeePost/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                await empRepo.DeleteEmployeePostAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}