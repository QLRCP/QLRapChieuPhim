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
    class CheckNhap
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
            _ava.check_Image(ava);
            _cmnd = new CheckNhapTB();
            _cmnd.check_cmnd(cmnd);
            _warningMsg = _hoten._warningMsg + _sdt._warningMsg + _email._warningMsg + _quequan._warningMsg + _diachi._warningMsg + _cmnd._warningMsg + _cv._warningMsg + _pb._warningMsg + _ava._warningMsg;
            
        }

    }



    class CheckNhapTB
    {
        private BitmapImage _warningIcon;
        private BitmapImage _passIcon;
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

    
        public void check_Hoten(TextBox tb_Hoten)
        {

            if (tb_Hoten.Text.ToString() == "")
            {
                warning("Họ tên không được để trống");
            }
            else
                if (_is_have_Number(tb_Hoten.Text.ToString()))
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
                pass();
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

        public void check_Image(TextBlock tb)
        {
            try{               
            BitmapImage bm  = GetHinhAnhTuPoster(tb.Text.ToString());
            pass();            
            }
            catch
            {
                warning("Chưa chọn ảnh đại diện");
            }
        }


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
