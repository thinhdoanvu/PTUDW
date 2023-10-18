using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _63CNTT5N2.Library;
using MyClass.DAO;
using MyClass.Model;

namespace _63CNTT5N2.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesDAO categoriesDAO = new CategoriesDAO();
        ///////////////////////////////////////////////////////////////////
        /// INDEX
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(categoriesDAO.getList("Index"));//chi hien thi cac dong co status ==1/2
        }

        ///////////////////////////////////////////////////////////////////
        /// DETAILS
        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = categoriesDAO.getRow(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        ///////////////////////////////////////////////////////////////////
        /// CREATE
        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(categoriesDAO.getList("Index"),"Id","Name");
            ViewBag.ListOrder = new SelectList(categoriesDAO.getList("Index"), "Order", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories categories)
        {
            if (ModelState.IsValid)
            {
                //Xu ly tu dong cho: CreateAt
                categories.CreateAt = DateTime.Now;

                //Xu ly tu dong cho: UpdateAt
                categories.UpdateAt = DateTime.Now;

                //Xu ly tu dong cho: ParentId
                if (categories.ParentID == null)
                {
                    categories.ParentID = 0;
                }

                //Xu ly tu dong cho: Order
                if (categories.Order == null)
                {
                    categories.Order = 1;
                }
                else
                {
                    categories.Order += 1;
                }

                //Xu ly tu dong cho: Slug
                categories.Slug = XString.Str_Slug(categories.Name);

                //them dong du lieu cho DB
                categoriesDAO.Insert(categories);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(categoriesDAO.getList("Index"), "Id", "Name");
            ViewBag.ListOrder = new SelectList(categoriesDAO.getList("Index"), "Order", "Name");
            return View(categories);
        }

        ///////////////////////////////////////////////////////////////////
        /// EDIT
        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //tim dong DB can chinh sua
            Categories categories = categoriesDAO.getRow(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                categoriesDAO.Update(categories);
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        ///////////////////////////////////////////////////////////////////
        /// DELETE
        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = categoriesDAO.getRow(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories categories = categoriesDAO.getRow(id);
            categoriesDAO.Delete(categories);
            return RedirectToAction("Index");
        }

        ///////////////////////////////////////////////////////////////////
        /// STATUS
        // GET: Admin/Category/Status/5
        public ActionResult Status(int? id)
        {
            if (id==null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger","Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }

            //tim row co id == id cua loai SP can thay doi Status
            Categories categories = categoriesDAO.getRow(id);
            if (categories==null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger","Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            //kiem tra trang thai cua status, neu hien tai la 1 ->2 va nguoc lai
            categories.Status = (categories.Status == 1) ? 2 : 1;
            //cap nhat gia tri cho UpdateAt
            categories.UpdateAt = DateTime.Now;
            //cap nhat lai DB
            categoriesDAO.Update(categories);
            //thong bao thanh cong
            TempData["message"] = new XMessage("success","Cập nhật trạng thái thành công");
            //tra ket qua ve Index
            return RedirectToAction("Index");
        }
    }
}
