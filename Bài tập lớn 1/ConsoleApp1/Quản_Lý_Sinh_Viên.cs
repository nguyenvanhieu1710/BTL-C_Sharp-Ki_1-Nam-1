using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_tập_lớn_1
{
    internal class Quản_Lý_Sinh_Viên
    {
        public struct Sinhvien
        {
            public string Masv;
            public string Tensv;
            public string Malop;         
            public string Ngaysinh;
            public string Gioitinh;
            public string Diachi;
            public string Sodienthoai;
            public string Diem;
        }
        public static Sinhvien Taosv(string Masv,string Tensv, string Malop,string Ngaysinh,string Gioitinh,string Diachi,string Sodienthoai,string Diem)
        {
            Sinhvien sinhvien = new Sinhvien();
            sinhvien.Tensv = Tensv;
            sinhvien.Masv = Masv;
            sinhvien.Malop = Malop;
            sinhvien.Ngaysinh = Ngaysinh;
            sinhvien.Gioitinh = Gioitinh;
            sinhvien.Diachi = Diachi;
            sinhvien.Sodienthoai = Sodienthoai;
            sinhvien.Diem = Diem;
            return sinhvien;
        }
    }
}
