using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;

namespace MyClass.DAO
{
    public class SuppliersDAO
    {
        //Copy noi dung cua class CATEGORIES, thay the Categories bang Suppliers
        private MyDBContext db = new MyDBContext();

        //SELECT * FROM ...
        public List<Suppliers> getList()
        {
            return db.Suppliers.ToList();
        }

        //Index chi voi staus 1,2        
        public List<Suppliers> getList(string status = "ALL")//status 0,1,2
        {
            List<Suppliers> list = null;
            switch (status)
            {
                case "Index"://1,2
                    {
                        list = db.Suppliers.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash"://0
                    {
                        list = db.Suppliers.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Suppliers.ToList();
                        break;
                    }
            }
            return list;
        }
        //details
        public Suppliers getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Suppliers.Find(id);
            }
        }

        //tao moi mau tin
        public int Insert(Suppliers row)
        {
            db.Suppliers.Add(row);
            return db.SaveChanges();
        }

        //cap nhat mau tin
        public int Update(Suppliers row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }

        //Xoa mau tin
        public int Delete(Suppliers row)
        {
            db.Suppliers.Remove(row);
            return db.SaveChanges();
        }
    }
}
