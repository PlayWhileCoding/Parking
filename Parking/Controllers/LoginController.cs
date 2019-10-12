using Newtonsoft.Json;
using Parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Parking.Controllers
{
    
    public class LoginController : Controller
    {
        private HttpClient client = new HttpClient();
        private LoginM model;
        protected string EmployeeID;
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginM data)
        {

            if (!ModelState.IsValid)
                return View();

            model = data;
            client.BaseAddress = CommonData.ApiUrl;

            var jsonString = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            IEnumerable<string> found;
            try
            {
                HttpResponseMessage responseFromRequest = await client.PostAsync("api/ExternalLogin", content);

                if (responseFromRequest != null)
                {
                    System.Net.Http.Headers.HttpResponseHeaders headers = responseFromRequest.Headers;
                    if (headers.Contains("Found"))
                    {
                        if (headers.TryGetValues("Found", out found) && found.ToArray()[0] == "true")
                        {
                            if (headers.Contains("EmployeeID"))
                            {
                                EmployeeID = headers.GetValues("EmployeeID").ToString();
                                Session["UserName"] = model.UserName;
                                Session["SafetyLogged"] = true;
                                return RedirectToAction("", "");
                            }
                            else if (headers.Contains("WrongPassword"))
                            {
                                ViewBag.Error = "Password doesn't match.";
                                return RedirectToAction("Login", "Login");
                            }
                        }
                        else if (headers.TryGetValues("Found", out found) && found.ToArray()[0] == "false")
                        {
                            if (headers.Contains("UserNotFound"))
                            {
                                ViewBag.Error = "Username not found";
                                return RedirectToAction("", "");
                            }
                            else if (headers.Contains("WrongPassword"))
                            {
                                ViewBag.Error = "Password incorrect";
                                return RedirectToAction("", "");
                            }
                        }
                    }
                }
                ViewBag.Error = "Internal issue, please try again later.";
                return RedirectToAction("", "");
            }
            catch (Exception exc)
            {
                return View("Error");
                 
            }

        }

        private async Task<bool> ValidateLogin()
        {
            client.BaseAddress = CommonData.ApiUrl;

            var jsonString = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            IEnumerable<string> found;
            try
            {
                HttpResponseMessage responseFromRequest = await client.PostAsync("api/ExternalLogin", content);

                if (responseFromRequest != null)
                {
                    System.Net.Http.Headers.HttpResponseHeaders headers = responseFromRequest.Headers;
                    if (headers.Contains("Found"))
                    {
                        if (headers.TryGetValues("Found", out found) && found.ToArray()[0] == "true")
                        {
                            if (headers.Contains("EmployeeID"))
                            {
                                EmployeeID = headers.GetValues("EmployeeID").ToString();
                                Session["UserName"] = model.UserName;
                                Session["SafetyLogged"] = true;
                                return true;
                            }
                            else if (headers.Contains("WrongPassword"))
                            {
                                ViewBag.Error = "Password doesn't match.";
                                return false;
                            }
                        }
                        else if (headers.TryGetValues("Found", out found) && found.ToArray()[0] == "false")
                        {
                            if (headers.Contains("UserNotFound"))
                            {
                                ViewBag.Error = "Username not found";
                                return false;
                            }
                            else if (headers.Contains("WrongPassword"))
                            {
                                ViewBag.Error = "Password incorrect";
                                return false;
                            }
                        }
                    }
                }
                ViewBag.Error = "Internal issue, please try again later.";
                return false;
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(exc.Message) + "')</>");
                return false;
            }           


            #region validationUsingEntFramework
            //parkingEntities entity = new parkingEntities();

            ////using linq to find user
            //var result = entity.SystemUsers.FirstOrDefault(m => m.LoginUserName == loginData.UserName);

            //if (result != null)
            //{
            //    var userAndPass = entity.SystemUsers.FirstOrDefault(m => m.LoginUserName == loginData.UserName && m.LoginPassword == loginData.Password);

            //    if(userAndPass != null)
            //    {
            //        Session["UserName"] = result.LoginUserName;
            //        Session["SafetyLogged"] = true;
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        ViewBag.WrongData = "Wrong password.";
            //        return View("Login");
            //    }  
            //}                
            //else
            //{
            //    ViewBag.LoginError = "User ot found.";
            //    return View("Login");
            //}

            #endregion

        }
    }
}