﻿using Microsoft.AspNetCore.Mvc;
using RankenSchedule.UI.Models.DataLayer;
using RankenSchedule.UI.Models.DomainModels;

namespace RankenSchedule.UI.Controllers
{
    public class TeacherController : Controller
    {
        private Repository<Teacher> teachers { get; set; }

        public TeacherController(ClassScheduleContext ctx) => teachers = new Repository<Teacher>(ctx);

        public ViewResult Index()
        {
            var options = new QueryOption<Teacher>
            {
                OrderBy = t => t.LastName
            };

            return View(teachers.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            if(ModelState.IsValid)
            {
                teachers.Insert(teacher);
                teachers.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(teacher);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)=>View(teachers.Get(id));

        [HttpPost]
        public RedirectToActionResult Delete(Teacher teacher)
        {
            teachers.Delete(teacher);
            teachers.Save();
            return RedirectToAction("Index");
        }
    }
}
