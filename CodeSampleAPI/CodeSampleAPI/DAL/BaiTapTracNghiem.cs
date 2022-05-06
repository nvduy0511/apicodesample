using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.DAL
{
    public partial class BaiTapTracNghiem
    {
        public BaiTapTracNghiem()
        {
            CtDeKiemTraTracNghiems = new HashSet<CtDeKiemTraTracNghiem>();
        }

        public int Id { get; set; }
        public string CauHoi { get; set; }
        public string CauTraLoi1 { get; set; }
        public string CauTraLoi2 { get; set; }
        public string CauTraLoi3 { get; set; }
        public string CauTraLoi4 { get; set; }
        public int DapAn { get; set; }
        public string UIdNguoiTao { get; set; }

        public virtual GiangVien UIdNguoiTaoNavigation { get; set; }
        public virtual ICollection<CtDeKiemTraTracNghiem> CtDeKiemTraTracNghiems { get; set; }
    }
}
