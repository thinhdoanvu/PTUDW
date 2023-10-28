using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;
using MyClass.DAO;
using UDW.Library;
using System.IO;

namespace _63CNTT5N1.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        SuppliersDAO suppliersDAO = new SuppliersDAO();

        //////////////////////////////////////////////////////////////////////////////////////
        // GET: Admin/Supplier
        public ActionResult Index()
        {
            return View(suppliersDAO.getList("Index"));
        }

        //////////////////////////////////////////////////////////////////////////////////////
        // GET: Admin/Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
                return RedirectToAction("Index");
            }
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
            }
            return View(suppliers);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        // GET: Admin/Supplier/Create
        public ActionResult Create()
        {
            ViewBag.ListOrder = new SelectList(suppliersDAO.getList("Index"), "Order", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                //xu ly tu dong cho cac truong: Slug, CreateAt/By, UpdateAt/By, Oder
                //Xu ly tu dong: CreateAt
                suppliers.CreateAt = DateTime.Now;
                //Xu ly tu dong: UpdateAt
                suppliers.UpdateAt = DateTime.Now;
                //Xu ly tu dong: CreateBy
                suppliers.CreateBy = Convert.ToInt32(Session["UserId"]);
                //Xu ly tu dong: UpdateBy
                suppliers.UpdateBy = Convert.ToInt32(Session["UserId"]);
                //Xu ly tu dong: Order
                if (suppliers.Order == null)
                {
                    suppliers.Order = 1;
                }
                else
                {
                    suppliers.Order += 1;
                }
                //Xu ly tu dong: Slug
                suppliers.Slug = XString.Str_Slug(suppliers.Name);

                //xu ly cho phan upload hinh anh
                var img = Request.Files["img"];//lay thong tin file
                if (img.ContentLength != 0)
                {
                    string[] FileExtentions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    //kiem tra tap tin co hay khong
                    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))//lay phan mo rong cua tap tin
                    {
                        string slug = suppliers.Slug;
                        //ten file = Slug + phan mo rong cua tap tin
                        string imgName = slug + suppliers.Id + img.FileName.Substring(img.FileName.LastIndexOf("."));
                        suppliers.Image = imgName;
                        //upload hinh
                        string PathDir = "~/Public/img/supplier";
                        string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                        img.SaveAs(PathFile);
                    }
                }//ket thuc phan upload hinh anh

                //chen mau tin vao DB
                suppliersDAO.Insert(suppliers);
                //thong bao tao mau tin thanh cong
                TempData["message"] = new XMessage("success", "Tạo mới nhà cung cấp thành công");
                return RedirectToAction("Index");
            }
            ViewBag.ListOrder = new SelectList(suppliersDAO.getList("Index"), "Order", "Name");
            return View(suppliers);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        // GET: Admin/Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
                return RedirectToAction("Index");
            }
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
                return RedirectToAction("Index");
            }
            ViewBag.ListOrder = new SelectList(suppliersDAO.getList("Index"), "Order", "Name");
            return View(suppliers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                //xu ly tu dong cho cac truong: Slug, CreateAt/By, UpdateAt/By, Oder
                //Xu ly tu dong: UpdateAt
                suppliers.UpdateAt = DateTime.Now;
                //Xu ly tu dong: Order
                if (suppliers.Order == null)
                {
                    suppliers.Order = 1;
                }
                else
                {
                    suppliers.Order += 1;
                }
                //Xu ly tu dong: Slug
                suppliers.Slug = XString.Str_Slug(suppliers.Name);

                //xu ly cho phan upload hinh anh
                var img = Request.Files["img"];//lay thong tin file
                string PathDir = "~/Public/img/supplier";
                if (img.ContentLength != 0)
                {
                    //Xu ly cho muc xoa hinh anh
                    if (suppliers.Image != null)
                    {
                        string DelPath = Path.Combine(Server.MapPath(PathDir), suppliers.Image);
                        System.IO.File.Delete(DelPath);
                    }

                    string[] FileExtentions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    //kiem tra tap tin co hay khong
                    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))//lay phan mo rong cua tap tin
                    {
                        string slug = suppliers.Slug;
                        //ten file = Slug + phan mo rong cua tap tin
                        string imgName = slug + suppliers.Id + img.FileName.Substring(img.FileName.LastIndexOf("."));
                        suppliers.Image = imgName;
                        //upload hinh
                        string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                        img.SaveAs(PathFile);
                    }
                    
                }//ket thuc phan upload hinh anh

                //cap nhat mau tin vao DB
                suppliersDAO.Update(suppliers);
                //thong bao tao mau tin thanh cong
                TempData["message"] = new XMessage("success", "Cập nhật nhà cung cấp thành công");
                return RedirectToAction("Index");
            }
            ViewBag.ListOrder = new SelectList(suppliersDAO.getList("Index"), "Order", "Name");
            return View(suppliers);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        // GET: Admin/Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
            }
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
            }
            return View(suppliers);
        }

        // POST: Admin/Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suppliers suppliers = suppliersDAO.getRow(id);
            //xoa mau tin ra khoi DB
            suppliersDAO.Delete(suppliers);
            //thong bao xoa mau tin thanh cong
            TempData["message"] = new XMessage("success", "Xóa nhà cung cấp thành công");
            return RedirectToAction("Index");
        }
        //phat sinh them 1 so action: Status, Trash, DelTrash, Undo: Copy tu Category Controller
        //////////////////////////////////////////////////////////////////////////////////////
        //STATUS
        // GET: Admin/Supplier/Status/5
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            //truy van dong co id = id yeu cau
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            else
            {
                //chuyen doi trang thai cua Satus tu 1<->2
                suppliers.Status = (suppliers.Status == 1) ? 2 : 1;

                //cap nhat gia tri UpdateAt
                suppliers.UpdateAt = DateTime.Now;

                //cap nhat lai DB
                suppliersDAO.Update(suppliers);

                //thong bao cap nhat trang thai thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Cập nhật trạng thái thành công");

                return RedirectToAction("Index");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //DELTRAH
        // GET: Admin/Supplier/DelTrash/5
        public ActionResult DelTrash(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tìm thấy mẩu tin");
                return RedirectToAction("Index");
            }
            //truy van dong co id = id yeu cau
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tìm thấy mẩu tin");
                return RedirectToAction("Index");
            }
            else
            {
                //chuyen doi trang thai cua Satus tu 1,2 -> 0: Không hiển thị ở Index
                suppliers.Status = 0;

                //cap nhat gia tri UpdateAt
                suppliers.UpdateAt = DateTime.Now;

                //cap nhat lai DB
                suppliersDAO.Update(suppliers);

                //thong bao cap nhat trang thai thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Xóa mẩu tin thành công");

                return RedirectToAction("Index");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //TRASH
        // GET: Admin/Supplier/Trash
        public ActionResult Trash()
        {
            return View(suppliersDAO.getList("Trash"));
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //RECOVER
        // GET: Admin/Supplier/Recover/5
        public ActionResult Recover(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Phục hồi mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            //truy van dong co id = id yeu cau
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Phục hồi mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            else
            {
                //chuyen doi trang thai cua Satus tu 0 -> 2: Khong xuat ban
                suppliers.Status = 2;

                //cap nhat gia tri UpdateAt
                suppliers.UpdateAt = DateTime.Now;

                //cap nhat lai DB
                suppliersDAO.Update(suppliers);

                //thong bao phuc hoi du lieu thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Phục hồi mẩu tin thành công");

                return RedirectToAction("Index");
            }
        }
    }
}
