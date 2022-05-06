using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.DAL
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            LyThuyets = new HashSet<LyThuyet>();
        }

        public int Id { get; set; }
        public string TenMonHoc { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<LyThuyet> LyThuyets { get; set; }
    }
}
