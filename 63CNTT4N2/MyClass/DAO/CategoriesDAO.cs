using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class CategoriesDAO
    {
        private MyDBContext db = new MyDBContext();

        //INDEX = SELECT * FROM
        public List<Categories> getList()
        {
            return db.Categories.ToList();
        }
        //INDEX -  tra ve cac gia tri co status =1,2, status =0 <=> thung rac
        public List<Categories> getList(string status = "All")//Status 1,2: hien thi; 0 an di
        {
            List<Categories> list = null;
            switch (status)
            {
                case "Index":   //satus = 1,2
                    {
                        list = db.Categories.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash": //status = 0
                {
                        list = db.Categories.Where(m => m.Status == 0).ToList();
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

        //CREATE
        public int Insert(Categories row)
        {
            db.Categories.Add(row);
            return db.SaveChanges();
        }

    }
}
