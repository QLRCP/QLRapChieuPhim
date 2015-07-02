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
    /// Interaction logic for Giao_dien_nhap_khuyen_mai.xaml
    /// </summary>
    public partial class Giao_dien_nhap_khuyen_mai : Window
    {
        public Giao_dien_nhap_khuyen_mai()
        {
            InitializeComponent();
            datepicker_NgayKetThuc.SelectedDate = DateTime.Now;
            datepicker_NgayBatDau.SelectedDate = DateTime.Now;
           
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            KT_NhapKM();

            if (_checkNhap._warningMsg == "")
            {
            KhuyenMai_Pub km_pub = new KhuyenMai_Pub();
            KhuyenMai_BUL km_bul = new KhuyenMai_BUL();

            HeSoKM_BUL hskm_bul = new HeSoKM_BUL();
            HeSoKM_Pub hskm_pub1 = new HeSoKM_Pub();
            HeSoKM_Pub hskm_pub2 = new HeSoKM_Pub();
            HeSoKM_Pub hskm_pub3 = new HeSoKM_Pub();
            HeSoKM_Pub hskm_pub4 = new HeSoKM_Pub();
            
            km_pub.TenKM = tb_TenKM.Text;
            km_pub.NgayBatDau = datepicker_NgayBatDau.SelectedDate.Value;
            km_pub.NgayKetThuc = datepicker_NgayKetThuc.SelectedDate.Value;
            km_pub.NoiDung = tb_NoiDungKM.Text;
          

            hskm_pub1.HeSoKM = float.Parse(tb_LoaiKHMoi.Text);
            hskm_pub2.HeSoKM = float.Parse(tb_LoaiKHTT.Text);
            hskm_pub3.HeSoKM = float.Parse(tb_LoaiKHVIP.Text);
            hskm_pub4.HeSoKM = float.Parse(tb_LoaiKHBT.Text);

            hskm_pub1.MaKM = GetMa("KM", GetIndex_BUL.GetIndexKhuyenMai());
            hskm_pub2.MaKM = GetMa("KM", GetIndex_BUL.GetIndexKhuyenMai());
            hskm_pub3.MaKM = GetMa("KM", GetIndex_BUL.GetIndexKhuyenMai());
            hskm_pub4.MaKM = GetMa("KM", GetIndex_BUL.GetIndexKhuyenMai());
            km_bul.Insert(km_pub);

            hskm_pub1.TenLoaiKH = "LK0001";
            hskm_pub2.TenLoaiKH = "LK0002";
            hskm_pub3.TenLoaiKH = "LK0003";
            hskm_pub4.TenLoaiKH = "LK0004";

            hskm_bul.Insert(hskm_pub1);
            hskm_bul.Insert(hskm_pub2);
            hskm_bul.Insert(hskm_pub3);
            hskm_bul.Insert(hskm_pub4);

           
            MessageBox.Show("Nhập khuyến mãi thành công");
            this.Close();

            }
            else
            {
                MessageBox.Show("Xin xem lại thông tin đã nhập");

            }
        }

        public string GetMa(string _startString, int m_Index)
        {
            if (m_Index < 10)
            {
                return _startString + "000" + m_Index;
            }
            else
            {
                if (m_Index < 100)
                {
                    return _startString + "00" + m_Index;
                }
                else
                {
                    if (m_Index < 1000)
                    {
                        return _startString + "0" + m_Index;
                    }
                    else
                    {
                        return _startString + m_Index;
                    }
                }
            }
        }


        private void datepicker_NgayKetThuc_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(datepicker_NgayKetThuc.SelectedDate<datepicker_NgayBatDau.SelectedDate)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu");
                datepicker_NgayKetThuc.SelectedDate = datepicker_NgayBatDau.SelectedDate;

            }
        }



        private CheckNhapKM _checkNhap = new CheckNhapKM();

        private void KT_NhapKM()
        {
            _checkNhap.Check_Nhap(tb_TenKM, tb_NoiDungKM, tb_LoaiKHMoi, tb_LoaiKHTT, tb_LoaiKHVIP, tb_LoaiKHBT);
            warning1.Source = _checkNhap._tb1._checkImage;
            warning2.Source = _checkNhap._tb2._checkImage;
            warning3.Source = _checkNhap._tb3._checkImage;
            warning4.Source = _checkNhap._tb4._checkImage;
            warning5.Source = _checkNhap._tb5._checkImage;
            warning6.Source = _checkNhap._tb6._checkImage;



            warning_Label1.Content = _checkNhap._tb1._warningMsg;
            warning_Label2.Content = _checkNhap._tb2._warningMsg;
            warning_Label3.Content = _checkNhap._tb3._warningMsg;
            warning_Label4.Content = _checkNhap._tb4._warningMsg;
            warning_Label5.Content = _checkNhap._tb5._warningMsg;
            warning_Label6.Content = _checkNhap._tb6._warningMsg;


        }

    }
}
