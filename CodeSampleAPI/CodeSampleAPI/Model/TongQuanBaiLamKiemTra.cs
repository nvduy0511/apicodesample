using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Model
{
    public class TongQuanBaiLamKiemTra
    {
        public int id { get; set; }
        public string uid { get; set; }
        public int idBaiLam { get; set; }
        public string hoTen { get; set; }
        public string tenHienThi { get; set; }
        public DateTime? thoiGianNop { get; set; }
        public double? diem { get; set; }
    }
}
