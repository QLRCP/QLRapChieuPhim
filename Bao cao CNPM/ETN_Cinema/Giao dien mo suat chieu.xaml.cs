using PUBLIC;
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

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for Giao_dien_mo_suat_chieu.xaml
    /// </summary>
    public partial class Giao_dien_mo_suat_chieu : Window
    {
        List<Phim_Pub> LphimPUB;
        List<PhongChieu_Pub> LpcPUB;
        List<LoaiSuatChieu_Pub> LlscPUB;
        public Giao_dien_mo_suat_chieu()
        {
            InitializeComponent();
            for (int i = 0; i < 24; i++)
            {
                cb_Hour.Items.Add(i.ToString());
            }
            for (int i = 0; i < 4; i++)
            {
                cb_Minute.Items.Add((i * 15).ToString());
            }
            

            Phim_BUL phim_bul = new Phim_BUL();
            PhongChieu_BUL pc_bul = new PhongChieu_BUL();
            LoaiSuatChieu_BUL lsc_bul = new LoaiSuatChieu_BUL();
            
            LphimPUB = phim_bul.GetMaPhim();
            LpcPUB = pc_bul.GetPhongChieu();
            LlscPUB = lsc_bul.GetLoaiSuatChieu();

            cb_MaPhim.ItemsSource = LphimPUB;
            cb_MaPhim.DisplayMemberPath = "MaPhim";
            cb_MaPhim.SelectedValuePath = "MaPhim";

            cb_LoaiSuatChieu.ItemsSource = LlscPUB;
            cb_LoaiSuatChieu.DisplayMemberPath = "ID";
            cb_LoaiSuatChieu.SelectedValuePath = "ID";

            cb_TenPhongChieu.ItemsSource = LpcPUB;
            cb_TenPhongChieu.DisplayMemberPath = "TenPC";
            cb_TenPhongChieu.SelectedValuePath = "MaPC";

            datePicker_NgayChieu.SelectedDate = DateTime.Now;
            }

        CheckNhapSC _checkNhap=new CheckNhapSC();

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            KT_TaoSC();
            SuatChieu_BUL sc_bul = new SuatChieu_BUL();
            SuatChieu_Pub sc_pub = new SuatChieu_Pub();
            if (_checkNhap._warningMsg == "")
            {
                sc_pub.GioChieu = new DateTime(1, 1, 1, int.Parse(cb_Hour.Text), int.Parse(cb_Minute.Text), 0);
                sc_pub.NgayChieu = datePicker_NgayChieu.SelectedDate.Value;
                sc_pub.LoaiSuatChieu = cb_LoaiSuatChieu.SelectedValue.ToString();
                sc_pub.TenPhim = cb_MaPhim.SelectedValue.ToString();
                sc_pub.PhongChieu = cb_TenPhongChieu.SelectedValue.ToString();
                sc_pub.Gia = float.Parse(tb_GiaVe.Text.ToString());
                sc_bul.Insert(sc_pub);
                MessageBox.Show("Nhập thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Xin vui lòng xem lại thông tin đã nhập");
            }
        }

        private void cb_MaPhim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Phim_Pub phim_pub = new Phim_Pub();
            Phim_BUL phim_bul = new Phim_BUL();
        
            if (cb_MaPhim.SelectedValue != null )
            {
                phim_pub = phim_bul.GetPhimTheoMaPhim(cb_MaPhim.SelectedValue.ToString());
                lb_XuatTenPhim.Content = phim_pub.TenPhim;
            }
        }


        private void KT_TaoSC()
        {
            _checkNhap.Check_Nhap(cb_MaPhim,cb_Hour, cb_Minute, tb_GiaVe, cb_TenPhongChieu, cb_LoaiSuatChieu);

            warning_maphim.Source = _checkNhap._maphim._checkImage;
            warning_giochieu.Source = _checkNhap._giochieu._checkImage;
            warning_giave.Source = _checkNhap._giave._checkImage;
            warning_phongchieu.Source = _checkNhap._phongchieu._checkImage;
            warning_lsc.Source = _checkNhap._loaiSC._checkImage;

            warning_Label5.Content = _checkNhap._maphim._warningMsg;
            warning_Label1.Content = _checkNhap._giochieu._warningMsg;
            warning_Label2.Content = _checkNhap._giave._warningMsg;
            warning_Label3.Content = _checkNhap._phongchieu._warningMsg;
            warning_Label4.Content = _checkNhap._loaiSC._warningMsg;
         

        }
    }
}
