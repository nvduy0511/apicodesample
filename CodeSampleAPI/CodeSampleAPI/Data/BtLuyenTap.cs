using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class BtLuyenTap
    {
        public BtLuyenTap()
        {
            CtLuyenTaps = new HashSet<CtLuyenTap>();
            TestCaseLuyenTaps = new HashSet<TestCaseLuyenTap>();
        }

        public int Id { get; set; }
        public int DoKho { get; set; }
        public string TieuDe { get; set; }
        public string DeBai { get; set; }
        public string UIdNguoiTao { get; set; }
        public string RangBuoc { get; set; }
        public string DinhDangDauVao { get; set; }
        public string DinhDangDauRa { get; set; }
        public string MauDauVao { get; set; }
        public string MauDauRa { get; set; }
        public string Tag { get; set; }
        public int? SoNguoiLam { get; set; }
        public int? SoNguoiThanhCong { get; set; }

        public virtual GiangVien UIdNguoiTaoNavigation { get; set; }
        public virtual ICollection<CtLuyenTap> CtLuyenTaps { get; set; }
        public virtual ICollection<TestCaseLuyenTap> TestCaseLuyenTaps { get; set; }
    }
}
