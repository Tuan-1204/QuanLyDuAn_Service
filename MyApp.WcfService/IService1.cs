using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using MyApp.DTO;

namespace MyApp.WcfService
{
    [ServiceContract]
    public interface IService1
    {
        //  CÁC THAO TÁC CHO  NHÂN VIÊN
        [OperationContract]
        //lấy tất cả danh sách nhân viên
        List<NhanvienDto> Nhanvien_GetAll();

        //thêm mới nhân viên
        [OperationContract]
        void Nhanvien_Insert(NhanvienDto dto);
        //cập nhật thông tin nhân viên
        [OperationContract]
        void Nhanvien_Update(NhanvienDto dto);

        //xóa nhân viênB
        [OperationContract]
        void Nhanvien_Delete(string id);


        //  CÁC THAO TÁC CHO DỰ ÁN 
        [OperationContract]
        List<DuanDto> Duan_GetAll();

        [OperationContract]
        void Duan_Insert(DuanDto dto);

        [OperationContract]
        void Duan_Update(DuanDto dto);

        [OperationContract]
        void Duan_Delete(string id);


        // CÁC THAO TÁC CHO  NHÂN VIÊN DỰ ÁN 
        [OperationContract]
        void Nvd_Insert(NhanvienDuanDto dto);

        [OperationContract]
        void Nvd_Update(NhanvienDuanDto dto);

        [OperationContract]
        void Nvd_Delete(string manv, string mada);


        //  TRUY VẤN BÁO CÁO 
        [OperationContract]
        List<NhanvienDuanDto> Nvd_GetReport();
    }
}