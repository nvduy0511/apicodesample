using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            BaiLamKiemTras = new HashSet<BaiLamKiemTra>();
            CtLuyenTaps = new HashSet<CtLuyenTap>();
            CtPhongHocs = new HashSet<CtPhongHoc>();
            DaHocs = new HashSet<DaHoc>();
        }

        public string UId { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public DateTime NamSinh { get; set; }
        public string Truong { get; set; }

        public virtual ICollection<BaiLamKiemTra> BaiLamKiemTras { get; set; }
        public virtual ICollection<CtLuyenTap> CtLuyenTaps { get; set; }
        public virtual ICollection<CtPhongHoc> CtPhongHocs { get; set; }
        public virtual ICollection<DaHoc> DaHocs { get; set; }
    }
}
