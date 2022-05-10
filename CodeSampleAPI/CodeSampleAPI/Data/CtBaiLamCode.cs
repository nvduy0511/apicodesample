using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class CtBaiLamCode
    {
        public int IdBaiLamKt { get; set; }
        public int IdDeKiemTra { get; set; }
        public int IdBaiTapCode { get; set; }
        public string Code { get; set; }
        public double Diem { get; set; }

        public virtual CtDeKiemTraCode Id { get; set; }
        public virtual BaiLamKiemTra IdBaiLamKtNavigation { get; set; }
    }
}
