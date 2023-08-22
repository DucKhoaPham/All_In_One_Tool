namespace QI.Core.Common
{
    public class GiaiDoanConverter
    {
        public static string FromLoaiHoSo(LoaiHoSoEnum loaiHoSo)
        {
            string result = string.Empty;
            switch (loaiHoSo)
            {
                case LoaiHoSoEnum.KetQuaHocTap11:
                    {
                        result = "GK1";
                        break;
                    }
                case LoaiHoSoEnum.KetQuaHocTap12:
                    {
                        result = "CK1";
                        break;
                    }
                case LoaiHoSoEnum.KetQuaHocTap21:
                    {
                        result = "GK2";
                        break;
                    }
                case LoaiHoSoEnum.KetQuaHocTap22:
                    {
                        result = "CK2";
                        break;
                    }
                case LoaiHoSoEnum.KetQuaHocTap33:
                    {
                        result = "CN";
                        break;
                    }
            }
            return result;
        }
    }
}
