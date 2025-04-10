using IBM13MR25_MVCDeepDive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM13MR25_MVCDeepDive.Controllers
{
    public class ValidationModelBinderEgController : Controller
    {


        public ActionResult JQueryIntro()
        {
            return View();
        }




        // GET: ValidationModelBinderEg
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.VendorViewModel obj)
        {

            if (ModelState.IsValid==true)
            {
                // add oper
            }


            return View(obj);
        }



        #region Private Methods
        void BindCountry()
        {
            List<Country> lstCountry = new List<Country>{new Country { ID = null, Name = "Select" },
                                                         new Country { ID = 1, Name = "India" },
                                                         new Country { ID = 2, Name = "USA" }


            };


            ViewBag.Country = lstCountry;


        }

        //for server side
        void BindCity(int? mCountry)
        {
            try
            {
                if (mCountry != 0)
                {
                    //below code is only for demo, since city list will come from database based on country
                    //Hence remove below lines of code when you will query data from city table with in database based on country 
                    int index = 1;
                    List<City> lstCity = new List<City>{

                     new City
                    {
                        Country = 0,
                        ID=null,   // using index++ for making unique ID for city
                        Name = "Select"
                    },
                        new City
                    {
                        Country = 1,
                        ID=index++,   // using index++ for making unique ID for city
                        Name = "Delhi"
                    },
                new City
                    {
                        Country = 1,
                        ID=index++,
                        Name = "Lucknow"
                    },
                new City
                    {
                        Country = 1,
                        ID=index++,
                        Name = "Noida"
                    },
                new City
                    {
                        Country = 1,
                        ID=index++,
                        Name = "Guragon"
                    },
                new City
                    {
                        Country = 1,
                        ID=index++,
                        Name = "Pune"
                    },

                new City
                    {
                        Country = 2,
                        ID=index++,
                        Name = "New-York"
                    },
                   new City
                    {
                        Country = 2,
                        ID=index++,
                        Name = "California"
                    },
                new City
                    {
                        Country = 2,
                        ID=index++,
                        Name = "Washington"
                    },
                new City
                    {
                        Country = 2,
                        ID=index++,
                        Name = "Vermont"
                    },

            };

                    var city = from c in lstCity
                               where c.Country == mCountry || c.Country == 0
                               select c;

                    ViewBag.City = city;

                }
                else
                {
                    List<City> City = new List<City> { new City { ID = null, Name = "Select" } };
                    ViewBag.City = City;
                }
            }
            catch (Exception ex)
            {

            }


        }
        #endregion

        //for client side using jquery
        public JsonResult CityList(int mCountry)
        {
            try
            {
                if (mCountry != 0)
                {
                    //below code is only for demo, since city list will come from database based on country
                    //Hence remove below lines of code when you will query data from city table with in database based on country 
                    int index = 1;
                    List<City> lstCity = new List<City>{

                 new City
                    {
                        Country = 0,
                        ID=null,   // using index++ for making unique ID for city
                        Name = "Select"
                    },
                        new City
                    {
                        Country = 1,
                        ID=index++,   // using index++ for making unique ID for city
                        Name = "Delhi"
                    },
                new City
                    {
                        Country = 1,
                        ID=index++,
                        Name = "Lucknow"
                    },
                new City
                    {
                        Country = 1,
                        ID=index++,
                        Name = "Noida"
                    },
                new City
                    {
                        Country = 1,
                        ID=index++,
                        Name = "Guragon"
                    },
                new City
                    {
                        Country = 1,
                        ID=index++,
                        Name = "Pune"
                    },

                new City
                    {
                        Country = 2,
                        ID=index++,
                        Name = "New-York"
                    },
                   new City
                    {
                        Country = 2,
                        ID=index++,
                        Name = "California"
                    },
                new City
                    {
                        Country = 2,
                        ID=index++,
                        Name = "Washington"
                    },
                new City
                    {
                        Country = 2,
                        ID=index++,
                        Name = "Vermont"
                    },

            };

                    var city = from c in lstCity
                               where c.Country == mCountry || c.Country == 0
                               select c;

                    //  return Json(city, JsonRequestBehavior.AllowGet);
                    return Json(new SelectList(city.ToArray(), "ID", "Name"), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(null);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Demo()
        {
            return View();

        }

        public ActionResult RegistrationForm()
        {
            BindCountry();
            BindCity(0);
            return View();
        }
        [HttpPost]
        public ActionResult RegistrationForm(RegistrationModel mRegister)
        {

            if (mRegister.UserName != null)
                if (mRegister.UserName.Length > 15)
                {
                    ModelState.AddModelError("UserName", "UN Len must be < 15");


                }



            //Check Server Side Validation by using data annotation
            if (ModelState.IsValid)
            {




                return View("Completed");
            }
            else
            {
                // To DO: if client validation failed
                ViewBag.Selpwd = mRegister.Password; //for setting password value
                ViewBag.Selconfirmpwd = mRegister.ConfirmPassword;
                ViewBag.SelCountry = mRegister.Country; // for setting selected country
                BindCountry();
                ViewBag.SelCity = mRegister.City;// for setting selected city

                if (mRegister.Country != null)
                    BindCity(mRegister.Country.ID);
                else
                    BindCity(null);

                return View();
            }

        }


        [HttpGet]
        public JsonResult IsUserNameExist(string userName)
        {
            if (userName == "A")
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("false", JsonRequestBehavior.AllowGet);
        }



  
        public ActionResult EFCustomerValidation()
        {

            return View();


        }


        [HttpPost]
        public ActionResult EFCustomerValidation(Models.Customer customer )
        {

            return View();


        }


    }
}