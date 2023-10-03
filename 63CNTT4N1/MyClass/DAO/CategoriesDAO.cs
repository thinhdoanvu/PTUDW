using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;

namespace MyClass.DAO
{
    
    public class CategoriesDAO
    {
        private MyDBContext db = new MyDBContext();

        //INDEX
        public List<Categories> getList()
        {
            return db.Categories.ToList();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach theo trang thai
        public List<Categories> getList(string status = "All")
        {
            List<Categories> list = null;
            switch (status)
            {
                case "Index"://status == 1,2
                    {
                        list = db.Categories
                        .Where(m => m.Status != 0)
                        .ToList();
                        break;
                    }
                case "Trash"://status == 0
                    {
                        list = db.Categories
                        .Where(m => m.Status == 0)
                        .ToList();
                        break;
                    }
                default:
                    {
                        list = db.Categories.ToList();
                        break;
                    }
            }
            return list;
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //Hien thi danh sach 1 mau tin (ban ghi)
        public Categories getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Categories.Find(id);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Them moi mot mau tin
        public int Insert(Categories row)
        {
            db.Categories.Add(row);
            return db.SaveChanges();
        }

        /////////////////////////////////////////////////////////////////////////////////////
        ///Cap nhat mot mau tin
        public int Update(Categories row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }

    }
}
