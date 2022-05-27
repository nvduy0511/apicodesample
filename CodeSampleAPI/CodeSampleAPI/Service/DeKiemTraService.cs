using CodeSampleAPI.Data;
using CodeSampleAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IDeKiemTraService
    {
        List<DeKiemTra> getDeKiemTraByIdPhong(int id);
        
        bool addDeKiemTra(DeKiemTra_Custom deKiemTra);

        DeKiemTra_Custom getDeKiemTraByID(int id);
    }
    public class DeKiemTraService : IDeKiemTraService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public DeKiemTraService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }


        public List<DeKiemTra> getDeKiemTraByIdPhong(int id)
        {
            return _codeSampleContext.DeKiemTras.Where(p => p.IdPhong == id).ToList();
        }
        public bool addDeKiemTra(DeKiemTra_Custom deKiemTra_cus)
        {
            DeKiemTra deKiemTra = new DeKiemTra() 
            {
                MoTa = deKiemTra_cus.moTa,
                NgayBatDau = deKiemTra_cus.ngayBatDau,
                NgayKetThuc = deKiemTra_cus.ngayKetThuc,
                TrangThai = deKiemTra_cus.trangThai,
                IdPhong = deKiemTra_cus.idPhong
            };
            try
            {
                _codeSampleContext.DeKiemTras.Add(deKiemTra);
                _codeSampleContext.SaveChanges();
                foreach(var item in deKiemTra_cus.listCauHoi)
                {
                    if(item.loaiCauHoi == 0)
                    {
                        // thêm ct đề kiểm tra trắc nghiệm
                        CtDeKiemTraTracNghiem ctTN = new CtDeKiemTraTracNghiem()
                        {
                            IdDeKiemTra = deKiemTra.Id,
                            IdBaiTapTracNghiem = item.id,
                            SttCauHoi = item.stt,
                            Diem = item.diem
                        };
                        _codeSampleContext.CtDeKiemTraTracNghiems.Add(ctTN);
                    }    
                    else
                    {
                        // thêm ct đề kiểm tra code
                        CtDeKiemTraCode ctCode = new CtDeKiemTraCode()
                        {
                            IdDeKiemTra = deKiemTra.Id,
                            IdBaiTapCode = item.id,
                            SttCauHoi = item.stt,
                            Diem = item.diem
                        };
                        _codeSampleContext.CtDeKiemTraCodes.Add(ctCode);
                        
                    }
                    
                }
                _codeSampleContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public DeKiemTra_Custom getDeKiemTraByID(int id)
        {
            // lấy danh sách câu hỏi đề kiểm tra code
            var lsCode = (from ktCode in _codeSampleContext.CtDeKiemTraCodes
                          where ktCode.IdDeKiemTra == id
                          select new CauHoi()
                          {
                              id = ktCode.IdBaiTapCode,
                              diem = ktCode.Diem,
                              loaiCauHoi = 1,
                              stt = ktCode.SttCauHoi
                          }).ToList();

            // lấy danh sách câu hỏi đề kiểm tra trăc nghiệm
            var lsTN = (from ktTN in _codeSampleContext.CtDeKiemTraTracNghiems
                          where ktTN.IdDeKiemTra == id
                          select new CauHoi()
                          {
                              id = ktTN.IdBaiTapTracNghiem,
                              diem = ktTN.Diem,
                              loaiCauHoi = 0,
                              stt = ktTN.SttCauHoi
                          }).ToList();

            // gộp 2 danh sách lại và sắp xếp theo thứ tự câu
            var lsUnion = lsCode.Union(lsTN).OrderBy(p => p.stt).ToList();

            var res = (from deKT in _codeSampleContext.DeKiemTras
                      where deKT.Id == id
                      select new DeKiemTra_Custom()
                      {
                          moTa = deKT.MoTa,
                          ngayBatDau = deKT.NgayBatDau,
                          ngayKetThuc = deKT.NgayKetThuc,
                          trangThai = deKT.TrangThai,
                          listCauHoi = lsUnion
                      }).FirstOrDefault();
            return res;
        }
    }
}
