using Gym_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using PagedList;
using System.Data.Entity;
using System.Net;

namespace Gym_Management.Controllers
{
    public class HomeController : Controller
    {
        Gym_Management_SystemEntities13 db =new Gym_Management_SystemEntities13();
        public ActionResult trainee_details(int? id)
        {

            physcial_details tr = new physcial_details();
            List<physcial_details> list = db.physcial_details.ToList();
            foreach (var item1 in list)
            {
                trainer y = new trainer();
                List<physcial_details> li = db.physcial_details.Where(x => x.traine_id == id).ToList();

                ViewData["list"] = li;

            
            }

          
            return View();
        }



        public ActionResult trainee_details1(int? id)
        {

            physcial_details tr = new physcial_details();
            List<physcial_details> list = db.physcial_details.ToList();
            foreach (var item1 in list)
            {
                trainer y = new trainer();
                List<physcial_details> li = db.physcial_details.Where(x => x.traine_id == id).ToList();

                ViewData["list"] = li;


            }


            return View();
        }
        public ActionResult trainee_details2(int? id)
        {

            physcial_details tr = new physcial_details();
            List<physcial_details> list = db.physcial_details.ToList();
            foreach (var item1 in list)
            {
                trainer y = new trainer();
                List<physcial_details> li = db.physcial_details.Where(x => x.traine_id == id).ToList();

                ViewData["list"] = li;


            }


            return View();
        }


        public ActionResult Welcome(int? page)
        {
            var trainees = GetTrainee();
            var trainers = GetTrainer();
            var equipments = GetEquipment();
            var charts = GetChart();
            welcomevm model = new welcomevm();
            
            model.trainers = trainers;
          
            model.trainees = trainees;
            model.equipment = equipments;
            model.charts = charts;
            
            return View(model);

        }
        public ActionResult Welcome1()
        {

            return View();

        }
        public ActionResult Welcome2()
        {

            return View();

        }


        public ActionResult Contact()
        {
            return View();

        }

        private List<trainee> GetTrainee()
        {
            int id = 155;
            List<trainee> li1 = db.trainees.Where(x => x.trainee_id <= id).OrderBy(x => x.trainee_id).ToList();
           
            return li1;
        }
        private List<trainer> GetTrainer()
        {
            int id = 27;
             List<trainer> list2 = db.trainers.Where(x => x.trainer_id <= id).OrderBy(x => x.trainer_id).ToList();
         return list2;
      
        
        }
        private List<equipment> GetEquipment()
        {
            int id = 8;
            List<equipment> li = db.equipments.Where(x => x.eq_id <= id).OrderBy(x => x.eq_id ).ToList();
            return li;


        }
        private List<chart> GetChart()
        {
            int id = 12;
            List<chart> li = db.charts.Where(x => x.c_id <= id).OrderBy(x => x.c_id).ToList();
            return li;


        }


        public ActionResult Index()
        {

            


            return View();

        }
      

          
           

        


        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult trainee_size()
        {

            
            return View();
        }
        [HttpPost]
        public ActionResult trainee_size(physcial_details tr)
        {


            List<physcial_details> li = db.physcial_details.OrderByDescending(x => x.p_id).ToList();


            physcial_details tra = new physcial_details();

            tra.T_Hieght = tr.T_Hieght;
            tra.T_Weight = tr.T_Weight;
            tra.T_Age = tr.T_Age;
            tra.traine_id = Convert.ToInt32(Session["trainee_id"].ToString());
            tra.tt_id = 23;/* Convert.ToInt32(Session["tt_id"].ToString());*/
            tra.Mh_id =  Convert.ToInt32(Session["Mh_id"].ToString());
            tra.GB_id= Convert.ToInt32(Session["GB_id"].ToString());
            tra.to_eq_id = Convert.ToInt32(Session["to_eq_id"].ToString());
            tra.GEt_id = 22;
            db.physcial_details.Add(tra);
            db.SaveChanges();
            return RedirectToAction("Trainee_Membership");

        }





        [HttpPost]

        public ActionResult Admin(Admin1 a)
        {
            Admin1 ad = db.Admin1.Where(x => x.a_name == a.a_name && x.a_password == a.a_password).SingleOrDefault();
            if (ad != null)
            {
                Session["a_id"] = ad.a_id;
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewBag.msg = "Invalid Username or Password";

            }
            return View();
        }

        public ActionResult Traineelog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Traineelog(trainee t)
        {
            trainee std = db.trainees.Where(x => x.trainee_name == t.trainee_name && x.trainee_password == t.trainee_password).SingleOrDefault();
            trainee std1 = db.trainees.Where(x => x.trainee_id == t.trainee_id).SingleOrDefault();
            if (std1 != null)
            {
                Session["trainee_id"] = std1.trainee_id;
                return RedirectToAction("Welcome1");
            }

            if (std == null)
            {
                ViewBag.msg = "Invalid or Password";

            }
            else
            {
                Session["trainee_id"] = std.trainee_id;
                return RedirectToAction("Welcome1");
            }





            return View();
        }



        public ActionResult Traineelog1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Traineelog1(trainee t)
        {
            trainee std = db.trainees.Where(x => x.trainee_name == t.trainee_name && x.trainee_password == t.trainee_password).SingleOrDefault();
            trainee std1 = db.trainees.Where(x => x.trainee_id == t.trainee_id).SingleOrDefault();
            if (std1 != null)
            {
                Session["trainee_id"] = std1.trainee_id;
                return RedirectToAction("Trainee_Branch");
            }

            if (std == null)
            {
                ViewBag.msg = "Invalid or Password";

            }
            else
            {
                Session["trainee_id"] = std.trainee_id;
                return RedirectToAction("Trainee_Branch");
            }





            return View();
        }







        [HttpGet]
        public ActionResult Trainer()
        {
            trainer tr = new trainer();
            
            List<trainer> list = db.trainers.ToList();
            foreach (var item1 in list)
            {
                trainer y = new trainer();
                List<trainer> li1 = db.trainers.OrderByDescending(x => tr.trainer_id).ToList();

                ViewData["list"] = li1;


            }
            return View();
        }
        [HttpPost]
        public ActionResult Trainer(trainer tr)
        {


            List<trainer> li = db.trainers.OrderByDescending(x => x.trainer_id).ToList();

            trainer tra = new trainer();
            tra.trainer_name = tr.trainer_name;
            tra.trainer_speciality = tr.trainer_speciality;
            tra.trainer_salary = tr.trainer_salary;
            tra.trainer_id = tr.trainer_id;
            db.trainers.Add(tra);
            db.SaveChanges();

            return RedirectToAction("Trainer");


        }
        [HttpGet]
        public ActionResult Trainee()
        {
            trainee tr = new trainee();
       
            List<trainee> list = db.trainees.ToList();
            foreach (var item1 in list)
            {

                trainer y = new trainer();
                List<trainee> li1 = db.trainees.OrderByDescending(x => tr.trainee_id).ToList();

                ViewData["list"] = li1;


            }
            return View();
        }
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(trainee tr)
        {
            trainee s = new trainee();
            trainer s5 = new trainer();

            try
            {

                s.trainee_name = tr.trainee_name;
                s.trainee_contact = tr.trainee_contact;
                s.trainee_password = tr.trainee_password;
                s.trainee_Gender = tr.trainee_Gender;
                Session["trainee_Gender"]= tr.trainee_Gender;
                db.trainees.Add(s);
                db.SaveChanges();
              
                    return RedirectToAction("Traineelog1");
                
               
            }
            catch (Exception)
            {
                ViewBag.msg = "Please Enter Valid";

            }
            trainee tr1 = db.trainees.Where(x => x.trainee_id == s.trainee_id).SingleOrDefault();
            trainee tr2 = db.trainees.Where(x => x.trainee_id == s.trainee_id).SingleOrDefault();


            return View();
        }
      
        [HttpGet]
        public ActionResult Equipments()
        {
            equipment tr = new equipment();
        
            List<equipment> list = db.equipments.ToList();
            foreach (var item1 in list)
            {
                trainer y = new trainer();
                List<equipment> li1 = db.equipments.OrderByDescending(x => tr.eq_id).ToList();

                ViewData["list"] = li1;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Equipments(equipment tr)
        {


            List<equipment> li = db.equipments.OrderByDescending(x => x.eq_id).ToList();
      

            equipment tra = new equipment();
            tra.eq_name = tr.eq_name;
            tra.eq_tra_id = tr.eq_tra_id;

            db.equipments.Add(tra);
            
            db.SaveChanges();

            return RedirectToAction("Equipments");


        }


        [HttpGet]
        public ActionResult Chart()
        {
            chart tr = new chart();
        
            List<chart> list = db.charts.ToList();
            foreach (var item1 in list)
            {
                trainer y = new trainer();
                List<chart> li1 = db.charts.OrderByDescending(x => tr.c_id).ToList();

                ViewData["list"] = li1;

            }
            return View();
        }
        [HttpPost]
        public ActionResult Chart(chart tr)
        {


            List<chart> li = db.charts.OrderByDescending(x => x.c_id).ToList();
        

            chart tra = new chart();
            tra.chart_name = tr.chart_name;
            tra.chart_description = tr.chart_description;
            tra.chart_weight = tr.chart_weight;
            tra.t_id = tr.t_id;
            db.charts.Add(tra);
            db.SaveChanges();

            return RedirectToAction("Chart");


        }

        [HttpGet]
        public ActionResult Register1()
        {
            trainer tr = new trainer();
            trainee er = new trainee();
            string tid = er.trainee_contact;
            List<trainer> list = db.trainers.ToList();
            List<trainee> list1 = db.trainees.ToList();
            //string tid = Convert.ToInt32(Session["trainee_id"].ToString());
            List<type_of_equipment1> list2 = db.type_of_equipment1.ToList();

            string type;
            foreach (var item3 in list2)
            {
                type = item3.type_of_equipment.Eq_type;


                foreach (var item1 in list)
                {
                    foreach (var item2 in list1)
                    {

                        List<trainer> li = db.trainers.Where(x => x.trainer_id == item1.trainer_id).OrderByDescending(x => x.trainer_id).ToList();
                        List<trainer> li2 = db.trainers.Where(x => x.Gender == item2.trainee_Gender && x.trainer_speciality == type).OrderByDescending(x => x.Gender).ToList();

                        List<trainer> li1 = db.trainers.OrderByDescending(x => tr.trainer_id).ToList();

                        ViewData["list"] = li2;


                    }
                }
            }
            return View(); 

        }
        [HttpPost]
        public ActionResult Register1(student_trainer tr)
        {


            List<trainer> li = db.trainers.OrderByDescending(x => x.trainer_id).ToList();
            ViewData["list"] = li;
            trainer t = new trainer();
            trainee t1 = new trainee();
            student_trainer tra = new student_trainer();

            tra.trainer_id = tr.trainer_id;
            tra.t_id = Convert.ToInt32(Session["trainee_id"].ToString());

            db.student_trainer.Add(tra);
            db.SaveChanges();
            int mid= Convert.ToInt32(Session["M_id"].ToString());
            //if (mid == 2)
            //{
            //    return RedirectToAction("Admin");
            //}
            //else
            //{
            //    return RedirectToAction("Welcome1");
            //}
            return RedirectToAction("Welcome1");
        }

        [HttpGet]
        public ActionResult sTrainer()
        {
            student_trainer list1 = new student_trainer();
         
            int tid = Convert.ToInt32(Session["trainee_id"].ToString());
            
                
            List<student_trainer> li = db.student_trainer.Where(x => x.t_id == tid).OrderByDescending(x => x.s_tr_id).ToList();
           
            ViewData["list"] = li;

            return View();
        }

        public ActionResult Chart1(int? id,int? chart, student_trainer tr3)
        {
           List<chart> tr1=  db.charts.ToList();
            List<student_trainer> tr2 = db.student_trainer.ToList();
            chart tr = new chart(); 
            
            List<chart> list = db.charts.ToList();
            List<trainee_details> list1 = db.trainee_details.ToList();
            int tid = Convert.ToInt32(Session["trainee_id"].ToString());
            foreach (var item2 in list1)
            {

            foreach (var item in list)
            {
                List<chart> li2 = db.charts.Where(x => x.t_id == tid ).OrderByDescending(x => x.c_id).ToList();
                List<chart> li = db.charts.Where(x => x.c_id == item.c_id).ToList();
                ViewData["list"] = li2;
            } 
            }
            return View();

        }
        [HttpGet]
        public ActionResult Select_Timetable()
        {
            List<Timetable> ti = db.Timetables.OrderByDescending(x => x.tt_id).ToList();
            ViewData["list"] = ti;
            return View();
        }

        [HttpPost]
        public ActionResult Select_Timetable(Timetable t)
        {


            List<Timetable> ti = db.Timetables.OrderByDescending(x => x.tt_id).ToList();
            ViewData["list"] = ti;
            Timetable t2 = new Timetable();
            trainee t1 = new trainee();
            student_trainer tra = new student_trainer();

            t2.tt_id = t.tt_id;
            t2.tt_Slot = t.tt_Slot;
            t2.traine_id = Convert.ToInt32(Session["trainee_id"].ToString());
            
            db.Timetables.Add(t2);
            db.SaveChanges();
            Timetable k = db.Timetables.Where(x => x.tt_id == t2.tt_id).SingleOrDefault();
            Session["tt_id"] = k.tt_id;
            return RedirectToAction("trainee_size");


        }

        [HttpGet]
        public ActionResult Select_Membership()
        {
            List<Membership> ti = db.Memberships.OrderByDescending(x => x.M_id).ToList();
            ViewData["list"] = ti;
            return View();
        }

   
        [HttpGet]
        public ActionResult Trainee_Membership()
        {
            Membership_History list1 = new Membership_History();

            int tid = Convert.ToInt32(Session["trainee_id"].ToString());
            List<Membership> ti = db.Memberships.OrderByDescending(x => x.M_id).ToList();
            ViewData["list"] = ti;
            return View();






         
        }

        [HttpPost]
        public ActionResult Trainee_Membership(Membership_History m,int?id)
        {
            Membership mi = new Membership();
            List<Membership> ti2 = db.Memberships.Where(x=>x.M_id==1).OrderBy(x => x.M_id).ToList();
            
         
                List<Membership> ti1 = db.Memberships.OrderBy(x => x.M_id).ToList();
                ViewData["list"] = ti1;
                Membership_History mh1 = new Membership_History();

            Membership m2 = new Membership();
                mh1.Mh_id = m.Mh_id;


                mh1.trainee_id = Convert.ToInt32(Session["trainee_id"].ToString());
                mh1.M_id = m.M_id;
            db.Membership_History.Add(mh1);
            db.SaveChanges();
            Membership_History k1 = db.Membership_History.Where(x => x.Mh_id == mh1.Mh_id).SingleOrDefault();
            Session["Mh_id"] = k1.Mh_id;
            if (m.M_id == 1)
            {

                return RedirectToAction("Welcome1");

            }

            else
            {

                Membership k2 = db.Memberships.Where(x => x.M_id == m2.M_id).SingleOrDefault();
                Session["M_id"] = 2;

                return RedirectToAction("Register1");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Trainee_Branch()
        {
            Gym_Branch list1 = new Gym_Branch();

            int tid = Convert.ToInt32(Session["trainee_id"].ToString());
            List<Gym_Branch_1> ti = db.Gym_Branch_1.OrderByDescending(x => x.B_id).ToList();
            ViewData["list"] = ti;
            return View();

        }

        [HttpPost]
        public ActionResult Trainee_Branch(Gym_Branch m)
        {

            int tid = Convert.ToInt32(Session["trainee_id"].ToString());
            List<Gym_Branch_1> ti = db.Gym_Branch_1.OrderByDescending(x => x.B_id).ToList();
            ViewData["list"] = ti;
            Gym_Branch mh = new Gym_Branch();


            mh.GB_id = m.GB_id;
           

            mh.trainee_id = Convert.ToInt32(Session["trainee_id"].ToString());
            mh.B_id = m.B_id;
            db.Gym_Branch.Add(mh);
            db.SaveChanges();
            Gym_Branch k = db.Gym_Branch.Where(x => x.GB_id == mh.GB_id).SingleOrDefault();
            Session["GB_id"] = k.GB_id;
            return RedirectToAction ("type_of_equipment");
        }
        [HttpGet]
        public ActionResult Trainee_Equipment()
        {
            Gym_Equipment_type_1 list1 = new Gym_Equipment_type_1();

            int tid = Convert.ToInt32(Session["trainee_id"].ToString());
            List<Gym_Equipment_type_1> ti = db.Gym_Equipment_type_1.OrderByDescending(x => x.Et_id).ToList();
            ViewData["list"] = ti;
            return  View();







        }

        [HttpPost]
        public ActionResult Trainee_Equipment(Gym_Equipment_type m)
        {
            Gym_Equipment_type_1 list1 = new Gym_Equipment_type_1();

            int tid = Convert.ToInt32(Session["trainee_id"].ToString());
            List<Gym_Equipment_type_1> ti = db.Gym_Equipment_type_1.OrderByDescending(x => x.Et_id).ToList();
            ViewData["list"] = ti;
            Gym_Equipment_type mh = new Gym_Equipment_type();


            mh.GEt_id = m.GEt_id;


            mh.trainee_id = Convert.ToInt32(Session["trainee_id"].ToString());
            mh.Et_id = m.Et_id;
            db.Gym_Equipment_type.Add(mh);
            db.SaveChanges();
            Gym_Equipment_type k = db.Gym_Equipment_type.Where(x => x.GEt_id == mh.GEt_id).SingleOrDefault();
            Session["GEt_id"] = k.GEt_id;
            return RedirectToAction("Select_Timetable"); 
        }
        public ActionResult Trainerlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Trainerlog(trainer t)
        {
            trainer std = db.trainers.Where(x => x.trainer_name == t.trainer_name && x.trainer_password == t.trainer_password).SingleOrDefault();
            trainer std1 = db.trainers.Where(x => x.trainer_id == t.trainer_id).SingleOrDefault();
            if (std1 != null)
            {
                Session["trainer_id"] = std1.trainer_id;
                return RedirectToAction("Welcome2");
            }

            if (std == null)
            {
                ViewBag.msg = "Invalid or Password";

            }
            else
            {
                Session["trainer_id"] = std.trainer_id;
                return RedirectToAction("Welcome2");
            }


            return View();
        }

        [HttpGet]
        public ActionResult Trainee_Record_Trainer(int? id)
        {
            trainee tr = new trainee();
            trainer t = new trainer();

            student_trainer s = new student_trainer();


            List<trainer> list = db.trainers.ToList();
            foreach (var item1 in list)
            {

                int tid = Convert.ToInt32(Session["trainer_id"].ToString());
                trainer y = new trainer();
                List<student_trainer> li1 = db.student_trainer.Where(x => x.trainer_id == tid).OrderByDescending(x => x.t_id).ToList();

                ViewData["list"] = li1;



            }
            return View();
        }
        [HttpPost]
        public ActionResult Trainee_Record_Trainer()
        {
            trainee tr = new trainee();
            student_trainer s = new student_trainer();
            trainer t = new trainer();
            int tid = Convert.ToInt32(Session["trainer_id"].ToString());
            List<student_trainer> list = db.student_trainer.ToList();
            foreach (var item1 in list)
            {

                trainer y = new trainer();

                List<student_trainer> li1 = db.student_trainer.Where(x => x.trainer_id == tid).OrderByDescending(x => x.t_id).ToList();

                ViewData["list"] = li1;
                break;


            }
            return View();
        }

        [HttpGet]
        public ActionResult Trainer_Proifle(trainer t)
        {
            trainer tr = new trainer();
            List<trainer> list = db.trainers.ToList();
            foreach (var item1 in list)
            {

                int tid = Convert.ToInt32(Session["trainer_id"].ToString());
                trainer y = new trainer();
                List<trainer> li1 = db.trainers.Where(x => x.trainer_id == tid).OrderByDescending(x => x.trainer_id).ToList();

                ViewData["list"] = li1;



            }
            return View();
        }


        public ActionResult BasicUser()
        {

            return View();


        }
        /*Basic USER CLASSES*/
        public ActionResult Basic()
        {

            return View();

        }
        public ActionResult Basic_Profile()
        {

            return View();

        }
        /*PRO USER CLASSES*/
        public ActionResult Pro()
        {

            return View();

        }
        public ActionResult Pro_Trainer()
        {
            student_trainer list1 = new student_trainer();

            int tid = Convert.ToInt32(Session["trainee_id"].ToString());


            List<student_trainer> li = db.student_trainer.Where(x => x.t_id == tid).OrderByDescending(x => x.s_tr_id).ToList();

            ViewData["list"] = li;

            return View();
        }
      
        public ActionResult Pro_Profile()
        {

            return View();

        }
        public ActionResult Premium()
        {

            return View();

        }
        public ActionResult Premium_Profile()
        {

            return View();

        }
        public ActionResult Premium_Chart()
        {

            return View();

        }
        public ActionResult Premium_Trainer()
        {

            student_trainer list1 = new student_trainer();

            int tid = Convert.ToInt32(Session["trainee_id"].ToString());


            List<student_trainer> li = db.student_trainer.Where(x => x.t_id == tid).OrderByDescending(x => x.s_tr_id).ToList();

            ViewData["list"] = li;

            return View();

        }
       
        public ActionResult Profile()
        {
            trainee tr = new trainee();
            List<trainee> list = db.trainees.ToList();
            foreach (var item1 in list)
            {

                int tid = Convert.ToInt32(Session["trainee_id"].ToString());
                trainer y = new trainer();
                List<trainee> li1 = db.trainees.Where(x => x.trainee_id == tid).OrderByDescending(x => x.trainee_id).ToList();

                ViewData["list"] = li1;



            }
            return View();


        }

        [HttpGet]
        public ActionResult type_of_equipment()
        {
            type_of_equipment list1 = new type_of_equipment();

            int tid = Convert.ToInt32(Session["trainee_id"].ToString());
            List<type_of_equipment> ti = db.type_of_equipment.OrderByDescending(x => x.t_e_id).ToList();
            ViewData["list"] = ti;
            return View();







        }

        [HttpPost]
        public ActionResult type_of_equipment(type_of_equipment1 m)
        {
            Gym_Equipment_type_1 list1 = new Gym_Equipment_type_1();

            int tid = Convert.ToInt32(Session["trainee_id"].ToString());
            List<type_of_equipment> ti = db.type_of_equipment.OrderByDescending(x => x.t_e_id).ToList();
            ViewData["list"] = ti;
            type_of_equipment1 mh = new type_of_equipment1();


            mh.to_eq_id = m.to_eq_id;


            mh.trainee_id = Convert.ToInt32(Session["trainee_id"].ToString());
            mh.t_e_id = m.t_e_id;
            Session["t_e_id"] = m.to_eq_id;
            db.type_of_equipment1.Add(mh);
            db.SaveChanges();
            type_of_equipment1 k = db.type_of_equipment1.Where(x => x.to_eq_id == mh.to_eq_id).SingleOrDefault();
            Session["to_eq_id"] = k.to_eq_id;
            return RedirectToAction("Select_Timetable");
        }


        /*GET: Gym_Branch_1*/
        public ActionResult Gym_Branch_Index()
        {
            return View(db.Gym_Branch_1.ToList());
        }

        // GET: Gym_Branch_1/Details/5
        public ActionResult Gym_Branch_Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym_Branch_1 gym_Branch_1 = db.Gym_Branch_1.Find(id);
            if (gym_Branch_1 == null)
            {
                return HttpNotFound();
            }
            return View(gym_Branch_1);
        }

        // GET: Gym_Branch_1/Create
        public ActionResult Gym_Branch_Create()
        {
            return View();
        }

        // POST: Gym_Branch_1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gym_Branch_Create([Bind(Include = "B_id,B_Name")] Gym_Branch_1 gym_Branch_1)
        {
            if (ModelState.IsValid)
            {
                db.Gym_Branch_1.Add(gym_Branch_1);
                db.SaveChanges();
                return RedirectToAction("Gym_Branch_Index");
            }


            return View(gym_Branch_1);
        }

        // GET: Gym_Branch_1/Edit/5
        public ActionResult Gym_Branch_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym_Branch_1 gym_Branch_1 = db.Gym_Branch_1.Find(id);
            if (gym_Branch_1 == null)
            {
                return HttpNotFound();
            }
            return View(gym_Branch_1);
        }

        // POST: Gym_Branch_1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "B_id,B_Name")] Gym_Branch_1 gym_Branch_1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gym_Branch_1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Gym_Branch_Index");
            }
            return View(gym_Branch_1);
        }

        // GET: Gym_Branch_1/Delete/5
        public ActionResult Gym_Branch_Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym_Branch_1 gym_Branch_1 = db.Gym_Branch_1.Find(id);
            if (gym_Branch_1 == null)
            {
                return HttpNotFound();
            }
            return View(gym_Branch_1);
        }

        // POST: Gym_Branch_1/Delete/5
        [HttpPost, ActionName("Gym_Branch_Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gym_Branch_1 gym_Branch_1 = db.Gym_Branch_1.Find(id);
            db.Gym_Branch_1.Remove(gym_Branch_1);
            db.SaveChanges();
            return RedirectToAction("Gym_Branch_Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Gym_Equipment_type_1
        public ActionResult Gym_Equipment_typeIndex()
        {
            return View(db.Gym_Equipment_type_1.ToList());
        }

        // GET: Gym_Equipment_type_1/Details/5
        public ActionResult Gym_Equipment_typeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym_Equipment_type_1 gym_Equipment_type_1 = db.Gym_Equipment_type_1.Find(id);
            if (gym_Equipment_type_1 == null)
            {
                return HttpNotFound();
            }
            return View(gym_Equipment_type_1);
        }

        // GET: Gym_Equipment_type_1/Create
        public ActionResult Gym_Equipment_typeCreate()
        {
            return View();
        }

        // POST: Gym_Equipment_type_1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gym_Equipment_typeCreate([Bind(Include = "Et_id,Eq_type")] Gym_Equipment_type_1 gym_Equipment_type_1)
        {
            if (ModelState.IsValid)
            {
                db.Gym_Equipment_type_1.Add(gym_Equipment_type_1);
                db.SaveChanges();
                return RedirectToAction("Gym_Equipment_typeIndex");
            }

            return View(gym_Equipment_type_1);
        }

        // GET: Gym_Equipment_type_1/Edit/5
        public ActionResult Gym_Equipment_typeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym_Equipment_type_1 gym_Equipment_type_1 = db.Gym_Equipment_type_1.Find(id);
            if (gym_Equipment_type_1 == null)
            {
                return HttpNotFound();
            }
            return View(gym_Equipment_type_1);
        }

        // POST: Gym_Equipment_type_1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gym_Equipment_typeEdit([Bind(Include = "Et_id,Eq_type")] Gym_Equipment_type_1 gym_Equipment_type_1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gym_Equipment_type_1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Gym_Equipment_typeIndex");
            }
            return View(gym_Equipment_type_1);
        }

        // GET: Gym_Equipment_type_1/Delete/5
        public ActionResult Gym_Equipment_typeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym_Equipment_type_1 gym_Equipment_type_1 = db.Gym_Equipment_type_1.Find(id);
            if (gym_Equipment_type_1 == null)
            {
                return HttpNotFound();
            }
            return View(gym_Equipment_type_1);
        }

        // POST: Gym_Equipment_type_1/Delete/5
        [HttpPost, ActionName("Gym_Equipment_typeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult Gym_Equipment_typeDeleteConfirmed(int id)
        {
            Gym_Equipment_type_1 gym_Equipment_type_1 = db.Gym_Equipment_type_1.Find(id);
            db.Gym_Equipment_type_1.Remove(gym_Equipment_type_1);
            db.SaveChanges();
            return RedirectToAction("Gym_Equipment_typeIndex");
        }
        [HttpGet]
        public ActionResult trainer_Details()
        {
            trainer tr = new trainer();

            List<trainer> list = db.trainers.ToList();
            foreach (var item1 in list)
            {
                trainer y = new trainer();
                List<trainer> li1 = db.trainers.OrderByDescending(x => tr.trainer_id).ToList();

                ViewData["list"] = li1;


            }
            return View();
        }


        // GET: trainers/Edit/5
        public ActionResult trainer_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainer trainer = db.trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.trainee_id = new SelectList(db.trainees, "trainee_id", "trainee_name", trainer.trainee_id);
            return View(trainer);
        }

        // POST: trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult trainer_Edit([Bind(Include = "trainer_id,trainer_name,trainer_speciality,trainer_salary,for_weight,Gender,trainer_password,trainee_id")] trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Trainer");
            }
            ViewBag.trainee_id = new SelectList(db.trainees, "trainee_id", "trainee_name", trainer.trainee_id);
            return View(trainer);
        }
        // GET: trainees/Edit/5
        public ActionResult trainee_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainee trainee = db.trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult trainee_Edit([Bind(Include = "trainee_id,trainee_name,trainee_contact,trainee_password,trainee_Gender")] trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Trainee");
            }
            return View(trainee);
        }

        // GET: equipments/Edit/5
        public ActionResult Equipment_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equipment equipment = db.equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.eq_tra_id = new SelectList(db.trainers, "trainer_id", "trainer_name", equipment.eq_tra_id);
            return View(equipment);
        }

        // POST: equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Equipment_Edit([Bind(Include = "eq_id,eq_name,eq_tra_id")] equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Equipments");
            }
            ViewBag.eq_tra_id = new SelectList(db.trainers, "trainer_id", "trainer_name", equipment.eq_tra_id);
            return View(equipment);
        }

        // GET: charts/Edit/5
        public ActionResult Chart_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chart chart = db.charts.Find(id);
            if (chart == null)
            {
                return HttpNotFound();
            }
            ViewBag.t_id = new SelectList(db.trainees, "trainee_id", "trainee_name", chart.t_id);
            return View(chart);
        }

        // POST: charts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Chart_Edit([Bind(Include = "c_id,chart_name,chart_description,chart_weight,t_id")] chart chart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Chart");
            }
            ViewBag.t_id = new SelectList(db.trainees, "trainee_id", "trainee_name", chart.t_id);
            return View(chart);
        }




    }

}