using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MyApp.DTO
{
    [DataContract]
    public class NhanvienDuanDto
    {
        //Mã nhân viên
        [DataMember] public string Manv { get; set; }
        //Mã dự án
        [DataMember] public string Mada { get; set; }
        //Số giờ công
        [DataMember] public int Sogiocong { get; set; } // vừa dùng cho Report vừa dùng cho nhập liệu
        //Họ tên nhân viên để dùng cho Report
        [DataMember] public string Hoten { get; set; } // Dùng cho Report
        // Tên dự án để dùng cho Report
        [DataMember]public string Tenda { get; set; } // Dùng cho Report
        // Địa điểm dự án để dùng cho Report
        [DataMember] public string Diadiem { get; set; } // Dùng cho Report
    }
}
