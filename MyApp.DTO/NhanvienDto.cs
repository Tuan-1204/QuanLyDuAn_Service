using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MyApp.DTO
{
    [DataContract]
    public class NhanvienDto
    {
        //Mã nhân viên
        [DataMember] public string Manhanvien { get; set; }
        //Họ tên nhân viên
        [DataMember] public string Hoten { get; set; }
        //Giới tính
        [DataMember] public string Gioitinh { get; set; }
        //Ngày sinh
        [DataMember] public DateTime? Ngaysinh { get; set; }
    }
}
