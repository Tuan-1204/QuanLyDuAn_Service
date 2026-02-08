using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MyApp.DTO
{
    [DataContract]
    public class DuanDto
    {
        //Mã dự án
        [DataMember] public string Mada { get; set; }
        //Tên dự án
        [DataMember] public string Tenda { get; set; }
        //Địa điểm
        [DataMember] public string Diadiem { get; set; }
    }
}
