using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BarcodePrint
{
    public enum BarcodeBlockDataEnum
    {
      
        [Description("Seq")]
        Seq,

        [Description("SID")]
        SID,

        [Description("Mã bệnh nhân")]
        PID,

        [Description("Tên bệnh nhân")]
        PatientName,

        [Description("Số phiếu")]
        OrderID,

        [Description("Mã y tế")]
        Invoice,

        [Description("Ngày sinh")]
        DateOfBirth,

        [Description("Năm sinh")]
        NamSinh,

        [Description("Tuổi")]
        Tuoi,

        [Description("Sex")]
        Sex,

        [Description("Giới tính")]
        SexDisplay,

        [Description("Địa chỉ")]
        Address,

        [Description("Chẩn đoán")]
        ChanDoan,

        [Description("Mã khoa phòng")]
        LocationID,

        [Description("Tên khoa phòng")]
        LocationName,

        [Description("Mã đối tượng")]
        ObjectID,

        [Description("Tên đối tượng")]
        ObjectName,

        [Description("Mã bác sĩ")]
        DoctorID,

        [Description("Tên bác sĩ")]
        DoctorName,

        [Description("Nhóm chung xét nghiệm")]
        GroupCategoryID,

        [Description("Ngày nhập")]
        DateIn,

        [Description("Thời gian nhập")]
        InTime,

        [Description("Cấp Cứu")]
        Urgent,

        [Description("Thời gian in barcode")]
        PrintTime,

        [Description("Mã loại mẫu")]
        TypeID,

        [Description("Tên loại mẫu")]
        TypeName,

        [Description("Ghi chú test")]
        Notice,
        
    }
}
