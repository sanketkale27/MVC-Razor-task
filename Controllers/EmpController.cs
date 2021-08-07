using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Retail.Context;
using Retail.Models;

namespace Retail.Controllers
{
    public class EmpController : Controller
    {

        RetailEntities1 db = new RetailEntities1();
        string msg { get; set; }
        // GET: Emp        
        public ActionResult Emp(Emp_details obj)
        {
            try
            {
                ModelState.Clear();
                obj.message = msg;
                return View(obj);
            }
            catch (Exception)
            {
                return View(obj);
            }
                
          
        }

        [HttpPost]
        public ActionResult AddEmp(Emp_details modelemp)
        {
            try
            {
                Emp_details objemp = new Emp_details();
                if (ModelState.IsValid)
                {

                   
                    objemp.EmployeeID = modelemp.EmployeeID;
                    objemp.EmployeeName = modelemp.EmployeeName;
                    objemp.Address = modelemp.Address;
                    objemp.Mobile_No = modelemp.Mobile_No;
                    if (modelemp.EmployeeID == 0)
                    {
                        db.Emp_details.Add(objemp);
                        db.SaveChanges();
                        msg = "Record save successfully!";
                    }
                    else
                    {
                        db.Entry(objemp).State = EntityState.Modified;
                        db.SaveChanges();
                        msg = "Record edited successfully!";
                    }
                }

                ModelState.Clear();
                modelemp.message = msg;
                return View("Emp", modelemp);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                return View("Emp");
            }

        }

        public ActionResult Emplist(Emp_details modelemp)
        {
            try
            {
                var res = db.Emp_details.ToList();
                return View(res);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                return View("Emplist"); 
            }
          
        }


        public ActionResult Delete(int EmployeeID)
        {
            try
            {
                var res = db.Emp_details.Where(x => x.EmployeeID == EmployeeID).First();

                db.Emp_details.Remove(res);
                db.SaveChanges();               
                var lst = db.Emp_details.ToList();                
                return View("Emplist", lst);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                return View("Emplist"); 
            }         
           
        }
    
       
      public ActionResult CalculateEmpHrs(Revenue_details objrev)
        {

            try
            {
                ModelState.Clear();
                List<SelectListItem> emplist = new List<SelectListItem>();
                List<SelectListItem> shiftlist = new List<SelectListItem>();
                Revenue_details viewModel = new Revenue_details();
                emplist = Empdata();
                viewModel.EmpList = emplist;
                shiftlist = Shiftdata();
                viewModel.message = msg;
                viewModel.Shiftlist = shiftlist;
                return View(viewModel);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message.ToString());
                return View("Emplist");
            }

           
        }

        [HttpPost]
        public ActionResult AddEmphrs(Revenue_details objrev)
        {
            try
            {
                Revenue_details obj = new Revenue_details();
                var hrs = objrev.hrs_worked;
                int shiftid = Convert.ToInt32(objrev.Shits);

                var minbreak = db.WorkShifts.Where(x => x.ID == shiftid).Select(x => x.MiniBreak).SingleOrDefault();
                var longbreak = db.WorkShifts.Where(x => x.ID == shiftid).Select(x => x.LongBreak).SingleOrDefault();

                int finalhrs = calhrs(Convert.ToInt32(minbreak), Convert.ToInt32(longbreak), Convert.ToInt32(hrs));

                var hr_pay = db.WorkShifts.Where(x => x.ID == shiftid).Select(x => x.per_hr_pay).SingleOrDefault();

                int rev = finalhrs * Convert.ToInt32(hr_pay);

                obj.EmployeeID = objrev.EmployeeID;
                obj.work_date = objrev.work_date;
                obj.hrs_worked = Convert.ToString(finalhrs);
                obj.Shits = objrev.Shits;
                obj.Revenue = rev;
                db.Revenue_details.Add(obj);
                db.SaveChanges();
                msg = "Record save successfully!";
                List<SelectListItem> emplist = new List<SelectListItem>();
                List<SelectListItem> shiftlist = new List<SelectListItem>();
                
                emplist = Empdata();
                objrev.EmpList = emplist;
                shiftlist = Shiftdata();
                objrev.message = msg;
                objrev.Shiftlist = shiftlist;

                return View("CalculateEmpHrs", objrev);
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();               
                return View("CalculateEmpHrs", objrev);
            }
           
        }


        public int calhrs(int minibreak,int longbreak,int hrs)
        {

            int minihrs, b, totalhrs, actualhrs, finalhrs;
            try
            {
                minihrs = hrs * minibreak;
                b = 0;
                if (hrs > 4)
                {
                    int num = hrs / 4;
                    long longb = (long)num;
                    b = (int)longb * longbreak;
                }
                totalhrs = hrs * 60;
                actualhrs = totalhrs - (minihrs + b);
                finalhrs = actualhrs / 60;
                return finalhrs;

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message.ToString());
                return 0;
            }
           
        }

        public List<SelectListItem> Empdata()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                RetailEntities1 mb = new RetailEntities1();
               
                foreach (Emp_details e in db.Emp_details)
                {
                    SelectListItem item = new SelectListItem()
                    {
                        Text = e.EmployeeName,
                        Value = e.EmployeeID.ToString(),
                        Selected = false
                    };
                    list.Add(item);
                }

                return list;
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message.ToString());
                return null;

            }
           
        }

        public List<SelectListItem> Shiftdata()
        {
            try
            {
                RetailEntities1 mb = new RetailEntities1();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (WorkShift e in db.WorkShifts)
                {
                    SelectListItem item = new SelectListItem()
                    {
                        Text = e.Shifts,
                        Value = e.ID.ToString(),
                        Selected = false
                    };
                    list.Add(item);
                }

                return list;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                return null;
            }
            
        }

        public ActionResult EmpReport()
        {
         

            try
            {
               
                var result = (from emp in db.Emp_details
                              join reve in db.Revenue_details on emp.EmployeeID equals reve.EmployeeID
                              join sh in db.WorkShifts on reve.Shits equals sh.ID                          
                              
                              select new empdetaillist
                              {
                                  EmployeeName = emp.EmployeeName,
                                  Date = reve.work_date,
                                  Shift = sh.Shifts,
                                  Hrs_Worked = reve.hrs_worked,
                                  Revenue =  reve.Revenue
                              }).ToList();
                return View(result);

              
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                return View("EmpReport");
            }

        }


    }
}