﻿using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        //Tim kiem 1 mau tin
        public Categories getRow(int? id)
        {
            if (id==null)
            {
                return null;
            }
            else
            {
                return db.Categories.Find(id);
            }
        }

        //Update DB
        public int Update(Categories row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }

        //Delete DB
        public int Delete(Categories row)
        {
            db.Categories.Remove(row);
            return db.SaveChanges();
        }

    }
}
