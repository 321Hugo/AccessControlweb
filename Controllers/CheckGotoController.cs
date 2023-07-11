using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccessControlweb.Models;
using ClosedXML.Excel;
using System.IO;


namespace AccessControlweb.Controllers
{
    public class CheckGotoController : Controller

    {
        dbcompanyEntities db = new dbcompanyEntities();
        // GET: CheckGoto
        public ActionResult 勞工代號(string userId)
        {
            //List<dbcompany> list = new List<dbcompany>();
            var migrantuserId = db.dbcompany.Where(m => m.UserId==userId).FirstOrDefault();
            return View(migrantuserId);
            
        }
        // GET: CheckGoto
        
        public ActionResult 員工與卡號查詢(string userId, string cardFrm) 
        {
            var CheckUser = db.dbcompany.Where(m => m.UserId == userId).FirstOrDefault();
            var CheckCard = db.dbcompany.Where(m => m.CardFrm == cardFrm).FirstOrDefault();
            if (CheckUser != null)
            {
                return View(CheckUser);
            }
            else if (CheckCard != null)
            {
                return View(CheckCard);
            }
            return View("員工與卡號查詢");
        }
        // GET: CheckGoto
        public ActionResult 已發放卡片()
        {
            var card = db.dbcompany.OrderBy(m => m.UserId).ToList();
            return View(card); }
     
        public ActionResult 匯出EXCEL() {
            var card = db.dbcompany.OrderBy(m => m.UserId).ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("已發放卡片");

                // 在工作表中填入資料
                // ...

                using (var memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    memoryStream.Position = 0;

                    return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "已發放卡片.xlsx");
                }
            }
        }
    

    }

}

    