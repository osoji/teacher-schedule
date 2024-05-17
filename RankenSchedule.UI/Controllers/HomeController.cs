using Microsoft.AspNetCore.Mvc;
using RankenSchedule.UI.Models.DataLayer;
using RankenSchedule.UI.Models.DomainModels;

namespace RankenSchedule.UI.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Class> classes { get; set; }
        private Repository<Day> days { get; set; }
        public HomeController(ClassScheduleContext context)
        {
            classes = new Repository<Class>(context);
            days = new Repository<Day>(context);
        }

        public IActionResult Index(int id)
        {
            var dayOptions = new QueryOption<Day>
            {
                OrderBy = d => d.DayId
            };
            var classOptions = new QueryOption<Class>
            {
                Includes = "Teacher,Day"
            };

            if(id == 0)
            {
                classOptions.OrderBy =c => c.DayId;
                classOptions.ThenOrderBy =c => c.MilitaryTime;
            }
            else
            {
                classOptions.Where = c => c.DayId == id;
                classOptions.OrderBy = c => c.MilitaryTime;
            }

            //Executing the queries
            var dayList = days.List(dayOptions);
            var classList = classes.List(classOptions);

            //sending the data to the view
            ViewBag.Id = id;
            ViewBag.Days = dayList;


            return View(classList);
        }

    }
}
