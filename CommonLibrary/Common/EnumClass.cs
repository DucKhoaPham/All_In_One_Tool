using System.ComponentModel;

namespace QI.Core.Common
{
    public enum LoaiHoSoEnum
    {
        #region Hồ sơ
        HoSoTruong = 1,
        HoSoGiaoVien = 2,
        HoSoLop = 4,
        HoSoHocSinh = 8,
        HoSoEQMSDNC1 = 16,
        HoSoEQMSGNC1 = 32,
        HoSoEQMSCNC1 = 64,
        KetQuaHocTap11 = 128, //kỳ 1 GK
        KetQuaHocTap12 = 256, //kỳ 1 CK
        KetQuaHocTap21 = 512, //kỳ 2 GK
        KetQuaHocTap22 = 1024, //kỳ 2 CK
        KhenThuong = 2048, //khen thưởng ky luat
        KetQuaHocTapDiemThiLai = 4096, //ket qua hoc tap, diem thi lai,
        KetQuaHocTap33 = 8192, // cuoi nam
        HocSinhTotNghiep = 16384, //học sinh tốt nghiệp
        KetQuaHocTapHS12 = 32768, //Kết quả học tập học sinh lớp 12
        #endregion

        #region Xóa hồ sơ
        XoaHoSoTruong = 9010000,
        XoaHoSoGiaoVien = 9020000,
        XoaHoSoLop = 9030000,
        XoaHoSoHocSinh = 9040000,
        XoaHoSoDiemTruong = 9050000,
        XoaHoSoHocSinhTotNghiep = 9060000,
        #endregion

        #region Báo cáo đầu năm

        #region Báo cáo Emis

        #region Mầm non
        BaoCaoEmisMNTruongLopDauNam = 10010000,
        BaoCaoEmisMNGiaoVienDauNam = 10020000,
        BaoCaoEmisMNHocSinhDauNam = 10030000,
        BaoCaoEmisMNCsvcDauNam = 10040000,
        BaoCaoEmisMNNganSachDauNam = 10050000,
        BaoCaoEmisMNDoTuoiDauNam = 10060001,
        #endregion

        #region C1
        BaoCaoEmisC1TruongLopDauNam = 10011000,
        BaoCaoEmisC1GiaoVienDauNam = 10021000,
        BaoCaoEmisC1HocSinhDauNam = 10031000,
        BaoCaoEmisC1CsvcDauNam = 10041000,
        BaoCaoEmisC1NganSachDauNam = 10051000,
        BaoCaoEmisC1DoTuoiDauNam = 10061001,
        #endregion

        #region C2
        BaoCaoEmisC2TruongLopDauNam = 10012000,
        BaoCaoEmisC2GiaoVienDauNam = 10022000,
        BaoCaoEmisC2HocSinhDauNam = 10032000,
        BaoCaoEmisC2CsvcDauNam = 10042000,
        BaoCaoEmisC2NganSachDauNam = 10052000,
        BaoCaoEmisC2DoTuoiDauNam = 100620001,
        #endregion

        #region C3
        BaoCaoEmisC3TruongLopDauNam = 10013000,
        BaoCaoEmisC3GiaoVienDauNam = 10023000,
        BaoCaoEmisC3HocSinhDauNam = 10033000,
        BaoCaoEmisC3CsvcDauNam = 10043000,
        BaoCaoEmisC3NganSachDauNam = 10053000,
        BaoCaoEmisC3DoTuoiDauNam = 10063001,
        #endregion

        #region GDTX
        BaoCaoEmisGDTXTruongLopDauNam = 10014000,
        BaoCaoEmisGDTXGiaoVienDauNam = 10024000,
        BaoCaoEmisGDTXHocSinhDauNam = 10034000,
        BaoCaoEmisGDTXNganSachDauNam = 10054000,
        BaoCaoEmisGDTXNgoaiNguTinHocCongDongDauNam = 10055000,
        BaoCaoEmisGDTXNgoaiNguTinHocCongDongDoiNguDauNam = 10056000,
        BaoCaoEmisGDTXNgoaiNguTinHocCongDongQuyMoDauNam = 10057000,
        #endregion

        #endregion

        #region Báo cáo EQMS

        #region C1
        BaoCaoEqmsC1GiaoVienDauNam = 20010000,
        BaoCaoEqmsC1GiaoVienTiengAnhDauNam = 20011000,
        BaoCaoEqmsC1DiemTruongCSVCDauNam = 20012000,
        BaoCaoEqmsC1DiemTruongLopHocSinhDauNam = 20013000,
        BaoCaoEqmsC1LopHSDauNam = 20014000,
        BaoCaoEqmsC1CSVCDienTichDatDauNam = 20015000,
        BaoCaoEqmsC1CSVCPhongHocDauNam = 20016000,
        BaoCaoEqmsC1CSVCNhaVeSinhDauNam = 20017000,
        #endregion

        #endregion

        #region Báo cáo Đề án ngoại ngữ

        #region Mầm non
        BaoCaoDannMNTruongTreEmDauNam = 39000000,
        #endregion

        #region C1
        BaoCaoDannC1GiaoVienTiengAnhDauNam = 41000000,
        BaoCaoDannC1GiaoVienNgoaiNguKhacDauNam = 41100000,
        BaoCaoDannC1SoLuongNgoaiNguDauNam = 41200000,
        BaoCaoDannC1SoLuongGiaoVienBoiDuongNangCaoNangLucNgoaiNguDauNam = 41300000,
        BaoCaoDannC1SoLuongGiaoVienBoiDuongNangCaoNangLucSuPhamDauNam = 41400000,
        #endregion

        #region C2
        BaoCaoDannC2GiaoVienTiengAnhDauNam = 42000000,
        BaoCaoDannC2GiaoVienNgoaiNguKhacDauNam = 42100000,
        BaoCaoDannC2SoLuongNgoaiNguDauNam = 42200000,
        BaoCaoDannC2SoLuongGiaoVienBoiDuongNangCaoNangLucNgoaiNguDauNam = 42300000,
        BaoCaoDannC2SoLuongGiaoVienBoiDuongNangCaoNangLucSuPhamDauNam = 42400000,
        #endregion

        #region C3
        BaoCaoDannC3GiaoVienTiengAnhDauNam = 43000000,
        BaoCaoDannC3GiaoVienNgoaiNguKhacDauNam = 43100000,
        BaoCaoDannC3SoLuongNgoaiNguDauNam = 43200000,
        BaoCaoDannC3SoLuongGiaoVienBoiDuongNangCaoNangLucNgoaiNguDauNam = 43300000,
        BaoCaoDannC3SoLuongGiaoVienBoiDuongNangCaoNangLucSuPhamDauNam = 43400000,
        #endregion

        #endregion

        #region Báo cáo Giáo dục thể chất
        BaoCaoGdtcMNDauNam = 55000000,
        BaoCaoGdtcC1DauNam = 56000000,
        BaoCaoGdtcC2DauNam = 57000000,
        BaoCaoGdtcC3DauNam = 58000000,
        #endregion

        #region Báo cáo Máy tính cho em

        #region MN
        BaoCaoMtceNhuCauThietBiMNDauNam = 65000000,
        BaoCaoMtceHienTrangThietBiMNDauNam = 75000000,
        #endregion

        #region C1
        BaoCaoMtceNhuCauThietBiC1DauNam = 66000000,
        BaoCaoMtceHienTrangThietBiC1DauNam = 76000000,
        #endregion

        #region C2
        BaoCaoMtceNhuCauThietBiC2DauNam = 67000000,
        BaoCaoMtceHienTrangThietBiC2DauNam = 77000000,
        #endregion

        #region C3
        BaoCaoMtceNhuCauThietBiC3DauNam = 68000000,
        BaoCaoMtceHienTrangThietBiC3DauNam = 78000000,
        #endregion

        #region GDTX
        BaoCaoMtceNhuCauThietBiGDTXDauNam = 69000000,
        BaoCaoMtceHienTrangThietBiGDTXDauNam = 79000000,
        #endregion

        #endregion

        #endregion

        #region Báo cáo giữa năm

        #region Báo cáo EQMS

        #region C1
        BaoCaoEqmsC1DiemGiuaNam = 20020000,
        BaoCaoEqmsC1DanhGiaHSGiuaNam = 20022000,
        BaoCaoEqmsC1ChuyenMonCongDongGiuaNam = 20024000,
        BaoCaoEqmsC1ChuyenMonCongDong2GiuaNam = 20025000,
        #endregion

        #endregion

        #endregion

        #region Báo cáo cuối năm

        #region Báo cáo Emis

        #region Mầm non
        BaoCaoEmisMNTruongLopCuoiNam = 10060000,
        #endregion

        #region C1
        BaoCaoEmisC1TruongLopCuoiNam = 10061000,
        BaoCaoEmisC1GiaoVienCuoiNam = 10071000,
        BaoCaoEmisC1HocSinhCuoiNam = 10081000,
        #endregion

        #region C2
        BaoCaoEmisC2TruongLopCuoiNam = 10062000,
        BaoCaoEmisC2GiaoVienCuoiNam = 10072000,
        BaoCaoEmisC2HocSinhCuoiNam = 10082000,
        #endregion

        #region C3
        BaoCaoEmisC3TruongLopCuoiNam = 10063000,
        BaoCaoEmisC3GiaoVienCuoiNam = 10073000,
        BaoCaoEmisC3HocSinhCuoiNam = 10083000,
        #endregion

        #region GDTX
        BaoCaoEmisGDTXTruongLopCuoiNam = 10064000,
        BaoCaoEmisGDTXGiaoVienCuoiNam = 10074000,
        BaoCaoEmisGDTXHocSinhCuoiNam = 10084000,
        #endregion

        #endregion

        #region Báo cáo EQMS
        BaoCaoEqmsC1DiemCuoiNam = 20030000,
        BaoCaoEqmsC1DanhGiaHSCuoiNam = 20032000,
        BaoCaoEqmsC1ChuyenMonCongDongCuoiNam = 20034000,
        BaoCaoEqmsC1ChuyenMonCongDong2CuoiNam = 20035000,
        #endregion

        #region Báo cáo đội ngũ

        #region Mầm non
        BaoCaoDoiNguMNCanBoQuanLyChungCuoiNam = 31000000,
        BaoCaoDoiNguMNCanBoQuanLyChuanNgheNghiepCuoiNam = 31100000,
        BaoCaoDoiNguMNCanBoQuanLyNgoaiNguTinHocCuoiNam = 31200000,
        BaoCaoDoiNguMNGiaoVienChungCuoiNam = 31300000,
        BaoCaoDoiNguMNGiaoVienChuanNgheNghiepCuoiNam = 31400000,
        BaoCaoDoiNguMNGiaoVienNgoaiNguTinHocCuoiNam = 31500000,
        #endregion

        #region C1
        BaoCaoDoiNguC1CanBoQuanLyChungCuoiNam = 32000000,
        BaoCaoDoiNguC1CanBoQuanLyChuanNgheNghiepCuoiNam = 32100000,
        BaoCaoDoiNguC1CanBoQuanLyNgoaiNguTinHocCuoiNam = 32200000,
        BaoCaoDoiNguC1GiaoVienChungCuoiNam = 32300000,
        BaoCaoDoiNguC1GiaoVienChuanNgheNghiepCuoiNam = 32400000,
        BaoCaoDoiNguC1GiaoVienNgoaiNguTinHocCuoiNam = 32500000,
        #endregion

        #region C2
        BaoCaoDoiNguC2CanBoQuanLyChungCuoiNam = 33000000,
        BaoCaoDoiNguC2CanBoQuanLyChuanNgheNghiepCuoiNam = 33100000,
        BaoCaoDoiNguC2CanBoQuanLyNgoaiNguTinHocCuoiNam = 33200000,
        BaoCaoDoiNguC2GiaoVienChungCuoiNam = 33300000,
        BaoCaoDoiNguC2GiaoVienChuanNgheNghiepCuoiNam = 33400000,
        BaoCaoDoiNguC2GiaoVienNgoaiNguTinHocCuoiNam = 33500000,
        #endregion

        #region C3
        BaoCaoDoiNguC3CanBoQuanLyChungCuoiNam = 34000000,
        BaoCaoDoiNguC3CanBoQuanLyChuanNgheNghiepCuoiNam = 34100000,
        BaoCaoDoiNguC3CanBoQuanLyNgoaiNguTinHocCuoiNam = 34200000,
        BaoCaoDoiNguC3GiaoVienChungCuoiNam = 34300000,
        BaoCaoDoiNguC3GiaoVienChuanNgheNghiepCuoiNam = 34400000,
        BaoCaoDoiNguC3GiaoVienNgoaiNguTinHocCuoiNam = 34500000,
        #endregion

        #region GDTX
        BaoCaoDoiNguGDTXCanBoQuanLyChungCuoiNam = 35000000,
        BaoCaoDoiNguGDTXCanBoQuanLyChuanNgheNghiepCuoiNam = 35100000,
        BaoCaoDoiNguGDTXCanBoQuanLyNgoaiNguTinHocCuoiNam = 35200000,
        BaoCaoDoiNguGDTXGiaoVienChungCuoiNam = 35300000,
        BaoCaoDoiNguGDTXGiaoVienNgoaiNguTinHocCuoiNam = 35400000,
        #endregion

        #endregion

        #endregion

        #region Trạng thái báo cáo

        TrangThaiBaoCaoTruong = 45000000,
        TrangThaiBaoCaoPhong = 45100000,
        TrangThaiBaoCaoSo = 45200000,

        #endregion

        #region Báo cáo Phòng/Sở
        BaoCaoNganSachNhaNuocPhongGDDauNam = 50000000,
        BaoCaoGiaoDucKhuyetTatSoGDDauNam = 50000000,
        BaoCaoGiaoDucKhuyetTatSoGDCuoiNam = 50000000,
        BaoCaoPhoCapSoGDDauNam = 50000000,
        BaoCaoPhoCapSoGDCuoiNam = 50000000,
        BaoCaoNganSachNhaNuocSoGDDauNam = 50000000,
        BaoCaoGiaoDUcKhuyetTatHocSinhSoGDDauNam = 50000000,
        BaoCaoGiaoDUcKhuyetTatGiaoVienSoGDDauNam = 50000000,
        #endregion

        #region báo cáo tại sở
        BaoCaoThiDuaKhenThuongCapSoGD = 45210000,
        #endregion
        #region gửi file đính kèm
        QuanLyFileUpLoadCapSoGD = 45220000,
        QuanLyFileUpLoadCapPhongGD = 45110000,
        QuanLyFileUpLoadCapTruong = 45001000
        #endregion
    }

    public enum LoaiYeuCau
    {
        HoSo = 0,
        BaoCao = 1
    }

    public enum GiaiDoanBaoCao
    {
        DauNam = 1, GiuaNam = 2, CuoiNam = 3
    }

    public enum TrangThaiBaoCao
    {
        KhoiTao = 0,
        HoanThanh = 1,
        DangXuLy = 2
    }

    public enum XoaHoSoEnum
    {
        [Description("TRUONG")]
        TRUONG = 1,
        [Description("LOP")]
        LOP = 2,
        [Description("HOC_SINH")]
        HOC_SINH = 3,
        [Description("NHAN_SU")]
        NHAN_SU = 4,
        [Description("NGUOI_DUNG")]
        NGUOI_DUNG = 5,
        [Description("LOP_MON")]
        LOP_MON = 6,
        [Description("DIEM_TRUONG")]
        DIEM_TRUONG = 7,
        [Description("HOC_SINH_TOT_NGHIEP")]
        HOC_SINH_TOT_NGHIEP = 8,
    }

    public enum TrangThaiYeuCauEnum
    {
        KhoiTao = 1,
        DangXuLy = 2,
        HoanThanh = 3,
        HuyBo = 4,
        DaGuiGoiTin = 5
    }
    public enum TrangThaiWorkerEnum
    {
        ChuaXuLy = 0,
        DaGuiGoiTin = 1,
        ChoCheckKQ = 2,
        DaGuiChoCheck = 3,
        HoanThanh = 4,

    }
    public enum TrangThaiRequestApi
    {
        DangXuLy = 1,
        ThanhCong = 2,
        KhongThanhCong = 3,
        DaGuiGoiTin = 4
    }

    public enum ValidateYeuCauEnum
    {
        KhongHopLe = 1,
        HopLe = 2,
        BoQua = 3
    }
}
