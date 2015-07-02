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
    /// Interaction logic for Giao_dien_sua_suat_chieu.xaml
    /// </summary>
    public partial class Giao_dien_sua_suat_chieu : Window
    {
        List<SuatChieu_Pub> LsuatchieuPub;
        List<Phim_Pub> LphimPUB;
        List<PhongChieu_Pub> LpcPUB;
        List<LoaiSuatChieu_Pub> LlscPUB;
        string m_MaSC;
        public Giao_dien_sua_suat_chieu()
        {
            InitializeComponent();
            SuatChieu_BUL sc_BUL = new SuatChieu_BUL();

            LsuatchieuPub = sc_BUL.GetSuatChieu();
            cb_MaSC.ItemsSource = LsuatchieuPub;
            cb_MaSC.DisplayMemberPath = "MaSC";
            cb_MaSC.SelectedValuePath = "MaSC";


            for (int i = 0; i < 24; i++)
            {
                cb_Hour.Items.Add(i.ToString());
            }
            for (int i = 0; i < 4; i++)
            {
                cb_Minute.Items.Add((i * 15).ToString());
            }

            LoaiSuatChieu_BUL lsc_bul = new LoaiSuatChieu_BUL();
            LlscPUB = lsc_bul.GetLoaiSuatChieu();
            cb_LoaiSuatChieu.ItemsSource = LlscPUB;
            cb_LoaiSuatChieu.DisplayMemberPath = "ID";
            cb_LoaiSuatChieu.SelectedValuePath = "ID";

            Phim_BUL phim_bul = new Phim_BUL();
            PhongChieu_BUL pc_bul = new PhongChieu_BUL();

            LphimPUB = phim_bul.GetMaPhim();
            LpcPUB = pc_bul.GetPhongChieu();

            cb_TenPhongChieu.ItemsSource = LpcPUB;
            cb_TenPhongChieu.DisplayMemberPath = "MaPC";
            cb_TenPhongChieu.SelectedValuePath = "MaPC";

            cb_TenPhim.ItemsSource = LphimPUB;
            cb_TenPhim.DisplayMemberPath = "TenPhim";
            cb_TenPhim.SelectedValuePath = "MaPhim";

           

        }
        CheckNhapSC _checkNhap = new CheckNhapSC();
        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            KT_TaoSC();
            SuatChieu_BUL sc_bul = new SuatChieu_BUL();
            SuatChieu_Pub sc_pub = new SuatChieu_Pub();
            try
            {
                string str = cb_MaSC.SelectedItem.ToString();
           
            if (_checkNhap._warningMsg == "")
            {
                sc_pub.GioChieu = new DateTime(1, 1, 1, int.Parse(cb_Hour.Text), int.Parse(cb_Minute.Text), 0);
      //          sc_pub.GioChieu = new DateTime(1, 1, 1,1,1, 0);
                sc_pub.NgayChieu = datePicker_NgayChieu.SelectedDate.Value;
                sc_pub.LoaiSuatChieu = cb_LoaiSuatChieu.Text;
                sc_pub.TenPhim = cb_TenPhim.SelectedValue.ToString();
                sc_pub.PhongChieu = cb_TenPhongChieu.Text;
                sc_pub.Gia = float.Parse(tb_GiaVe.Text);
                sc_pub.MaSC = m_MaSC;
                sc_bul.Update(sc_pub);

                MessageBox.Show("Thay đổi thành công");
                this.Close();
            }
             else
             {
                 MessageBox.Show("Xin vui lòng xem lại thông tin đã sửa");
             }
            }
            catch
            {
                MessageBox.Show("Xin vui lòng chọn mã phim hoặc tên phim để sửa");
            }

        }

        private void cb_MaSC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string _MaSC = "";
            if (cb_MaSC.SelectedValue != null)
            {
                _MaSC = cb_MaSC.SelectedValue.ToString();
            }
            m_MaSC = _MaSC;
            SuatChieu_BUL sc_BUL = new SuatChieu_BUL();
            SuatChieu_Pub sc_PUB = sc_BUL.GetSuatChieuTheoMaSC(_MaSC);
            tb_GiaVe.Text = sc_PUB.Gia.ToString();
            datePicker_NgayChieu.SelectedDate = sc_PUB.NgayChieu;
            cb_Hour.SelectedValue = sc_PUB.GioChieu.Hour.ToString();
            cb_Minute.SelectedValue = sc_PUB.GioChieu.Minute.ToString();
            cb_TenPhim.SelectedValue = sc_PUB.TenPhim;
            cb_TenPhongChieu.SelectedValue = sc_PUB.PhongChieu;
            cb_LoaiSuatChieu.SelectedValue = sc_PUB.LoaiSuatChieu;
        }

        private void cb_LoaiSuatChieu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void KT_TaoSC()
        {
            _checkNhap.Check_Nhap(cb_MaSC, cb_Hour, cb_Minute, tb_GiaVe, cb_TenPhongChieu, cb_LoaiSuatChieu);

            
            warning_giave.Source = _checkNhap._giave._checkImage;
            warning_Label2.Content = _checkNhap._giave._warningMsg;


        }
    }
}
