using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class CtLuyenTap
    {
        public string UIdNguoiDung { get; set; }
        public int IdBaiTap { get; set; }
        public bool? TrangThai { get; set; }
        public string Code { get; set; }

        public virtual BaiTapCode IdBaiTapNavigation { get; set; }
        public virtual NguoiDung UIdNguoiDungNavigation { get; set; }
    }
}
