using System;
using System.Collections.Generic;
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
using BUL;
using PUBLIC;

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for Giao_dien_sua_thong_tin_khach_hang.xaml
    /// </summary>

    public partial class Giao_dien_sua_thong_tin_khach_hang : Window
    {
        List<MyGioiTinh> list;
        
        public Giao_dien_sua_thong_tin_khach_hang()
        {
            
            InitializeComponent();
            lb_XuatCMND.Text = VarGlobal.g_KhachHangPub.CMND;
            lb_XuatDiaChi.Text = VarGlobal.g_KhachHangPub.DiaChi;
            lb_XuatEmail.Text = VarGlobal.g_KhachHangPub.Email;
            lb_XuatMaKH.Content = VarGlobal.g_KhachHangPub.MaKH;
            lb_XuatSDT.Text = VarGlobal.g_KhachHangPub.SoDT;
            lb_XuatHoTen.Text = VarGlobal.g_KhachHangPub.HoTen;
            datepicker_NgaySinh.SelectedDate = DateTime.Now;

            list = new List<MyGioiTinh>();
            MyGioiTinh Nam = new MyGioiTinh("Nam", true);
            MyGioiTinh Nu = new MyGioiTinh("Nữ", false);

            list.Add(Nam);
            list.Add(Nu);
            cb_GioiTinh.ItemsSource = list;
            cb_GioiTinh.SelectedValuePath = "Sex";
            cb_GioiTinh.DisplayMemberPath = "Name";
            if (VarGlobal.g_KhachHangPub.GioiTinh)
            {
                cb_GioiTinh.SelectedItem = list[0];
            }
            else
            {
                cb_GioiTinh.SelectedItem = list[1];
            }
            datepicker_NgaySinh.SelectedDate = VarGlobal.g_KhachHangPub.NamSinh;

        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            KT_Nhap();
             if (_checkNhap._warningMsg == "")
            {
            VarGlobal.g_KhachHangPub.CMND = lb_XuatCMND.Text;
            VarGlobal.g_KhachHangPub.DiaChi = lb_XuatDiaChi.Text;
            VarGlobal.g_KhachHangPub.Email = lb_XuatEmail.Text;
            VarGlobal.g_KhachHangPub.SoDT = lb_XuatSDT.Text;
            VarGlobal.g_KhachHangPub.HoTen = lb_XuatHoTen.Text;
            VarGlobal.g_KhachHangPub.GioiTinh = (bool)cb_GioiTinh.SelectedValue;
            VarGlobal.g_KhachHangPub.NamSinh = datepicker_NgaySinh.SelectedDate.Value;
            KhachHang_BUL kh_bul = new KhachHang_BUL();
            kh_bul.Update(VarGlobal.g_KhachHangPub);
            MessageBox.Show("Thay đổi thông tin thành công!");
            this.Close();
            }
             else
             {
                 MessageBox.Show("Xin xem lại thông tin đã nhập");

             }
        }


        private CheckNhapKH _checkNhap = new CheckNhapKH();

        private void KT_Nhap()
        {
            _checkNhap.Check_Nhap(lb_XuatHoTen, lb_XuatSDT, lb_XuatEmail, lb_XuatDiaChi, lb_XuatCMND);

            warning_Hoten.Source = _checkNhap._hoten._checkImage;
            warning_Diachi.Source = _checkNhap._diachi._checkImage;
            warning_Sdt.Source = _checkNhap._sdt._checkImage;
            warning_Email.Source = _checkNhap._email._checkImage;
            warning_Cmnd.Source = _checkNhap._cmnd._checkImage;
            warning_Label1.Content = _checkNhap._hoten._warningMsg;
            warning_Label2.Content = _checkNhap._sdt._warningMsg;
            warning_Label3.Content = _checkNhap._email._warningMsg;
            warning_Label5.Content = _checkNhap._diachi._warningMsg;
            warning_Label6.Content = _checkNhap._cmnd._warningMsg;

        }

    }
}
