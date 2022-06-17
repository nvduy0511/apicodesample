using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Model
{
    public class BaiTapCode_Custom
    {
        public int Id { get; set; }
        public string TieuDe { get; set; }
        public string DeBai { get; set; }
        public string UIdNguoiTao { get; set; }
        public string NgonNgu { get; set; }
        public string RangBuoc { get; set; }
        public string DinhDangDauVao { get; set; }
        public string DinhDangDauRa { get; set; }
        public string MauDauVao { get; set; }
        public string MauDauRa { get; set; }
        public List<TestCase_Custom> testCases { get; set; }
    }
}
