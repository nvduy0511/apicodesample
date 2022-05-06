using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.DAL
{
    public partial class BaiTapCode
    {
        public BaiTapCode()
        {
            CtDeKiemTraCodes = new HashSet<CtDeKiemTraCode>();
            CtLuyenTaps = new HashSet<CtLuyenTap>();
            TestCases = new HashSet<TestCase>();
        }

        public int Id { get; set; }
        public string DoKho { get; set; }
        public string TieuDe { get; set; }
        public string DeBai { get; set; }
        public bool IsPublic { get; set; }
        public string UIdNguoiTao { get; set; }

        public virtual GiangVien UIdNguoiTaoNavigation { get; set; }
        public virtual ICollection<CtDeKiemTraCode> CtDeKiemTraCodes { get; set; }
        public virtual ICollection<CtLuyenTap> CtLuyenTaps { get; set; }
        public virtual ICollection<TestCase> TestCases { get; set; }
    }
}
