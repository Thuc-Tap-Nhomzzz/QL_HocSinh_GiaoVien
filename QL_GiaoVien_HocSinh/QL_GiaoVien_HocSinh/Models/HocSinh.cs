using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_GiaoVien_HocSinh.Models
{
  public  class HocSinh
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email { get; set; }
        public string DanToc { get; set; }
        public string SoDienThoai { get; set; }
        public string LopMa { get; set; }
        public string DiaChi { get; set; }
    }
}
