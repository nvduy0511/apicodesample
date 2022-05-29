using CodeSampleAPI.Data;
using CodeSampleAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IBaiLamKiemTraService
    {
        bool add(BaiLamKiemTraCustom baiLamKiemTra);

    }
    public class BaiLamKiemTraService:IBaiLamKiemTraService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public BaiLamKiemTraService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

        public bool add(BaiLamKiemTraCustom baiLamKiemTraCustom)
        {
            List<CauTraLoi> lsCauTraLoi = baiLamKiemTraCustom.lsCauTraLoi;
            try
            {
                BaiLamKiemTra baiLamKiemTra = new BaiLamKiemTra()
                {
                    TongDiem = baiLamKiemTraCustom.tongDiem,
                    IdDeKiemTra = baiLamKiemTraCustom.idDeKiemTra,
                    NgayNopBai = DateTime.Now,
                    UIdNguoiDung = baiLamKiemTraCustom.uId
                };
                _codeSampleContext.BaiLamKiemTras.Add(baiLamKiemTra);
                _codeSampleContext.SaveChanges();

                foreach(var cauTraLoi in lsCauTraLoi)
                {
                    if(cauTraLoi.loaiCauHoi == 0)
                    {
                        CtBaiLamTracNghiem ctBaiLamTracNghiem = new CtBaiLamTracNghiem()
                        {
                            IdBaiLamKt = baiLamKiemTra.Id,
                            IdBaiTapTracNghiem = cauTraLoi.id,
                            IdDeKiemTra = baiLamKiemTraCustom.idDeKiemTra,
                            Diem = cauTraLoi.diem,
                            DapAn = int.Parse(cauTraLoi.dapAn)
                        };
                        _codeSampleContext.CtBaiLamTracNghiems.Add(ctBaiLamTracNghiem);
                    }
                    else
                    {
                        CtBaiLamCode ctBaiLamCode = new CtBaiLamCode()
                        {
                            IdBaiLamKt = baiLamKiemTra.Id,
                            IdBaiTapCode = cauTraLoi.id,
                            IdDeKiemTra = baiLamKiemTraCustom.idDeKiemTra,
                            Diem = cauTraLoi.diem,
                            Code = cauTraLoi.dapAn
                        };
                        _codeSampleContext.CtBaiLamCodes.Add(ctBaiLamCode);
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
    }
}
