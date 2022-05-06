using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.DAL
{
    public partial class DaHoc
    {
        public int IdLyThuyet { get; set; }
        public string UIdNguoiDung { get; set; }

        public virtual LyThuyet IdLyThuyetNavigation { get; set; }
        public virtual NguoiDung UIdNguoiDungNavigation { get; set; }
    }
}
