using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccessControlweb.Models; /*使用此空間資料*/

namespace AccessControlweb.Controllers
{
    public class HomeController : Controller
    {
        dbcompanyEntities db = new dbcompanyEntities();
       
        public ActionResult Index( )
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(dbcompany com)
        {
            if (ModelState.IsValid)
            {
                db.dbcompany.Add(com);  //增加一筆新資料
                db.SaveChanges();       //儲存轉換新資料
                return RedirectToAction("Index");
            }
            return View("com");
        }

        //SQL編輯法有誤//public ActionResult Index(Company company)
        //{
        //    string msg = "";

        //    msg = "註冊資料如下:<br>" +
        //        "工號:" + company.UserId + "<br>" +
        //        "部門:" + company.Department + "<br>" +
        //        "卡號:" + company.CardFrm + "<br>" +
        //        "日期:" + company.Day+"<br>" +
        //        "權限呈現:" + company.AddPower + "<br>";
        //    ViewBag.Msg = msg; /*儲存在ViewBag，ViewBag.屬性 = 屬性值; 為動態轉換，省工動作較慢，保留前次資料*/
        //                       /*可在要展示的view使用<p>@Html.Raw(@viewBag.Msg)做顯示</p>*/
        //    return View(company); /* 要回傳給視窗，不然會錯誤，出現空的參數回傳，還是沒資料*/
        //}

       
        public ActionResult Edit(string userId)
        {
            //ViewBag.Message = "卡片資料修改";
            var EditCompany = db.dbcompany
                                .Where(m => m.UserId == userId)
                                .FirstOrDefault();
            return View(EditCompany);
        }
        [HttpPost]
        public ActionResult Edit
            (string CardFam, string Department, string Name, string Ambit, string UserId)
        {
            var company1 = db.dbcompany.Where(m => m.UserId == UserId).FirstOrDefault();
            //dbcompany com1 = new dbcompany(); // 創建 dbcompany 的物件實例
            if (company1 != null)
            {
                company1.CardFrm = CardFam; // 設置 CardFrm 屬性的值
                company1.Department = Department;
                company1.Name = Name;
                company1.Ambit = Ambit;
                db.SaveChanges();
                
            }
            //return RedirectToAction("Index");
            return View(company1);

        }
        
        public ActionResult Check()
        {
            ViewBag.Message = "查詢";

            return ViewBag("Index");
        }

        //，只有建立檢視，沒有在layout那邊超連結
        public ActionResult CherkCompany(string userId)
        {
            var CherkCompany = db.dbcompany.Where(m => m.UserId == userId).FirstOrDefault();
            //if (CherkCompany != null)
            //{
            //    return View(CherkCompany);
            //}
            //else
            //{
            //    // 處理找不到符合的資料的情況，例如顯示錯誤訊息或重定向到其他頁面
            //    return RedirectToAction("Index");
            //}
            return View(CherkCompany);
        }

    }
}