using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class CtDeKiemTraTracNghiem
    {
        public CtDeKiemTraTracNghiem()
        {
            CtBaiLamTracNghiems = new HashSet<CtBaiLamTracNghiem>();
        }

        public int IdDeKiemTra { get; set; }
        public int IdBaiTapTracNghiem { get; set; }
        public int? SttCauHoi { get; set; }
        public double? Diem { get; set; }

        public virtual BaiTapTracNghiem IdBaiTapTracNghiemNavigation { get; set; }
        public virtual DeKiemTra IdDeKiemTraNavigation { get; set; }
        public virtual ICollection<CtBaiLamTracNghiem> CtBaiLamTracNghiems { get; set; }
    }
}
