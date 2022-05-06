using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.DAL
{
    public partial class CtBaiLamTracNghiem
    {
        public int IdBaiLamKt { get; set; }
        public int IdDeKiemTra { get; set; }
        public int IdBaiTapTracNghiem { get; set; }
        public int DapAn { get; set; }
        public double Diem { get; set; }

        public virtual CtDeKiemTraTracNghiem Id { get; set; }
        public virtual BaiLamKiemTra IdBaiLamKtNavigation { get; set; }
    }
}
