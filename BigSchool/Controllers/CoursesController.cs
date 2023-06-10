using _2011770131_Trần_Hân_Nhi_BigSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace _2011770131_Trần_Hân_Nhi_BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Create()
        {
            BigSchoolContext context = new BigSchoolContext();
            Course objCourse = new Course();
            objCourse.ListCategory = context.Category.ToList();

            return View(objCourse);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course objCourse)
        {
            BigSchoolContext context = new BigSchoolContext();

            ModelState.Remove("LectureId");
            if (!ModelState.IsValid)
            {
                objCourse.ListCategory = context.Category.ToList();
                return View("Create", objCourse);
            }

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objCourse.LectureId = user.Id;
            objCourse.LectureName = user.Name;

            context.Course.Add(objCourse);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [Authorize]

        public ActionResult Attending()
        {
            BigSchoolContext context = new BigSchoolContext();
            ApplicationUser currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var listAttendances = context.Attendances.Where(p => p.Attendee == currentUser.Id).ToList();
            var courses = new List<Course>();
            foreach (Attendance temp in listAttendances)
            {
                if (temp.Course != null)
                {
                    Course objCourse = temp.Course;
                    objCourse.LectureName = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(objCourse.LectureId).Name;
                    courses.Add(objCourse);
                }
            }
            
            return View(courses);
        }

        public ActionResult Mine()
        {
            ApplicationUser currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            BigSchoolContext context = new BigSchoolContext();
            var courses = context.Course.Where(c => c.LectureId == currentUser.Id && c.DateTime > DateTime.Now).ToList();
            foreach(Course i in courses)
            {
                i.LectureName = currentUser.Name;
            }
            return View(courses);
        }

        public ActionResult LectureIamGoing()
        {
            ApplicationUser currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            BigSchoolContext context = new BigSchoolContext();

            var listFollowee = context.Following.Where(p=>p.FollowerId==currentUser.Id).ToList();

            var listAttendances = context.Attendances.Where(p => p.Attendee == currentUser.Id).ToList();
            var courses = new List<Course>();
            foreach(var course in listAttendances)
            {
                foreach(var item in listFollowee)
                {
                    if (item.FolloweeId == course.Course.LectureId)
                    {
                        Course objCourse = course.Course;
                        objCourse.LectureName = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(objCourse.LectureId).Name;
                        courses.Add(objCourse);
                    }
                }
            }

            return View(courses);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            BigSchoolContext context = new BigSchoolContext();
            Course objCourse = context.Course.FirstOrDefault(c => c.Id == id);

            if (objCourse == null)
            {
                return HttpNotFound();
            }

            // Check if the current user is the owner of the course
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (objCourse.LectureId != user.Id)
            {
                return RedirectToAction("Index", "Home");
            }

            objCourse.ListCategory = context.Category.ToList();

            return View(objCourse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course objCourse)
        {
            BigSchoolContext context = new BigSchoolContext();
            ModelState.Remove("LectureId");

            if (!ModelState.IsValid)
            {
                objCourse.ListCategory = context.Category.ToList();
                return View("Edit", objCourse);
            }

            // Check if the current user is the owner of the course
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Course existingCourse = context.Course.FirstOrDefault(c => c.Id == objCourse.Id && c.LectureId == user.Id);
            if (existingCourse == null)
            {
                return HttpNotFound();
            }

            existingCourse.Place = objCourse.Place;
            existingCourse.DateTime = objCourse.DateTime;
            existingCourse.CategoryId = objCourse.CategoryId;

            context.Course.AddOrUpdate(existingCourse);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            BigSchoolContext context = new BigSchoolContext();

            // Tìm lớp học theo id
            Course course = context.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            // Xóa lớp học
            context.Course.Remove(course);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}