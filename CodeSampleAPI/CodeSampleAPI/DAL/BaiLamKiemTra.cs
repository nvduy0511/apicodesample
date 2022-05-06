using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.DAL
{
    public partial class BaiLamKiemTra
    {
        public BaiLamKiemTra()
        {
            CtBaiLamCodes = new HashSet<CtBaiLamCode>();
            CtBaiLamTracNghiems = new HashSet<CtBaiLamTracNghiem>();
        }

        public int Id { get; set; }
        public double? TongDiem { get; set; }
        public DateTime? NgayNopBai { get; set; }
        public string UIdNguoiDung { get; set; }
        public int? IdDeKiemTra { get; set; }

        public virtual DeKiemTra IdDeKiemTraNavigation { get; set; }
        public virtual NguoiDung UIdNguoiDungNavigation { get; set; }
        public virtual ICollection<CtBaiLamCode> CtBaiLamCodes { get; set; }
        public virtual ICollection<CtBaiLamTracNghiem> CtBaiLamTracNghiems { get; set; }
    }
}
