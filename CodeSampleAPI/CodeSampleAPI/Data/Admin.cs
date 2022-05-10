using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class Admin
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string IdGiangVien { get; set; }

        public virtual GiangVien IdGiangVienNavigation { get; set; }
    }
}
