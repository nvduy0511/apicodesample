using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class LyThuyet
    {
        public LyThuyet()
        {
            DaHocs = new HashSet<DaHoc>();
        }

        public int Id { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public int IdMonHoc { get; set; }

        public virtual MonHoc IdMonHocNavigation { get; set; }
        public virtual ICollection<DaHoc> DaHocs { get; set; }
    }
}
