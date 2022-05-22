using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Model
{
    public class DeKiemTra_Custom
    {
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayKetThuc { get; set; }
        public string moTa { get; set; }
        public int idPhong { get; set; }
        public int trangThai { get; set; }
        public List<CauHoi> listCauHoi { get; set; }
    }
}
