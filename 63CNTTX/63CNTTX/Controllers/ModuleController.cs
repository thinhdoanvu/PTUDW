using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;

namespace _63CNTTX.Controllers
{
    public class ModuleController : Controller
    {
        MenusDAO menusDAO = new MenusDAO();
        ///////////////////////////////////////////////////////////////////
        //GET: MainMenu
        public ActionResult MainMenu()
        {
            return View(menusDAO.getListByParentId(0));
        }
    }
}