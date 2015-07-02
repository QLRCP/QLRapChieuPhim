using BUL;
using PUBLIC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ETN_Cinema
{
    class CheckNhapNV
    {
        public CheckNhapTB _hoten,_sdt,_email,_quequan,_diachi,_cmnd,_cv,_pb,_ava;
        public string _warningMsg;
        public void Check_Nhap(TextBox hoten, TextBox sdt, TextBox email, TextBox quequan, TextBox diachi, TextBox cmnd, ComboBox cv, ComboBox pb, TextBlock ava)
        {
            _hoten = new CheckNhapTB();
            _hoten.check_Hoten(hoten);
            _sdt = new CheckNhapTB();
            _sdt.check_Sdt(sdt);
            _email = new CheckNhapTB();
            _email.check_Email(email);
            _quequan = new CheckNhapTB();
            _quequan.check_queQuan(quequan);
            _diachi = new CheckNhapTB();
            _diachi.check_diaChi(diachi);
            _cv = new CheckNhapTB();
            _cv.check_CV(cv);
            _pb = new CheckNhapTB();
            _pb.check_PB(pb);
            _ava = new CheckNhapTB();
            _ava.check_Avatar(ava);
            _cmnd = new CheckNhapTB();
            _cmnd.check_cmnd(cmnd);
            _warningMsg = _hoten._warningMsg + _sdt._warningMsg + _email._warningMsg + _quequan._warningMsg + _diachi._warningMsg + _cmnd._warningMsg + _cv._warningMsg + _pb._warningMsg + _ava._warningMsg;
            
        }

    }


    class CheckNhapPhim
    {
        public CheckNhapTB _ten, _theloai, _noidung, _thoiluong, _dienvien, _daodien, _nuocsx, _tuoiquydinh, _namphathanh,_poster;
        public string _warningMsg;
        public void Check_Nhap(TextBox ten, ComboBox theloai, TextBox noidung, TextBox thoiluong, TextBox dienvien, TextBox daodien, TextBox nuocsx, TextBox tuoiquydinh, TextBox namphathanh,Uri poster)
        {
            _ten = new CheckNhapTB();
            _ten.check_Tenphim(ten);
            _theloai = new CheckNhapTB();
            _theloai.check_Theloai(theloai);
            _noidung = new CheckNhapTB();
            _noidung.check_Noidung(noidung);
            _thoiluong = new CheckNhapTB();
            _thoiluong.check_Thoiluong(thoiluong);
            _dienvien = new CheckNhapTB();
            _dienvien.check_Dienvien(dienvien);
            _daodien = new CheckNhapTB();
            _daodien.check_Daodien(daodien);
            _nuocsx = new CheckNhapTB();
            _nuocsx.check_Nuocsx(nuocsx);
            _tuoiquydinh = new CheckNhapTB();
            _tuoiquydinh.check_Tuoiquydinh(tuoiquydinh);
            _namphathanh = new CheckNhapTB();
            _namphathanh.check_Namphathanh(namphathanh);
            _poster = new CheckNhapTB();
            _poster.check_Poster(poster);
            _warningMsg = _ten._warningMsg + _theloai._warningMsg + _noidung._warningMsg + _thoiluong._warningMsg + _dienvien._warningMsg + _daodien._warningMsg + _nuocsx._warningMsg + _tuoiquydinh._warningMsg + _namphathanh._warningMsg + _poster._warningMsg;

        }
    }

    class CheckNhapSC
    {
        public CheckNhapTB _maphim,_giochieu,  _giave, _phongchieu, _loaiSC;
        public string _warningMsg;
        public void Check_Nhap(ComboBox maphim, ComboBox giochieu, ComboBox phutchieu, TextBox giave, ComboBox phongchieu, ComboBox loaiSC)
        {
            _maphim = new CheckNhapTB();
            _giochieu= new CheckNhapTB();
            _giave = new CheckNhapTB();
            _phongchieu = new CheckNhapTB();
            _loaiSC = new CheckNhapTB();
            _maphim.check_maphim(maphim);
            _giave.check_giave(giave);
            _giochieu.check_giochieu(giochieu, phutchieu);
            _phongchieu.check_phongchieu(phongchieu);
            _loaiSC.check_LSC(loaiSC);


            _warningMsg = _giochieu._warningMsg + _giave._warningMsg + _phongchieu._warningMsg + _loaiSC._warningMsg;

        }

    }

    class CheckNhapKH
    {
        public CheckNhapTB _hoten, _sdt, _email,  _diachi, _cmnd;
        public string _warningMsg;
        public void Check_Nhap(TextBox hoten, TextBox sdt, TextBox email1, TextBox email2, TextBox diachi, TextBox cmnd)
        {
            _hoten = new CheckNhapTB();
            _hoten.check_Hoten(hoten);
            _sdt = new CheckNhapTB();
            _sdt.check_Sdt(sdt);
            _email = new CheckNhapTB();
            _email.check_Email(email1,email2);
            _diachi = new CheckNhapTB();
            _diachi.check_diaChi(diachi);
            _cmnd = new CheckNhapTB();
            _cmnd.check_cmnd(cmnd);
            _warningMsg = _hoten._warningMsg + _sdt._warningMsg + _email._warningMsg +  _diachi._warningMsg + _cmnd._warningMsg;

        }

        public void Check_Nhap(TextBox hoten, TextBox sdt, TextBox email, TextBox diachi, TextBox cmnd)
        {
            _hoten = new CheckNhapTB();
            _hoten.check_Hoten(hoten);
            _sdt = new CheckNhapTB();
            _sdt.check_Sdt(sdt);
            _email = new CheckNhapTB();
            _email.check_Email(email);
            _diachi = new CheckNhapTB();
            _diachi.check_diaChi(diachi);
            _cmnd = new CheckNhapTB();
            _cmnd.check_cmnd(cmnd);
            _warningMsg = _hoten._warningMsg + _sdt._warningMsg + _email._warningMsg + _diachi._warningMsg + _cmnd._warningMsg;

        }

    }

    class CheckNhapTB
    {
        public BitmapImage _warningIcon;
        public BitmapImage _passIcon;
        public BitmapImage _checkImage;
        public string _warningMsg;


        private void pass()
        {
            _warningMsg = null;
            _checkImage = _passIcon;
        }

        private void warning(string _Msg)
        {
             _warningMsg = _Msg;
            _checkImage = _warningIcon;
        }

        public CheckNhapTB()
        {
            _passIcon = GetHinhAnhTuPoster("/check/pass-icon.png");
            _warningIcon = GetHinhAnhTuPoster("/check/warning-icon.png");
        }
//
        private bool _is_have_Number(string _str)
        {
            bool kt = false;
            for (int i = 0; i < _str.Length; i++)
                if (_str[i] >= '0' && _str[i] <= '9')
                {
                    kt = true;
                }
            return kt;
        }

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            Regex rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(email);
        }
//

        public void check_Null(TextBox tb,string mess)
        {
            if (tb.Text.ToString() == "")
            {
                warning(mess);
            }
            else
            {
                pass();
            }

        }

        public void check_isNumber(TextBox tb, string mess)
        {
            if (tb.Text.ToString() == "")
            {
                warning(mess+" không được để trống");
            }
            else
                if (!IsNumber(tb.Text.ToString()))
                {
                    warning(mess+" chỉ được chứa ký tự số");
                }
                else
                {
                    pass();
                }   
        }

        public void check_Image(TextBlock tb, string mess)
        {
            try
            {
                BitmapImage bm = GetHinhAnhTuPoster(tb.Text.ToString());
                pass();
            }
            catch
            {
                warning(mess+" chưa được chọn");
            }
        }

        //check nhập phim
        public void check_Tenphim(TextBox tb)
        {
            check_Null(tb, "Tên phim không được để trống");
                
        }
        public void check_Theloai(ComboBox tb)
        {
            string str = null;
            try
            {
                str = tb.SelectedValue.ToString();
            }
            catch
            {

            }
            if (str == null)
            {
                warning("Chưa chọn thể loại phim");
            }
            else
            {
                pass();
            }
        }

             public void check_Noidung(TextBox tb)
        {
            check_Null(tb, "Nội dung phim không được để trống");
                
        }
         public void check_Thoiluong(TextBox tb)
        {
            check_isNumber(tb, "Thời lượng");     
        }

         public void check_Daodien(TextBox tb)
         {
             check_Null(tb, "Đạo diễn phim không được để trống");

         }
         public void check_Dienvien(TextBox tb)
         {
             check_Null(tb, "Diễn viên trong phim không được để trống");

         }
         public void check_Nuocsx(TextBox tb)
         {
             check_Null(tb, "Nước sản xuất không được để trống");
         }

        public void check_Tuoiquydinh(TextBox tb)
         {
             check_isNumber(tb, "Độ tuổi quy định");
         }
        public void check_Namphathanh(TextBox tb)
        {
            check_isNumber(tb, "Năm phát hành");
        }
        public void check_Poster(Uri filmPosterURI)
        {
            if (filmPosterURI != null)
                    {
                        pass();
                    }
                    else
                    {
                        warning("Chưa nhập Poster Phim");
                    }
        }

        //check nhập phim
        
// Check nhập nhân viên
        public void check_Hoten(TextBox tb)
        {

            if (tb.Text.ToString() == "")
            {
                warning("Họ tên không được để trống");
            }
            else
                if (_is_have_Number(tb.Text.ToString()))
                {
                    warning("Họ tên không được chứa ký tự số");
                }
                else
                {
                    pass();
                }

        }

        public void check_Sdt(TextBox tb_sdt)
        {
            if (tb_sdt.Text.ToString() == "")
            {
                warning("Số điện thoại không được để trống");
            }
            else
            {
                if (!IsNumber(tb_sdt.Text.ToString()))
                {
                    warning("Số điện thoại chỉ được chứa ký tự số");
                }
                else
                {
                    if (tb_sdt.Text.Length>9)
                    {
                        warning("Số điện thoại không được lớn hơn 9 chữ số");
                    }
                    else
                    pass();
                }
            }
        }


        public void check_Email(TextBox tb)
        {
            if (tb.Text.ToString() == "")
            {
                warning("Địa chỉ Email không được để trống");
            }
            else
            {
                if (!IsValidEmail(tb.Text.ToString()))
                {
                    warning("Địa chỉ Email không chính xác");
                }
                else
                {
                    pass();
                }
            }
        }

        public void check_Email(TextBox tb1, TextBox tb2)
        {
            string str = tb1.Text.ToString() + "@" + tb2.Text.ToString();
            if (str == "@")
            {
                warning("Địa chỉ Email không được để trống");
            }
            else
            {
                if (!IsValidEmail(str))
                {
                    warning("Địa chỉ Email không chính xác");
                }
                else
                {
                    pass();
                }
            }
        }

        public void check_queQuan(TextBox tb)
        {
            if (tb.Text.ToString() == "")
            {
                warning("Quê quán không được để trống");
            }
            else
            {
                pass();
            }

        }

        public void check_diaChi(TextBox tb)
        {
            if (tb.Text.ToString() == "")
            {
                warning("Địa chỉ không được để trống");
            }
            else
            {
                pass();
            }

        }

        public void check_cmnd(TextBox tb)
        {
            if (tb.Text.ToString() == "")
            {
                warning("Số CMND không được để trống");
            }
            else
            {
                if (!IsNumber(tb.Text.ToString()))
                {
                    warning("Số CMND chỉ được chứa ký tự số");
                }
                else
                {
                    if (tb.Text.Length > 9)
                    {
                        warning("Số CMND không được lớn hơn 9 chữ số");
                    }
                    else
                        pass();
                }
            }

        }


        public void check_CV(ComboBox tb)
        {
            string str=null;
            try
            {
                str = tb.SelectedValue.ToString();
            }
            catch
            {

            }
            if (str == null)
            {
                warning("Chưa chọn chức vụ");
            }
            else
            {
                pass();
            }
        }

        public void check_PB(ComboBox tb)
        {
            string str = null;
            try
            {
                str = tb.SelectedValue.ToString();
            }
            catch
            {

            }
            if (str == null)
            {
                warning("Chưa chọn phòng ban");
            }
            else
            {
                pass();
            }
        }

        public void check_Avatar(TextBlock tb)
        {
            check_Image(tb, "Ảnh đại diện");
        }
// Check nhập nhân viên

//Check đăng ký suất chiếu


        public void check_giave(TextBox tb_sdt)
        {
            if (tb_sdt.Text.ToString() == "")
            {
                warning("Giá vé không được để trống");
            }
            else
            {
                if (!IsNumber(tb_sdt.Text.ToString()))
                {
                    warning("Giá vé chỉ được chứa ký tự số");
                }
                else
                {
                        pass();
                }
            }
        }

        public void check_giochieu(ComboBox tb, ComboBox tb2)
        {
            string str = null,str2=null;
            try
            {
                str = tb.SelectedValue.ToString();
            }
            catch
            {

            }

                try
                {
                    str2 = tb2.SelectedValue.ToString();
                }
                catch
                {

                }

                if (str == null)
                {
                    warning("Chưa chọn giờ chiếu");
                    return;
                }
                else
                {
                    if (str2 == null)
                    {
                        warning("Chưa chọn phút chiếu");
                        return;
                    }
                    else
                    {
                        pass();
                    }
                }
           
                
            
        }


        public void check_phongchieu(ComboBox tb)
        {
            string str = null;
            try
            {
                str = tb.SelectedValue.ToString();
            }
            catch
            {

            }
            if (str == null)
            {
                warning("Chưa chọn phòng chiếu");
            }
            else
            {
                pass();
            }
        }

        public void check_maphim(ComboBox tb)
        {
            string str = null;
            try
            {
                str = tb.SelectedValue.ToString();
            }
            catch
            {

            }
            if (str == null)
            {
                warning("Chưa chọn mã phim");
            }
            else
            {
                pass();
            }
        }

        public void check_LSC(ComboBox tb)
        {
            string str = null;
            try
            {
                str = tb.SelectedValue.ToString();
            }
            catch
            {

            }
            if (str == null)
            {
                warning("Chưa chọn loại suất chiếu");
            }
            else
            {
                pass();
            }
        }



//Check đăng ký suất chiếu


//Load hình ảnh
        private BitmapImage GetHinhAnhTuPoster(string _Poster)
        {
            BitmapImage bImg = new BitmapImage();
            Stream bm_Stream = new FileStream("../Debug/Image/" + _Poster, FileMode.Open);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            MemoryStream memoryStream = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create(bm_Stream));
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Save(memoryStream);
            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(memoryStream.ToArray());
            bImg.EndInit();
            memoryStream.Close();
            bm_Stream.Close();
            return bImg;
        }


    }
}
