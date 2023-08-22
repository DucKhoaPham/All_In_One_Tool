namespace QI.Core.Common
{
    public class AppConfigs
    {
        public string ApiBaseURL { get; set; }
        public ApiURL ApiURLs { get; set; }
        public AuthConfigs AuthConfigs { get; set; }
        public int ApiTimeOut { get; set; }
        public int ServiceIntervalTime { get; set; }
        public bool LogRequestData { get; set; }
        public bool LogResponseData { get; set; }
        public int NamDongBoDanhMuc { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public bool CompressData { get; set; }
        public string ElasticUrl { get; set; }

    }
    public class ConnectionStrings
    {
        public string MoetDatabase { get; set; }
        public string MoetDatabase2021 { get; set; }
        public string DongBoDatabase { get; set; }      
        public string DongBoTuyenSinhPhoThongDatabase { get; set; }
    }
    public class ApiURL
    {
        public string GET_DM_NHOM_CAP_HOC { get; set; }
        public string GET_DM_TINH { get; set; }
        /// <summary>
        /// ?ma_nam_hoc=2017
        /// </summary>
        public string GET_ALL_HUYEN { get; set; }
        /// <summary>
        /// ?ma_tinh=xxx&ma_nam_hoc=2017
        /// </summary>
        public string GET_DM_HUYEN_BY_TINH { get; set; }
        /// <summary>
        /// ?ma_nam_hoc=2017
        /// </summary>
        public string GET_DM_XA { get; set; }
        /// <summary>
        /// ?ma_nam_hoc=2017
        /// </summary>
        public string GET_DM_LOAI_HINH { get; set; }
        /// <summary>
        /// ?ma_nam_hoc=2017
        /// </summary>
        public string GET_DM_MUC_DAT_CHUAN_QUOC_GIA { get; set; }
        public string GET_DM_KHU_VUC { get; set; }
        public string GET_DM_LOAI_TRUONG { get; set; }
        public string GET_DM_KHOI { get; set; }
        /// <summary>
        /// ?ma_cap_hoc=01
        /// </summary>
        public string GET_DM_KHOI_BY_MA_CAP_HOC { get; set; }
        public string GET_DM_NHOM_TUOI { get; set; }
        public string GET_DM_TIET_HOC { get; set; }
        public string GET_DM_HOC_NGOAI_NGU { get; set; }
        public string GET_DM_SO_TIET_NGOAI_NGU { get; set; }
        public string GET_DM_MON_HOC { get; set; }
        public string GET_DM_PHAN_BAN { get; set; }
        public string GET_DM_HE_CHUYEN { get; set; }
        public string GET_DM_KIEU_LOP { get; set; }
        public string GET_DM_HINH_THUC_DAO_TAO_HOC_TAP { get; set; }
        public string GET_DM_LOP_DAO_TAO_BOI_DUONG { get; set; }
        public string GET_DM_LOP_HUONG_NGHIEP_DAY_NGHE { get; set; }
        public string GET_DM_GIOI_TINH { get; set; }
        public string GET_DM_TRANG_THAI_HOC_SINH { get; set; }
        public string GET_DM_LY_DO_THOI_HOC { get; set; }
        public string GET_DM_DAN_TOC { get; set; }
        public string GET_DM_LOAI_KHUYET_TAT { get; set; }
        public string GET_DM_DIEN_CHINH_SACH { get; set; }
        /// <summary>
        /// ?ma_cap_hoc=01
        /// </summary>
        public string GET_DM_DIEN_CHINH_SACH_BY_MA_CAP_HOC { get; set; }
        public string GET_DM_NUOC { get; set; }
        public string GET_DM_TRANG_THAI_CAN_BO { get; set; }
        public string GET_DM_NHOM_CAN_BO { get; set; }
        /// <summary>
        /// ?ma_cap_hoc=01&cap_don_vi=04
        /// </summary>
        public string GET_DM_NHOM_CAN_BO_BY_CAP_HOC { get; set; }
        public string GET_DM_LOAI_CAN_BO { get; set; }
        /// <summary>
        /// ?ma_nhom=01&ma_cap_hoc=01&cap_don_vi=04
        /// </summary>
        public string GET_DM_LOAI_CAN_BO_BY_CAP_HOC { get; set; }
        /// <summary>
        /// ?ma_nam_hoc=2017
        /// </summary>
        public string GET_DM_HINH_THUC_HOP_DONG { get; set; }
        public string GET_DM_NGACH { get; set; }
        public string GET_DM_MON_DAY_GV { get; set; }
        /// <summary>
        /// ?ma_cap_hoc=01
        /// </summary>
        public string GET_DM_MON_DAY_GV_BY_CAP_HOC { get; set; }
        public string GET_DM_BAC_LUONG { get; set; }
        public string GET_DM_BOI_DUONG_TX { get; set; }
        /// <summary>
        /// ?ma_nam_hoc=2017
        /// </summary>
        public string GET_DM_TRINH_DO_CHUYEN_MON_NGHIEP_VU { get; set; }
        public string GET_DM_TRINH_DO_LLCT { get; set; }
        public string GET_DM_TRINH_DO_QLGD { get; set; }
        public string GET_DM_NGOAI_NGU { get; set; }
        public string GET_DM_TRINH_DO_NGOAI_NGU { get; set; }
        public string GET_DM_TRINH_DO_NGOAI_NGU_BY_MA_NGOAI_NGU { get; set; }
        public string GET_DM_TRINH_DO_TIN_HOC { get; set; }
        public string GET_DM_CHUYEN_MON { get; set; }
        public string GET_DM_KQ_CHUAN_NGHE_NGHIEP { get; set; }
        public string GET_DM_DG_VIEN_CHUC { get; set; }
        public string GET_DM_GIAO_VIEN_GIOI { get; set; }
        public string GET_DM_NHIEM_VU_KIEM_NHIEM { get; set; }
        public string GET_DM_NHOM_CHUYEN_NGANH { get; set; }
        public string GET_DM_KHEN_THUONG_GV { get; set; }
        public string GET_DM_KY_LUAT_GV { get; set; }
        public string GET_DM_VUNG_KHO_KHAN { get; set; }
        public string GET_DM_CAP_DON_VI { get; set; }
        public string GET_DM_CAP_HOC { get; set; }
        public string GET_DM_CHUAN_DAO_TAO { get; set; }
        public string GET_DM_CHUC_VU_DANG_VIEN { get; set; }
        public string GET_DM_CHUC_VU_DOAN_VIEN { get; set; }
        public string GET_DM_CHUYEN_NGANH_DAO_TAO { get; set; }
        public string GET_DM_DANG_NGHI_BHXH { get; set; }
        public string GET_DM_DANH_HIEU { get; set; }
        public string GET_DM_DIEN_UU_TIEN_GD { get; set; }
        public string GET_DM_DU_AN { get; set; }
        public string GET_DM_GV_GIANG_DAY_VH { get; set; }
        public string GET_DM_HANG_THUONG_BINH { get; set; }
        public string GET_DM_HANH_KIEM { get; set; }
        public string GET_DM_HINH_THUC_DAO_TAO { get; set; }
        public string GET_DM_HINH_THUC_KHEN_THUONG { get; set; }
        public string GET_DM_HINH_THUC_KY_LUAT { get; set; }
        public string GET_DM_HINH_THUC_TUYEN_DUNG { get; set; }
        public string GET_DM_HOC_HAM { get; set; }
        public string GET_DM_HOC_LUC { get; set; }
        public string GET_DM_HOC_VAN_PHO_THONG { get; set; }
        public string GET_DM_HOC_VI { get; set; }
        public string GET_DM_KENH_TANG_TRUONG_CAN_NANG { get; set; }
        public string GET_DM_KHEN_THUONG_NHAN_SU { get; set; }
        public string GET_DM_LOAI_GV_GIANG_DAY_VAN_HOA { get; set; }
        public string GET_DM_LOP_GHEP { get; set; }
        public string GET_DM_MIEN_GIAM_HOC_PHI { get; set; }
        public string GET_DM_MOI_QUAN_HE { get; set; }
        public string GET_DM_NGANH_DAO_TAO { get; set; }
        public string GET_DM_QUAN_HAM { get; set; }
        public string GET_DM_TIENG_DAN_TOC { get; set; }
        public string GET_DM_TINH_TRANG_HON_NHAN { get; set; }
        public string GET_DM_TINH_TRANG_SUC_KHOE { get; set; }
        public string GET_DM_TON_GIAO { get; set; }
        public string GET_DM_TOT_NGHIEP { get; set; }
        public string GET_DM_TRINH_DO { get; set; }
        public string GET_DM_TRINH_DO_HANH_CHINH_NHA_NUOC { get; set; }

        public string GET_DM_SO { get; set; }
        /// <summary>
        /// ?nam_hoc=2017
        /// </summary>
        public string GET_DM_PHONG { get; set; }
        /// <summary>
        /// ?nam_hoc=2017&ma_so=01
        /// </summary>
        public string GET_DM_PHONG_BY_SO { get; set; }
        /// <summary>
        /// ?nam_hoc=2017&ma_so=01&ma_phong=01&cap_hoc=01
        /// </summary>
        public string GET_DM_TRUONG { get; set; }
        /// <summary>
        /// ?nam_hoc=2017&ma_so=01&ma_phong=01&ma_truong=000
        /// </summary>
        public string GET_DM_LOP { get; set; }

        public string GetAuthToken { get; set; }
        public string TiepNhan { get; set; }
        public string TiepNhanCompress { get; set; }
        public string TimKiemGiaoVien { get; set; }
        public string TimKiemHocSinh { get; set; }

        /// <summary>
        /// ?ma_nam_hoc=2018
        /// </summary>
        public string GET_DM_VUNG { get; set; }
        public string GET_DM_HOC_BAN_TRU { get; set; }
        public string GET_DM_SO_BUOI_HOC_TREN_TUAN { get; set; }
        public string GET_DM_TRUNG_TAM { get; set; }
        public string GET_DM_LOAI_TRUNG_TAM { get; set; }
    }

    public class AuthConfigs
    {
        public string CapDonVi { get; set; }
        public string MaDonVi { get; set; }
        public string CapHoc { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
