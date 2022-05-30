using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class CtPhongHoc
    {
        public string UIdNguoiDung { get; set; }
        public string IdPhongHoc { get; set; }
        public DateTime? NgayThamGia { get; set; }

        public virtual PhongHoc IdPhongHocNavigation { get; set; }
        public virtual NguoiDung UIdNguoiDungNavigation { get; set; }
    }
}
