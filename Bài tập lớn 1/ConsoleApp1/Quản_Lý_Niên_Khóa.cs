using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Bài_tập_lớn_1.Quản_Lý_Khoa;
using static Bài_tập_lớn_1.Quản_Lý_Niên_Khóa;

namespace Bài_tập_lớn_1
{
    internal class Quản_Lý_Niên_Khóa : Quản_Lý_Lớp
    {
        public struct Nienkhoa
        {
            public string Manienkhoa;
            public string Tennienkhoa;
            public List<Lop> DSlop;

        }
        public static Nienkhoa Taonienkhoamoi(string Manienkhoa, string Tennienkhoa)//hàm tạo niên khóa
        {
            Nienkhoa nkmoi = new Nienkhoa();
            nkmoi.Manienkhoa = Manienkhoa;
            nkmoi.Tennienkhoa = Tennienkhoa;
            nkmoi.DSlop = new List<Lop>();
            return nkmoi;
        }
        // khởi tạo sanh sách lưu thông tin niên khoá
        public static List<Nienkhoa> DSNienkhoa = new List<Nienkhoa>();
        public static int luachon()
        {
            int i;
            while (true)
            {
                Console.Write("Mời nhập lựa chọn của bạn: ");

                if (int.TryParse(Console.ReadLine(), out i))
                {//kiểm tra lựa chọn nhập vào có đúng định dạng không, nếu đúng thì thoát khỏi vòng lặp
                    break;
                }
                else Console.WriteLine("Nhập lựa chọn chưa đúng định dạng");
            }
            return i;
        }
        public static Nienkhoa Laynienkhoa(string Manienkhoa)
        {
            foreach (Nienkhoa K in DSNienkhoa)
            {
                if (K.Manienkhoa == Manienkhoa) { return K; }
            }//kiểm tra mã niên khóa nếu trùng thì trả ra K(biến truy xuất đến DSnienkhoa) còn ko trùng thi trả ra 1 biến rỗng
            Nienkhoa Ktrong = new Nienkhoa();
            return Ktrong;
        }
        public static bool Ktttrung(string Manienkhoa)//hàm kiểm tra Mã niên khóa có trùng không
        {
            bool kt = true;
            foreach (Nienkhoa K in DSNienkhoa)//duyệt trong list DSnienkhoa
            {
                if (K.Manienkhoa == Manienkhoa) { kt = false; break; }//nếu trùng thì trả về false
            }
            return kt;//không trùng thì trả về true
        }
        public static void Quanlycacnienkhoa()
        {
            Console.OutputEncoding = Encoding.UTF8;
           
            Console.WriteLine("\t\t\t\t\t╔══════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║        QUẢN LÝ THÔNG TIN NIÊN KHÓA           ║");
            Console.WriteLine("\t\t\t\t\t╠══════════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║     1. THÊM NIÊN KHOÁ                        ║");
            Console.WriteLine("\t\t\t\t\t║         └──────────┘                         ║");
            Console.WriteLine("\t\t\t\t\t║     2. HIỂN THỊ CÁC NIÊN KHOÁ ĐÃ CÓ TRONG    ║");
            Console.WriteLine("\t\t\t\t\t║         DANH SÁCH                            ║");
            Console.WriteLine("\t\t\t\t\t║         └──────────────────────┘             ║");
            Console.WriteLine("\t\t\t\t\t║     3. XEM THÔNG TIN DANH SÁCH LỚP CỦA NIÊN  ║");
            Console.WriteLine("\t\t\t\t\t║         KHOÁ                                 ║");
            Console.WriteLine("\t\t\t\t\t║         └────────────────────┘               ║");
            Console.WriteLine("\t\t\t\t\t║     4. XOÁ NIÊN KHOÁ                         ║");
            Console.WriteLine("\t\t\t\t\t║         └──────────┘                         ║");
            Console.WriteLine("\t\t\t\t\t║     5. TÌM KIẾM NIÊN KHÓA                    ║");
            Console.WriteLine("\t\t\t\t\t║         └────────────────────┘               ║");
            Console.WriteLine("\t\t\t\t\t║     6. THOÁT KHỎI CHƯƠNG TRÌNH               ║");
            Console.WriteLine("\t\t\t\t\t║         └───────────────┘                    ║");
            Console.WriteLine("\t\t\t\t\t╠══════════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║     Hãy chọn một trong các chức năng trên:   ║");
            Console.WriteLine("\t\t\t\t\t╚══════════════════════════════════════════════╝");
            int lc = luachon();
            switch (lc)
            {
                case 1:
                    Themnienkhoa();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                     Bạn có làm thêm nữa không                     ║");
                    Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                    Console.WriteLine("║                                                                   ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      1.Có             │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      2.Không          │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                    Console.Write("Mời nhập lựa chọn của bạn: ");
                    string nhap = Console.ReadLine();
                    if (nhap.Equals("1"))
                    {
                        Quanlycacnienkhoa();
                    }
                    else if (nhap.Equals("2")) { break; }                   
                    break;
                case 2://hiển thị niên khóa đã có
                    DSNienkhoa.Clear();
                    docdanhsachnienkhoa();
                    Hienthinienkhoadaco();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                     Bạn có làm thêm nữa không                     ║");
                    Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                    Console.WriteLine("║                                                                   ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      1.Có             │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      2.Không          │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                    Console.Write("Mời nhập lựa chọn của bạn: ");
                    string nhap1 = Console.ReadLine();
                    if (nhap1.Equals("1"))
                    {
                        Quanlycacnienkhoa();
                    }
                    else if (nhap1.Equals("2")) { break; }
                    break;
                case 3://xem danh sách lớp của niên khoá đang đào tạo;
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t║           Nhập vào mã niên khóa muốn hiển thị       ║");
                    Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                    Console.WriteLine("\t\t\t\t\t║                                                     ║");
                    Console.WriteLine("\t\t\t\t\t║          ╭─────────────────────────────╮            ║");
                    Console.WriteLine("\t\t\t\t\t║          │ Mã niên khóa :              │            ║");
                    Console.WriteLine("\t\t\t\t\t║          ╰─────────────────────────────╯            ║");
                    Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                    Console.SetCursorPosition(68, 5);
                    string Manienkhoa = Console.ReadLine();
                    Hienthithongtinloptrongnienkhoa(Manienkhoa);
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                     Bạn có làm thêm nữa không                     ║");
                    Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                    Console.WriteLine("║                                                                   ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      1.Có             │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      2.Không          │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                    Console.Write("Mời nhập lựa chọn của bạn: ");
                    string nhap2 = Console.ReadLine();
                    if (nhap2.Equals("1"))
                    {
                        Quanlycacnienkhoa();
                    }
                    else if (nhap2.Equals("2")) { break; }
                    break;
                case 4://xóa niên khóa
                    do
                    {
                        Console.Write("Nhập vào mã niên khóa bạn muốn xóa: "); Manienkhoa = Console.ReadLine();
                        DSNienkhoa.Clear();
                        docdanhsachnienkhoa();
                        if (Ktttrung(Manienkhoa) == false) { break; }//kiểm tra mã khoa phải trùng,false là trùng
                        else
                        {
                            Console.WriteLine("Mã niên khóa này chưa có bạn phải thêm khoa đã ");
                            goto Thoat;
                        }
                    } while (true);
                    Xoanienkhoa(Manienkhoa);
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                     Bạn có làm thêm nữa không                     ║");
                    Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                    Console.WriteLine("║                                                                   ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      1.Có             │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      2.Không          │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                    Console.Write("Mời nhập lựa chọn của bạn: ");
                    string nhap3 = Console.ReadLine();
                    if (nhap3.Equals("1"))
                    {
                        Quanlycacnienkhoa();
                    }
                    else if (nhap3.Equals("2")) { break; }
                Thoat: Quanlycacnienkhoa();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t║          Nhập vào mã niên khóa muốn tìm kiếm        ║");
                    Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                    Console.WriteLine("\t\t\t\t\t║                                                     ║");
                    Console.WriteLine("\t\t\t\t\t║            ╭─────────────────────────────╮          ║");
                    Console.WriteLine("\t\t\t\t\t║            │ Mã niên khóa :              │          ║");
                    Console.WriteLine("\t\t\t\t\t║            ╰─────────────────────────────╯          ║");
                    Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                    Console.SetCursorPosition(70, 5);
                    Manienkhoa = Console.ReadLine();
                    Timkiemnienkhoa(Manienkhoa);
                    break;
                case 6: break;
                default:
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t╔════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t║           KHÔNG CÓ CHỨC NĂNG NÀY. VUI LÒNG NHẬP LẠI            ║");
                    Console.WriteLine("\t\t\t\t\t╚════════════════════════════════════════════════════════════════╝");
                    Quanlycacnienkhoa();
                    break;
            }
        }
        public static void Timkiemnienkhoa(string Manienkhoa)
        {
            Console.Clear ();
            DSNienkhoa.Clear ();
            docdanhsachnienkhoa();
            if (DSNienkhoa.Count > 0)
            {
                foreach(Nienkhoa nk in DSNienkhoa)
                {
                    if(nk.Manienkhoa== Manienkhoa)
                    {
                        Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                        Console.WriteLine("║              Danh sách các niên khóa                ║");
                        Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                        Console.WriteLine("║ Mã niên khóa ║ ║ Tên niên khóa ║");
                        Console.WriteLine($"║ {nk.Manienkhoa} ║\t\t ║ {nk.Tennienkhoa} ║");
                        Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                    }
                }
            }
            else { Console.WriteLine("không có dữ liệu"); }
        }
        public static void Hienthithongtinloptrongnienkhoa(string Manienkhoa)
        {
            Console.Clear ();
            DSNienkhoa.Clear();//xóa hết dữ liệu trong list DSNienkhoa
            docdanhsachnienkhoa();//đọc file ra DSNienkhoa để lấy Mã khoa trong DSNienkhoa
            if (Ktttrung(Manienkhoa) == false)//kiểm tra mã niên khóa phải trùng,false là trùng
            {
                //Console.WriteLine("check");
                Nienkhoa kq = Laynienkhoa(Manienkhoa);//cho kq = (nienkhoa trùng với nienkhoa(đã nhập)) để cho ra 1 biến truy xuất đến struct
                docdanhsachlop();//đọc file ra DSlop để lấy Mã khoa trong DSlop
                Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║           Danh sách các lớp trong niên khóa              ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
                Console.WriteLine("║ Mã lớp ║\t║ Tên lớp ║ GVCN ║ Mã khoa ║ Mã niên khóa ║");
                if (DSlop.Count > 0)//kiểm tra list DSlop có dữ liệu không
                {
                    foreach (Lop L in DSlop)//cho L chạy trong list DSlop
                    {
                        if (kq.Manienkhoa == L.Manienkhoa)//kiểm tra Mã niên khóa trong DSNienkhoa có trùng với Mã niên khóa trong Dslop không
                        {
                            //nếu trùng thì hiển thị ra màn hình
                            //Console.WriteLine("check");
                            Console.WriteLine("║ " + L.Malop + " ║" + "\t" + "║ " + L.Tenlop + " ║" + "\t" + "║ " + L.Giaovienchunhiem + " ║" + "\t" + "║ " + L.Makhoa + " ║" + "\t" + "║ " + L.Manienkhoa + " ║");
                            //Console.WriteLine(L.Manienkhoa);
                            //break;
                        }
                        //else { Console.Clear(); Console.WriteLine("Mã niên khóa không trùng với mã niên khóa trong lớp");break; }
                    }
                }
                else { Console.WriteLine("Niên khóa này không có lớp nào. Bạn phải thêm lớp vào niên khóa đã"); Chạy_Chương_Trình.inchinh(); }
            }
            else { Console.WriteLine("Niên khóa này chưa có. Bạn phải thêm niên khóa vào đã "); }

        }
        public static void Hienthinienkhoadaco()
        {
            if(DSNienkhoa.Count>0)//kiểm tra list DSnienkhoa có dữ liệu không 
            {
                Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                Console.WriteLine("║          Danh sách các niên khóa đang có            ║");
                Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                Console.WriteLine("║ Mã niên khóa ║ ║ Tên niên khóa ║");
                foreach (Nienkhoa K in DSNienkhoa)// Cho K chạy trong list DSkhoa
                {
                    Console.WriteLine($"║ {K.Manienkhoa} ║\t\t ║ {K.Tennienkhoa} ║");
                }
            }
            else
            {
                Console.WriteLine("Chưa có niên khóa nào");
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                   Bạn có muốn thêm niên khóa không                ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                                   ║");
                Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                Console.WriteLine("║                      │      1.Có             │                    ║");
                Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                Console.WriteLine("║                      │      2.Không          │                    ║");
                Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                Console.Write("Mời nhập lựa chọn của bạn: ");
                string nhap = Console.ReadLine();
                if (nhap.Equals("1"))
                {
                    Themnienkhoa();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║              Bạn có muốn hiển thị niên khóa nữa không             ║");
                    Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                    Console.WriteLine("║                                                                   ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      1.Có             │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      2.Không          │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                    Console.Write("Mời nhập lựa chọn của bạn: ");
                    string nhap1 = Console.ReadLine();
                    if (nhap1.Equals("1"))
                    {
                        Hienthinienkhoadaco();
                    }
                    else { }

                }
                else if (nhap.Equals("2")) { }
            }
            
            
        }
        public static void Xoanienkhoa(string Manienkhoa)
        {
            foreach(Nienkhoa nk in DSNienkhoa)//Cho k chạy trong list DSNienkhoa
            {
                if(nk.Manienkhoa == Manienkhoa)//nếu Mã niên khóa trong list DsNienkhoa = Mã niên khóa nhập vào
                {
                    //thì xóa trong DSkhoa
                    DSNienkhoa.Remove(nk);
                    //ghidanhsachnienkhoa();//xong lại ghi vào file
                    Console.WriteLine("Bạn đã xóa niên khóa thành công");
                    break;
                }
            }
            string filePath = "nienkhoa.txt";
            File.WriteAllText(filePath, string.Empty);//xóa dữ liệu trong file nienkhoa.txt
            ghidanhsachnienkhoa();//xóa xong thì ghi những dữ liệu cũ vô file (còn dữ liệu vừa bị xóa thì đã mất)
            DSNienkhoa.Clear();//xong lại cho list DSNienkhoa trống để trách bị lặp dữ liệu sang những phần khác
        }
        public static void Themnienkhoa()
        {
            string Manienkhoa;
            string Tennienkhoa;
            bool kt = true;
            do
            {
                do
                {
                    Console.Write("Nhập vào mã niên khoá: "); Manienkhoa = Console.ReadLine();
                    if(!Regex.IsMatch(Manienkhoa, @"^[0-9]+$")) { Console.WriteLine("Mã niên khóa không đúng định dạng vui lòng nhập lại"); }
                } while (!Regex.IsMatch(Manienkhoa, @"^[0-9]+$"));//kiểm tra điều kiện sai (nếu Manienkhoa nhập vào khác 0-9 thì nhập lại)
                kt = Ktttrung(Manienkhoa);//kiểm tra Manienkhoa có trùng ko: nếu trùng thì kt=false, ko trùng thì kt=true
                if (kt == false) Console.WriteLine("Mã niên khoá này đã có nhập lại thông tin");
            }
            while (kt == false);//kt phải = true(ko trùng) thì mới thoát khỏi vòng lặp 

            do
            {
                Console.Write("Nhập vào tên niên khóa: ");
                Tennienkhoa = Console.ReadLine();
                Tennienkhoa = Regex.Replace(Tennienkhoa, @"\s+", " ");//thay thế các khoảng trắng liên tiếp bằng một khoảng trắng duy nhất
                if (!Regex.IsMatch(Tennienkhoa, @"^[a-zA-Z0-9 ]+$")||Tennienkhoa.Length==0) { Console.WriteLine("Tên niên khóa không đúng định dạng vui lòng nhập lại"); }
            } while (!Regex.IsMatch(Tennienkhoa, @"^[a-zA-Z0-9 ]+$")||Tennienkhoa.Length==0);//kiểm tra điều kiện sai (nếu Tenkhoa nhập vào khác a-zA-Z0-9 thì nhập lại) 

            Nienkhoa Km = Taonienkhoamoi(Manienkhoa, Tennienkhoa);//Km = hàm Taonienkhoamoi
            DSNienkhoa.Add(Km);// thêm niên khóa đã nhập vào danh sách niên khóa
            /*foreach(Nienkhoa nienkhoa in DSNienkhoa)
            {
                Console.WriteLine(nienkhoa.Manienkhoa);
            }*/
            ghidanhsachnienkhoa();//ghi vào file nienkhoa.txt
            Console.WriteLine("Đã thêm niên khóa thành công");

        }
        public static void ghidanhsachnienkhoa()
        {
            try
            {
                for (int j = 0; j < DSNienkhoa.Count; j++)// duyệt dữ liệu trong DSkhoa
                {
                    //xong ghi dữ liệu vào file
                    File.AppendAllText("C:\\Users\\NGUYEN VAN HIEU\\Source\\Repos\\Bài tập lớn 1\\ConsoleApp1\\bin\\Debug\\nienkhoa.txt", $"{DSNienkhoa[j].Manienkhoa}@{DSNienkhoa[j].Tennienkhoa}" + "\n");

                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }//try-catch để kiểm tra ngoại lệ, soát lỗi,...
            
        }
        public static void docdanhsachnienkhoa()
        {
            try
            {
                //đọc file nienkhoa.txt ra 1 mảng
                string[] tach = File.ReadAllLines("C:\\Users\\NGUYEN VAN HIEU\\Source\\Repos\\Bài tập lớn 1\\ConsoleApp1\\bin\\Debug\\nienkhoa.txt");
                // 1 mảng = đọc file 1 dòng trong file là 1 dòng trong mảng
                foreach (string s in tach)
                {//duyệt trong mảng
                    Nienkhoa nienkhoa = new Nienkhoa();
                    string[] tach1 = s.Split('@');//tách mảng bởi dấu @            
                    nienkhoa.Manienkhoa = tach1[0];//trở thành dòng đầu
                    nienkhoa.Tennienkhoa = tach1[1];//dòng 2
                    //Console.WriteLine(tach1[0]);
                    //Console.WriteLine(nienkhoa.Manienkhoa);
                    DSNienkhoa.Add(nienkhoa);
                    /*foreach (Nienkhoa nienkhoa1 in DSNienkhoa)
                    {
                        Console.WriteLine("check trong DSnienkhoa");
                        Console.WriteLine(nienkhoa1.Manienkhoa);
                        Console.WriteLine(nienkhoa1.Tennienkhoa);
                    }
                    Console.WriteLine("Đã đọc hết dữ liệu trong DSnienkhoa"); */
                }
                Console.WriteLine("Đã đọc hết dữ liệu trong file nienkhoa.txt");
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }//try-catch để kiểm tra ngoại lệ, soát lỗi,...
            
        }
    }
}
