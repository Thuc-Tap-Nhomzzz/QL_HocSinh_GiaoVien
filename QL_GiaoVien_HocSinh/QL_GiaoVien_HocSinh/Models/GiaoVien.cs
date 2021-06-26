using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_GiaoVien_HocSinh.Models
{
    public class GiaoVien
    {
        public String Ma { get; set; }
        public String Ten { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public String Email { get; set; }
        public int Luong { get; set; }
        public String NhiemVu { get; set; }
        public String SoDienThoai { get; set; }
        public String BoMonMa { get; set; }
    }
}
