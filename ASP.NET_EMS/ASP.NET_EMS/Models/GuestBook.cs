using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ASP.NET_EMS.Models
{
    public class GuestBook
    {
        [DisplayName("用户编号")]
        public int Id { get; set; }
        [DisplayName("姓名")]
        public string Name { get; set; }
        [DisplayName("内容")]
        public string Detail { get;set; }
    }
}