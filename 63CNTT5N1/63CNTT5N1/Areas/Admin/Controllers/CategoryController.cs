using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Model;
using UDW.Library;

namespace _63CNTT5N1.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesDAO categoriesDAO = new CategoriesDAO();
        
        //////////////////////////////////////////////////////////////////////////////////////
        //INDEX
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(categoriesDAO.getList("Index"));
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //DETAILS
        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại loại sản phẩm");
                return RedirectToAction("Index");
            }
            Categories categories = categoriesDAO.getRow(id);
            if (categories == null)
            {
                TempData["message"] = new XMessage("danger", "Không tồn tại loại sản phẩm");
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //CREATE
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
                //Xu ly tu dong: CreateAt
                categories.CreateAt = DateTime.Now;
                //Xu ly tu dong: UpdateAt
                categories.UpdateAt = DateTime.Now;
                //Xu ly tu dong: ParentId
                if (categories.ParentID==null)
                {
                    categories.ParentID = 0;
                }
                //Xu ly tu dong: Order
                if (categories.Order == null)
                {
                    categories.Order = 1;
                }
                else
                {
                    categories.Order += 1;
                }
                //Xu ly tu dong: Slug
                categories.Slug = XString.Str_Slug(categories.Name);

                //Chen them dong cho DB
                categoriesDAO.Insert(categories);
                //thong bao cap nhat trang thai thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Tạo mới loại sản phẩm thành công");
                //tro ve trang index
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(categoriesDAO.getList("Index"), "Id", "Name");
            ViewBag.ListOrder = new SelectList(categoriesDAO.getList("Index"), "Order", "Name");
            return View(categories);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //EDIT
        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = TempData["message"] = new XMessage("danger", "Không tìm thấy mẩu tin");
                return RedirectToAction("Index");
            }
            Categories categories = categoriesDAO.getRow(id);
            if (categories == null)
            {
                //thong bao that bai
                TempData["message"] = TempData["message"] = new XMessage("danger", "Không tìm thấy mẩu tin");
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(categoriesDAO.getList("Index"), "Id", "Name");
            ViewBag.ListOrder = new SelectList(categoriesDAO.getList("Index"), "Order", "Name");
            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                //xu ly tu dong: Slug
                categories.Slug = XString.Str_Slug(categories.Name);
                //xu ly tu dong: ParentID
                if(categories.ParentID == null)
                {
                    categories.ParentID = 0;
                }
                //xu ly tu dong: Order
                if(categories.Order == null){
                    categories.Order = 1;
                }
                else
                {
                    categories.Order += 1;
                }
                //xu ly tu dong: UpdateAt
                categories.UpdateAt = DateTime.Now;

                //cap nhat mau tin
                categoriesDAO.Update(categories);

                //thong bao thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Cập nhật mẩu tin thành công");
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(categoriesDAO.getList("Index"), "Id", "Name");
            ViewBag.ListOrder = new SelectList(categoriesDAO.getList("Index"), "Order", "Name");
            return View(categories);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //DELETE
        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Xóa mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            Categories categories = categoriesDAO.getRow(id);
            if (categories == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Xóa mẩu tin thất bại");
                return RedirectToAction("Index");
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

            //thong bao thanh cong
            TempData["message"] = new XMessage("success", "Xóa mẩu tin thành công");
            return RedirectToAction("Trash");
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //STATUS
        // GET: Admin/Category/Status/5
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            //truy van dong co id = id yeu cau
            Categories categories = categoriesDAO.getRow(id);
            if (categories == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            else
            {
                //chuyen doi trang thai cua Satus tu 1<->2
                categories.Status = (categories.Status == 1) ? 2 : 1;

                //cap nhat gia tri UpdateAt
                categories.UpdateAt = DateTime.Now;

                //cap nhat lai DB
                categoriesDAO.Update(categories);

                //thong bao cap nhat trang thai thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Cập nhật trạng thái thành công");

                return RedirectToAction("Index");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //DELTRAH
        // GET: Admin/Category/DelTrash/5
        public ActionResult DelTrash(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tìm thấy mẩu tin");
                return RedirectToAction("Index");
            }
            //truy van dong co id = id yeu cau
            Categories categories = categoriesDAO.getRow(id);
            if (categories == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tìm thấy mẩu tin");
                return RedirectToAction("Index");
            }
            else
            {
                //chuyen doi trang thai cua Satus tu 1,2 -> 0: Không hiển thị ở Index
                categories.Status = 0;

                //cap nhat gia tri UpdateAt
                categories.UpdateAt = DateTime.Now;

                //cap nhat lai DB
                categoriesDAO.Update(categories);

                //thong bao cap nhat trang thai thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Xóa mẩu tin thành công");

                return RedirectToAction("Index");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //TRASH
        // GET: Admin/Category/Trash
        public ActionResult Trash()
        {
            return View(categoriesDAO.getList("Trash"));
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //RECOVER
        // GET: Admin/Category/Recover/5
        public ActionResult Recover(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Phục hồi mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            //truy van dong co id = id yeu cau
            Categories categories = categoriesDAO.getRow(id);
            if (categories == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Phục hồi mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            else
            {
                //chuyen doi trang thai cua Satus tu 0 -> 2: Khong xuat ban
                categories.Status = 2;

                //cap nhat gia tri UpdateAt
                categories.UpdateAt = DateTime.Now;

                //cap nhat lai DB
                categoriesDAO.Update(categories);

                //thong bao phuc hoi du lieu thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Phục hồi mẩu tin thành công");

                return RedirectToAction("Index");
            }
        }
    }
}
