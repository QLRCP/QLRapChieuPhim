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
using PUBLIC;
using BUL;

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for Giao_dien_xem_phieu_dat_ve.xaml
    /// </summary>
    public partial class Giao_dien_xem_phieu_dat_ve : Window
    {
        public Giao_dien_xem_phieu_dat_ve()
        {
            InitializeComponent();
            PhieuDatVe_BUL pdv_bul = new PhieuDatVe_BUL();
            cb_MaPDV.ItemsSource = pdv_bul.GetPDVTuMaKH(VarGlobal.g_KhachHangPub.MaKH);
            cb_MaPDV.DisplayMemberPath = "MaPDV";
            cb_MaPDV.SelectedValuePath = "MaPDV";
        }

        private void cb_MaPDV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhieuDatVe_BUL pdv_bul = new PhieuDatVe_BUL();
            string _MaPDV = cb_MaPDV.SelectedValue.ToString();
            PhieuDatVe_Pub pdv_pub = new PhieuDatVe_Pub();
             pdv_pub = pdv_bul.GetPDVTuMaPDV(_MaPDV);

            Phim_BUL phim_bul = new Phim_BUL();
            Phim_Pub _tempPhim = phim_bul.GetPhimTheoMaPhim(pdv_pub.TenPhim);

  
            lb_XuatGioChieu.Content = pdv_pub.GioChieu.ToShortTimeString();
            lb_XuatMaGheDat.Content = pdv_pub.MaGhe;
            lb_XuatNgayChieu.Content = pdv_pub.NgayChieu.ToShortDateString();
            lb_XuatNgayDatVe.Content = pdv_pub.NgayDatVe.ToShortDateString();
            lb_XuatPhongChieu.Content = pdv_pub.PhongChieu;
            lb_XuatTenPhim.Content = _tempPhim.TenPhim;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (cb_MaPDV.SelectedValue == null)
            {
                MessageBox.Show("Xin vui lòng chọn phiếu đặt vé để xóa");
            }
            else
            {
                PhieuDatVe_BUL pdv_bul = new PhieuDatVe_BUL();
                string _MaPDV = cb_MaPDV.SelectedValue.ToString();

                PhieuDatVe_Pub pdv_pub = new PhieuDatVe_Pub();
                pdv_pub = pdv_bul.GetPDVTuMaPDV(_MaPDV);

                pdv_bul.XoaPDVTuMaPDV(pdv_pub);

                MessageBox.Show("Xóa thành công - Nhấn OK để tiếp tục");

                this.Close();
            }
        }
    }
}
