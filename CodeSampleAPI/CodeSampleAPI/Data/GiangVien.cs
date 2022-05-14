using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class GiangVien
    {
        public GiangVien()
        {
            BaiTapCodes = new HashSet<BaiTapCode>();
            BaiTapTracNghiems = new HashSet<BaiTapTracNghiem>();
        }

        public string UId { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public DateTime NamSinh { get; set; }
        public string Truong { get; set; }

        public virtual ICollection<BaiTapCode> BaiTapCodes { get; set; }
        public virtual ICollection<BaiTapTracNghiem> BaiTapTracNghiems { get; set; }
    }
}
