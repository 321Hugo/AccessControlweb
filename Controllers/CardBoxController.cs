using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccessControlweb.Models;

namespace AccessControlweb.Controllers
{

    public class CardBoxController : Controller
    {
        dbcompanyEntities db = new dbcompanyEntities();
        // GET: CardBox

        public ActionResult CardRecycle()
        {
            var cardBox = db.CardBox.OrderByDescending(m => m.Id).ToList();
            //LINQ運算式寫法"遞減"，讓資料新的在最上面，寫用項目list展示
            return View(cardBox); //回傳到顯示頁面
        }

        public ActionResult CardBoxEdit(/*int id,*/ string cardId)
        {
            var cardBox = db.CardBox.OrderByDescending(m => m.CardId == cardId).FirstOrDefault();
            //var cardBox = db.CardBox.OrderByDescending(m => m.Id== id).FirstOrDefault();
            return View(cardBox);
        }
        [HttpPost]
        public ActionResult CardBoxEdit(int Id,string CardId, string Day, string RecDay)
        {
            var cardBox = db.CardBox.OrderByDescending(m => m.CardId == CardId).FirstOrDefault();
            //var cardBox = db.CardBox.OrderByDescending(m => m.Id==Id).FirstOrDefault();
            cardBox.Day = Day;
            cardBox.RecDay = RecDay;
            db.SaveChanges();
            return RedirectToAction("CardRecycle");
        }
        public ActionResult Amount()
        {
            var cards = db.CardBox.ToList(); // 從資料庫取得卡的列表

            int totalCards = cards.Count; // 總卡數

            int usedCards = cards.Count(m => m.Day != null); // 使用的卡數 (day 不為 null)

            int unusedCards = cards.Count(m => m.RecDay != null); // 未使用的卡數 (recday 不為 null)

            // 將計算結果傳遞到視圖
            ViewBag.TotalCards = totalCards;
            ViewBag.UsedCards = usedCards;
            ViewBag.UnusedCards = unusedCards;

            return View();
        }


    }
}