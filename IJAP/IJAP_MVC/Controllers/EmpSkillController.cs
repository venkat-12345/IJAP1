using EmpSkillLibrary;
using EmpSkillMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IJAP_MVC.Controllers
{
    public class EmpSkillController : Controller
    {
        // GET: EmpSkillMvc
        EmpSkillApiRepoAsync emprepo = new EmpSkillApiRepoAsync();
        /*public static  async Task<List<SelectListItem>> GetAllEmpIds()
        {
            //IFightRepoAsync flightRepo = new FlightRepoAsync();

            List<Employee> employees = await emprepo.GetAllEmpIdsAsync();
            List<SelectListItem> enos = new List<SelectListItem>();
            foreach (Employee emp in employees)
            {
                enos.Add(new SelectListItem { Text = emp.EmpId, Value = emp.EmpId });
            }
            return enos;
        }



        public static async Task<List<SelectListItem>> GetAllSkillIds()
        {
            //IFightRepoAsync flightRepo = new FlightRepoAsync();



            List<Skill> skills = await emprepo.GetAllSkillIdsAsync();
            List<SelectListItem> enos = new List<SelectListItem>();
            foreach (Skill skill in skills)
            {
                enos.Add(new SelectListItem { Text = skill.SkillId, Value = skill.SkillId });
            }
            return enos;
        }*/
        public async Task<ActionResult> Index()
        {
            /*List<Skill> empids =await emprepo.GetAllSkillIdsAsync();*/

            List<EmpSkill> empskl = await emprepo.GetAllEmpSkillsAsync();

            /*ViewBag.EmpIds = empids;
            ViewBag.EmpSkills = empskl;*/
            return View(empskl);
        }

        // GET: EmpSkillMvc/Details/5
        public async Task<ActionResult> Details(string eid, string sid)
        {
            EmpSkill empskl = await emprepo.GetBySkillIdAndEmpId(eid, sid);
            return View(empskl);
        }

        // GET: EmpSkillMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpSkillMvc/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmpSkill empSkill)
        {
            try
            {
                await emprepo.InsertEmployeeAsync(empSkill);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpSkillMvc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpSkillMvc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpSkillMvc/Delete/5
        public ActionResult Delete(string eid)
        {
            return View();
        }

        // POST: EmpSkillMvc/Delete/5

        [HttpPost]
        public async Task<ActionResult> Delete(string eid, string sid)
        {
            try
            {
                // TODO: Add delete logic here
                await emprepo.DeleteEmpSkillAsync(eid, sid);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}