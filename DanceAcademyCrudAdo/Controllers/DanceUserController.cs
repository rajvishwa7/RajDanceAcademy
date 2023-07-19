using DanceAcademyCrudAdo.DanceService;
using DanceAcademyCrudAdo.Models;
using System.Web.Mvc;

namespace DanceAcademyCrudAdo.Controllers
{
    public class DanceUserController : Controller
    {
        DanceUserDAL danceUserDAL = new DanceUserDAL();
        // GET: DanceUser
        public ActionResult List()
        {
            var data = danceUserDAL.GetDanceUsers();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DanceUserModel danceUser)
        {
            if (danceUserDAL.InsertDanceUser(danceUser))
            {
                TempData["InsertMsg"] = "<script>alert('Student User Inserted Perfectly!')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "<script>alert('Student User Not Inserted.')</script>";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var data = danceUserDAL.GetDanceUsers().Find(a => a.Id == id);
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = danceUserDAL.GetDanceUsers().Find(a => a.Id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(DanceUserModel danceUser)
        {
            if (danceUserDAL.UpdateDanceUser(danceUser))
            {
                TempData["UpdateMsg"] = "<script>alert('Student User Updated Perfectly!')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "<script>alert('Student User Not Updated.')</script>";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            int r = danceUserDAL.DeleteDanceUser(id);
            if (r > 0)
            {
                TempData["DeleteMsg"] = "<script>alert('Student User Deleted Perfectly!')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "<script>alert('Student User Not Deleted.')</script>";
            }
            return View();
        }
    }
}