using Microsoft.AspNetCore.Mvc;
using RankenSchedule.UI.Models.DataLayer;
using RankenSchedule.UI.Models.DomainModels;

namespace RankenSchedule.UI.Controllers
{
    public class ClassController : Controller
    {
        private Repository<Class> classes { get; set; }
        private Repository<Teacher> teachers { get; set; }
        private Repository<Day> days { get; set; }
        public ClassController(ClassScheduleContext ctx)
        {
            classes = new Repository<Class>(ctx);
            teachers = new Repository<Teacher>(ctx);
            days = new Repository<Day>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View("AddEdit", new Class());
        }

        [HttpPost]
        public IActionResult Add(Class c)
        {
            bool isAdd = c.ClassId == 0;

            if (ModelState.IsValid)
            {
                if (isAdd)
                    classes.Insert(c);
                else
                    classes.Update(c);
                classes.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string opertaion = (isAdd) ? "Add" : "Edit";
                this.LoadViewBag(opertaion);
                return View("AddEdit", c);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var c = this.GetClass(id);
            return View("AddEdit", c);
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var c = this.GetClass(id);
            return View(c);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Class c)
        {
            classes.Delete(c);
            classes.Save();
            return RedirectToAction("Index", "Home");
        }

        //helper methods
        private Class GetClass(int id)
        {
            var classOptions = new QueryOption<Class>
            {
                Includes = "Teacher, Day",
                Where = c => c.ClassId == id
            };
            return classes.Get(classOptions) ?? new Class();
        }
        private void LoadViewBag(string Opertion)
        {
            ViewBag.Days = days.List(new QueryOption<Day>
            {
                OrderBy = d => d.DayId
            });
            ViewBag.Teachers = teachers.List(new QueryOption<Teacher>
            {
                OrderBy = teachers => teachers
            });
            ViewBag.Operation = Opertion;

        }
    }
}
