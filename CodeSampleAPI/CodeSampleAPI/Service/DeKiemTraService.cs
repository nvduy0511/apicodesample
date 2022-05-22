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
                        CtDeKiemTraCode ctCode = new CtDeKiemTraCode() 
                        {
                            IdDeKiemTra =  deKiemTra.Id,
                            IdBaiTapCode=item.id, 
                            SttCauHoi = item.stt,
                            Diem = item.diem
                        };
                        _codeSampleContext.CtDeKiemTraCodes.Add(ctCode);
                    }    
                    else
                    {
                        // thêm ct đề kiểm tra code
                        CtDeKiemTraTracNghiem ctTN = new CtDeKiemTraTracNghiem()
                        {
                            IdDeKiemTra = deKiemTra.Id,
                            IdBaiTapTracNghiem = item.id,
                            SttCauHoi = item.stt,
                            Diem = item.diem
                        };
                        _codeSampleContext.CtDeKiemTraTracNghiems.Add(ctTN);
                    }
                    _codeSampleContext.SaveChanges();
                }    
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
