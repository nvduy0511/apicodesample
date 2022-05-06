using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.DAL
{
    public partial class PhongHoc
    {
        public PhongHoc()
        {
            CtPhongHocs = new HashSet<CtPhongHoc>();
            DeKiemTras = new HashSet<DeKiemTra>();
        }

        public int Id { get; set; }
        public string TenPhong { get; set; }
        public string IdChuPhong { get; set; }

        public virtual GiangVien IdChuPhongNavigation { get; set; }
        public virtual ICollection<CtPhongHoc> CtPhongHocs { get; set; }
        public virtual ICollection<DeKiemTra> DeKiemTras { get; set; }
    }
}
