using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UniversityWebDBMS.Models;

namespace UniversityWebDBMS.Controllers
{
    public class LoginCredentialsController : Controller
    {
        private UniModel db = new UniModel();

        // GET: LoginCredentials/Login
        public ActionResult Login()
        {
            HttpCookie cookie = Request.Cookies.Get("SSID");
            LoginInfo loginInfo = db.LoginInfoes.SqlQuery("SELECT * FROM dbo.LoginInfo WHERE sessionid = @sessionid;", new SqlParameter("@sessionid", cookie==null? "":cookie.Value)).SingleOrDefault();
            
            if (loginInfo != null)
            {
                Response.Cookies.Set(cookie);
                Response.Cookies.Get("SSID").Expires = DateTime.Now.AddMinutes(1);
                if (loginInfo.LoginCredential.role.Equals("student"))
                {
                    switch (Request.QueryString.Get("mod"))
                    {
                        case "announces":
                            return View("../Login/Failed");
                        case "course_struct":
                            return CourseStructure(loginInfo.id);
                        case "course_reg":
                            return View("../Login/Failed");
                        case "course_sched":
                            return View("../Login/Failed");
                        case "re_exam":
                            return View("../Login/Failed");
                        case "grades":
                            return View("../Login/Failed");
                        case "ejurnal":
                            return View("../Login/Failed");
                        case "transcript":
                            return View("../Login/Failed");
                        case "library":
                            return View("../Login/Failed");
                        case "contact":
                            return View("../Login/Failed");
                        case "settings":
                            return View("../Login/Failed");
                        case "view_deps":
                            return View("../Login/Failed");
                        case "card":
                            return View("../Login/Failed");
                        case "online":
                            return View("../Login/Failed");
                        case "question":
                            return View("../Login/Failed");
                        case "tuition":
                            return View("../Login/Failed");
                        case "exit":
                            return Logout();
                        default:
                            return HomePage(loginInfo.id);
                    }
                }
                else if (loginInfo.LoginCredential.role.Equals("admin"))
                {
                    switch(Request.QueryString.Get("mod"))
                    {
                        case "course_create":
                            return CreateCourse();
                        case "create_course_form":
                            return CreateCourseForm();
                        case "course_list":
                            return View("../Course/List", db.Courses.ToList());
                        case "course_details":
                            return View("../Course/Details", db.Courses.Find(Request.QueryString.Get("id")));
                        case "course_edit":
                            return EditCourse();
                        case "course_delete":
                            db.Courses.Remove(db.Courses.Find(Request.QueryString.Get("id")));
                            db.SaveChanges();
                            return View("../Course/List", db.Courses.ToList());
                        case "program_add":
                            return AddProgram();
                        case "program_add_form":
                            return AddProgramForm();
                        case "program_list":
                            return View("../Program/List", db.Programs.ToList());
                        case "program_edit":
                            return EditProgram();
                        case "program_details":
                            return View("../Program/Details", db.Programs.Find(Request.QueryString.Get("id")));
                        case "program_delete":
                            db.Programs.Remove(db.Programs.Find(Request.QueryString.Get("id")));
                            db.SaveChanges();
                            return View("../Program/List", db.Programs.ToList());
                        case "student_list":
                            return View("../Student/List", db.Students.ToList());
                        case "student_add":
                            return AddStudent();
                        case "student_edit":
                            return EditStudent();
                        case "student_delete":
                            db.LoginCredentials.Remove(db.LoginCredentials.Find(Request.QueryString.Get("id")));
                            db.Users.Remove(db.Users.Find(Request.QueryString.Get("id")));
                            db.AcademicInfos.Remove(db.AcademicInfos.Find(Request.QueryString.Get("id")));
                            db.Students.Remove(db.Students.Find(Request.QueryString.Get("id")));
                            db.SaveChanges();
                            return View("../Student/List", db.Students.ToList());
                        case "student_add_form":
                            return AddStudentForm();
                        case "student_details":
                            return View("../Student/Details", db.Students.Find(Request.QueryString.Get("id")));
                        case "exit":
                            return Logout();
                        default:
                            return AdminPanel(loginInfo.id);
                    }
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            else
            {
                LoginCredential loginCredential = new LoginCredential
                {
                    id = Request.Form.Get("username"),
                    password = Request.Form.Get("password")
                };
                if (loginCredential.id.IsNullOrWhiteSpace())
                {
                    return View("../Login/Login");
                }
                else
                {
                    LoginCredential login = db.LoginCredentials.Find(loginCredential.id);
                    if (login == null)
                        return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                    else if (!login.password.Equals(loginCredential.password))
                        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);

                    Response.Cookies.Set(new HttpCookie("SSID", Session.SessionID));
                    Response.Cookies.Get("SSID").Expires = DateTime.Now.AddMinutes(10);
                    db.LoginInfoes.AddOrUpdate(new LoginInfo
                    {
                        id = login.id,
                        sessionid = Session.SessionID,
                        lastLogin = DateTime.Now,
                        browser = Request.UserAgent 
                    });
                    db.SaveChanges();

                    if (login.role.Equals("student"))
                    {
                        return HomePage(login.id);
                    }
                    else if(login.role.Equals("admin"))
                    {
                        return AdminPanel(login.id);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                    }
                }
            }
        }

        private ActionResult AdminPanel(string userid)
        {
            User principal = db.Users.Find(userid);
            return View("../Admin/Home", principal);
        }

        private ActionResult AddStudent()
        {
            return View("../Student/Add", new Student());
        }

        private ActionResult EditStudent()
        {
            return View("../Student/Edit", db.Students.Find(Request.QueryString.Get("id")));
        }

        private ActionResult AddStudentForm()
        {
            NameValueCollection data = Request.Form;
            String newId = data.Get("entrance").Substring(2, 2) + Request.Form.Get("program").Substring(1, 4) + (new Random().Next(100,999)).ToString();
            String newUsername = (data.Get("name").Substring(0, 1) + data.Get("surname")).ToLower();
            Student student = new Student()
            {
                id = newId,
                name = data.Get("name"),
                surname=data.Get("surname"),
                patronymic = data.Get("patronymic"),
                program = data.Get("program"),
                User = new User()
                {
                    email = data.Get("email"),
                    address = data.Get("address"),
                    mobile = data.Get("mobile"),
                    id = newId,
                    LoginCredential = new LoginCredential()
                    {
                        id = newId,
                        role = "student",
                        password = data.Get("password"),
                        username = newUsername
                    }
                },
                AcademicInfo = new AcademicInfo()
                {
                    advisor = data.Get("advisor"),
                    dis_topic = data.Get("dis_topic"),
                    entrance = int.Parse("0" + data.Get("entrance")),
                    exam_score = int.Parse("0"+data.Get("exam_score")),
                    id = newId,
                    status = data.Get("status"),
                    registration_date = DateTime.Now
                }
            };
            db.Students.AddOrUpdate(student);
            db.SaveChanges();
            return View("../Student/Add", new Student());
        }

        private ActionResult AddProgram()
        {
            return View("../Program/Add", new Program());
        }

        private ActionResult EditProgram()
        {
            return View("../Program/Edit", db.Programs.Find(Request.QueryString.Get("id")));
        }

        private ActionResult AddProgramForm()
        {
            db.Programs.AddOrUpdate(new Program()
            {
                id = Request.Form.Get("id"),
                name=Request.Form.Get("name"),
                department=Request.Form.Get("department"),
                year=int.Parse(Request.Form.Get("year")),
                type=Request.Form.Get("type")
            });
            db.SaveChanges();
            return View("../Program/Add", new Program());
        }
        private ActionResult CreateCourse()
        {
            CreateCourseViewData data = new CreateCourseViewData()
            {
                course = new Course(),
                Programs = db.Programs.ToList()
            };
            return View("../Course/Create", data);
        }

        private ActionResult CreateCourseForm()
        {
            
                Course course = new Course()
                {
                    id = Request.Form.Get("id"),
                    name = Request.Form.Get("name"),
                    credit = int.Parse(Request.Form.Get("credit")),
                    exe = int.Parse(Request.Form.Get("exe")),
                    hours = int.Parse(Request.Form.Get("hours")),
                    lab = int.Parse(Request.Form.Get("lab")),
                    lec = int.Parse(Request.Form.Get("lec")),
                    semester = int.Parse(Request.Form.Get("semester")),
                    program = Request.Form.Get("program")
                };
            db.Courses.AddOrUpdate(course);
            db.SaveChanges();
            
            return CreateCourse();
        }
        private ActionResult EditCourse()
        {
            CreateCourseViewData data = new CreateCourseViewData()
            {
                course = db.Courses.Find(Request.QueryString.Get("id")),
                Programs = db.Programs.ToList()
            };
            return View("../Course/Edit", data);
        }

        private ActionResult HomePage(string userid)
        {
            Student student = db.Students.Find(userid);
            if(student != null)
            {
                return View("../Home/Home", student);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
        }

        private ActionResult CourseStructure(string studentid)
        {
            Student student = db.Students.Find(studentid);
            Program speciality = db.Programs.Find(student.program);
            return View("../Home/CourseStruct", speciality);
        }
        private ActionResult Logout()
        {
            Response.Cookies.Get("SSID").Expires = DateTime.Now;
            return View("../Login/Login");
        }
    }
}
