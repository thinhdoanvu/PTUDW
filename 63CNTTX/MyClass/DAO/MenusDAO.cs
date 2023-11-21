using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class MenusDAO
    {
        private MyDBContext db = new MyDBContext();

        //SELECT * FROM ...
        public List<Menus> getList()
        {
            return db.Menus.ToList();
        }

        public List<Menus> getListByParentId(int parentid=0)
        {
            return db.Menus
                .Where(m => m.ParentID == parentid && m.Status ==1)
                .ToList();
        }

        //Index chi voi staus 1,2        
        public List<Menus> getList(string status = "ALL")//status 0,1,2
        {
            List<Menus> list = null;
            switch (status)
            {
                case "Index"://1,2
                    {
                        list = db.Menus.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash"://0
                    {
                        list = db.Menus.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Menus.ToList();
                        break;
                    }
            }
            return list;
        }
        //details
        public Menus getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Menus.Find(id);
            }
        }

        //tao moi mau tin
        public int Insert(Menus row)
        {
            db.Menus.Add(row);
            return db.SaveChanges();
        }

        //cap nhat mau tin
        public int Update(Menus row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }

        //Xoa mau tin
        public int Delete(Menus row)
        {
            db.Menus.Remove(row);
            return db.SaveChanges();
        }
    }
}
