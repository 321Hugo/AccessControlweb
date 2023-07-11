using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace AccessControlweb.Models
{
    public class Company
    {
        [DisplayName("工號")]
        public string UserId { get; set; } //工號
        public string CardFrm { get; set; } //卡號
        public string Department { get; set; } //公司部門
        //public List<string> DepartmentList { get; set; }//公司部門 還在研究
        public string Name { get; set; } //員工名稱
        public DateTime Day { get; set; } //申請日期
        public string Ambit { get; set; } //可進入範圍
        public List<string> RemovePower { get; set; }
        public List<string> AddPower { get; set; }
        public List<dbcompany> company { get; set; } //直接列表儲取
    }
}