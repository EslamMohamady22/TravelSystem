using JobOfferWebiste.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult PostComment(int? id)
        {
            return View(db.CommentsModels.Where(a => a.Id == id).SingleOrDefault());
        }
        public ActionResult AllUsers()
        {
            return View(db.Users.ToList());
        }

        public ActionResult EditAllUsers(string id)
        {
            //var user = db.Users.Find(userId);


            //Session[userId] = userId;
            //return View(user);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser job = db.Users.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }



        public ActionResult DeleteUsers(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser job = db.Users.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("DeleteUsers")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            
            ApplicationUser job = db.Users.Find(id);
            
            db.Users.Remove(job);
            db.SaveChanges();
            return RedirectToAction("AllUsers");
        }



        public ActionResult DeleteComment(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentsModel job = db.CommentsModels.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedComment(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentsModel job = db.CommentsModels.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
           

            db.CommentsModels.Remove(job);
            db.SaveChanges();
            return RedirectToAction("ViewAgencycomment");
        }





        //public ActionResult EditProfile()
        //{
        //    var UserID = User.Identity.GetUserId();
        //    var user = db.Users.Where(a => a.Id == UserID).SingleOrDefault();
        //    EditProfileViewModel profile = new EditProfileViewModel();
        //    profile.UserName = user.UserName;
        //    profile.Email = user.Email;
        //    profile.PhoneNumper = user.PhoneNumber;

        //    return View(profile);
        //}

        //[HttpPost]
        //public ActionResult EditProfile(EditProfileViewModel profile)
        //{
        //    var UserID = User.Identity.GetUserId();
        //    var CurrentUser = db.Users.Where(a => a.Id == UserID).SingleOrDefault();
        //    if (!UserManager.CheckPassword(CurrentUser, profile.CurrentPassword))
        //    {
        //        ViewBag.Message = "كلمة السر الحالية غير صحيحة";
        //    }
        //    else
        //    {
        //        var newPasswordHash = UserManager.PasswordHasher.HashPassword(profile.NewPassword);
        //        CurrentUser.UserName = profile.UserName;
        //        CurrentUser.Email = profile.Email;
        //        CurrentUser.PhoneNumber = profile.PhoneNumper;
        //        CurrentUser.LastName = profile.LastName;
        //        CurrentUser.FirstName = profile.FirstName;
        //        CurrentUser.PasswordHash = newPasswordHash;
        //        db.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        ViewBag.Message = "تمت عملية التحديث بنجاح";
        //    }
        //    return View(profile);
        //}


        //UserManager
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //SignInManager
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ActionResult AdminEditUser(string id)
        {
            
            var user = db.Users.Where(a => a.Id == id).SingleOrDefault();
            EditProfileViewModel profile = new EditProfileViewModel();
            profile.UserName = user.UserName;
            profile.Email = user.Email;
            profile.PhoneNumper = user.PhoneNumber;
            profile.UserType = user.UserType;

            return View(profile);
        }

        [HttpPost]
        public ActionResult AdminEditUser(  EditProfileViewModel profile , string id)
        {
           
            var CurrentUser = db.Users.Where(a => a.Id == id).SingleOrDefault();
            if (!UserManager.CheckPassword(CurrentUser, profile.CurrentPassword))
            {
                ViewBag.Message = "كلمة السر الحالية غير صحيحة";
            }
            else
            {
                var newPasswordHash = UserManager.PasswordHasher.HashPassword(profile.NewPassword);
                CurrentUser.UserName = profile.UserName;
                CurrentUser.Email = profile.Email;
                CurrentUser.PhoneNumber = profile.PhoneNumper;
                CurrentUser.LastName = profile.LastName;
                CurrentUser.FirstName = profile.FirstName;
                CurrentUser.UserType = profile.UserType;
                CurrentUser.PasswordHash = newPasswordHash;
                db.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "تمت عملية التحديث بنجاح";
            }
            return View(profile);
        }


        //AddErrors
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ActionResult AdminCreateUser()
        {
            
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminCreateUser(AdminRegisterViewModel model, HttpPostedFileBase upload)
        {
           
                ApplicationUser user = new ApplicationUser();
            ///*var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, UserType = model.UserType, FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNumber, UserImage = model.UserImage };
            //*/

            //return RedirectToAction("LogOff", "Account");


            if (ModelState.IsValid) 
            {

                string path = Path.Combine(Server.MapPath("~/Userimages"), upload.FileName);
                upload.SaveAs(path);
                model.UserImage = upload.FileName;
                
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("LogOff", "Account");
            }

           

            return RedirectToAction("AllUsers" , "Home");
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
       

       


        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> AdminCreateUser(AdminRegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {





        //        //string path = Path.Combine(Server.MapPath("~/Uploads"), Userimages.FileName);
        //        //Userimages.SaveAs(path);
        //        //model.UserImage = Userimages.FileName;
        //        string username = User.Identity.Name;
        //        ViewBag.UserType = new SelectList(db.Roles.Where(a => !a.Name.Contains("Adminstrator")).ToList(), "Name", "Name");
        //        var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, UserType = model.UserType, FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNumber, UserImage = model.UserImage };




        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

















        //public ActionResult View_comment()
        //{
        //    CommentsModel vc = new CommentsModel(); 
        //      var JobId = (int)Session["JobId"];
        //    if (vc.JobId == JobId) 
        //    {
        //        return View(db.CommentsModels.Where(a => a.Id == JobId).SingleOrDefault());
        //    }
        //    else 
        //    {
        //        return View(db.CommentsModels.ToList());
        //    }

        //}

        public ActionResult AdminViewAllComments() 
        {
            return View(db.CommentsModels.ToList());
        }

       
        public ActionResult ViewAgencyComment()
        {
            return View(db.CommentsModels.ToList());
        }



        [Authorize]
        public ActionResult Detailse(int JopId)
        {

            var jop = db.Jobs.Find(JopId);
            if (jop == null)
            {
                return HttpNotFound();
            }

            Session["JobId"] = JopId;
            return View(jop);
        }


        


       



        //public ActionResult Like(int id)
        //{
        //    PostModel update = db.PostModels.ToList().Find(u => u.post_Id == id);
        //    update.post_Like += 1;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}




        [Authorize]
        public ActionResult Aplay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Aplay(string massage)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];

            var check = db.AplaForJobs.Where(a => a.UserId == UserId && a.JobId == JobId).ToList();
            if (check.Count < 1)
            {
                var aplayjob = new AplaForJob();
                aplayjob.UserId = UserId;
                aplayjob.JobId = JobId;
                
                aplayjob.commentDate = DateTime.Now;
                db.AplaForJobs.Add(aplayjob);
                db.SaveChanges();
                ViewBag.Result = "Post Are Saved Successfly";
            }
            else
            {
                ViewBag.Result = "This Post Are Saved";

            }
        return View();
        }

       


        [Authorize]
        public ActionResult AddComment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddComment(string Add_New_Comment )
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];


            var UserComment = new CommentsModel();
            UserComment.UserId = UserId;
            UserComment.JobId = JobId;
            UserComment.commentMassage = Add_New_Comment;
            UserComment.commentDate = DateTime.Now;
            db.CommentsModels.Add(UserComment);
            db.SaveChanges();


            return View();
        }








        [Authorize]
        public ActionResult AgencyAddComment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgencyAddComment(string Add_New_Comment)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];


            //var UserComment = new Agency_Comments();
            //UserComment.UserId = UserId;
            //UserComment.JobId = JobId;
            //UserComment.AgencycommentMassage = Add_New_Comment;
            //UserComment.AgencycommentDate = DateTime.Now;
            //db.Add(UserComment);
            //db.SaveChanges();


            return View();
        }









        [Authorize]
        public ActionResult GetJobsByPublisher()
        {
            var UserId = User.Identity.GetUserId();
            var jobs = db.Jobs.Where(a => a.UserID == UserId).ToList();
            return View(jobs.ToList());
        }






        [Authorize]
        public ActionResult GetJobsByUser()
        {
            var UserId = User.Identity.GetUserId();
            var jobs = db.AplaForJobs.Where(a => a.UserId == UserId).ToList();
            return View(jobs.ToList());
        }




       





        public ActionResult Edit(int id)
        {
            var job = db.AplaForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [HttpPost]
        public ActionResult Edit(AplaForJob job)
        {
            if (ModelState.IsValid)
            {
                job.commentDate = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("GetJobsByUser");
            }
            return View(job);
        }

        public ActionResult Delete(int id)
        {

            var job = db.AplaForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(AplaForJob job)
        {
            // TODO: Add delete logic here
            var myJob = db.AplaForJobs.Find(job.Id);
            db.AplaForJobs.Remove(myJob);
            db.SaveChanges();
            return RedirectToAction("GetJobsByUser");

        }



        public ActionResult DetailsOfJob(int id)
        {
            var job = db.AplaForJobs.Find(id);

            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SearchItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchItem(string Search)
        {
            var result = db.Jobs.Where(a => a.TripDetails.Contains(Search)
            || a.TripTitle.Contains(Search)
            || a.Category.CategoryName.Contains(Search)
            || a.Category.CategoryDescription.Contains(Search)
            || a.TripDate.Contains(Search)
            || a.Price.Contains(Search)
            || a.AgencyName.Contains(Search)).ToList();

            return View(result);
        }

      
        public ActionResult AddAgencyComment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAgencyComment(string Add_New_Agency_Comment)
        {

            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];


            var AgencyComment = new CommentsModel();
            AgencyComment.UserId = UserId;
            AgencyComment.JobId = JobId;
            AgencyComment.AgencycommentMassage = Add_New_Agency_Comment;
            AgencyComment.commentDate = DateTime.Now;
            db.CommentsModels.Add(AgencyComment);
            db.SaveChanges();
            return View();
        }

    }
}