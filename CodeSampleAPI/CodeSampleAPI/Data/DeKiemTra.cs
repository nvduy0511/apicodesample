using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class DeKiemTra
    {
        public DeKiemTra()
        {
            BaiLamKiemTras = new HashSet<BaiLamKiemTra>();
            CtDeKiemTraCodes = new HashSet<CtDeKiemTraCode>();
            CtDeKiemTraTracNghiems = new HashSet<CtDeKiemTraTracNghiem>();
        }

        public int Id { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int IdPhong { get; set; }

        public virtual PhongHoc IdPhongNavigation { get; set; }
        public virtual ICollection<BaiLamKiemTra> BaiLamKiemTras { get; set; }
        public virtual ICollection<CtDeKiemTraCode> CtDeKiemTraCodes { get; set; }
        public virtual ICollection<CtDeKiemTraTracNghiem> CtDeKiemTraTracNghiems { get; set; }
    }
}
