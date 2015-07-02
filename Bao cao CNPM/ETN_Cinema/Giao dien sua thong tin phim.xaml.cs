using BUL;
using Microsoft.Win32;
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

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for Giao_dien_xem_thong_tin_phim.xaml
    /// </summary>
    public partial class Giao_dien_sua_thong_tin_phim : Window
    {
        List<Phim_Pub> LphimPUB;
        List<TheLoaiPhim_Pub> LtlPUB;
        Uri filmPosterURI;
        string m_Poster = "";
        public Giao_dien_sua_thong_tin_phim()
        {
            InitializeComponent();
            Phim_BUL phim_bul = new Phim_BUL();
            LphimPUB = phim_bul.GetMaPhim();
            cb_MaPhim.ItemsSource = LphimPUB;
            cb_MaPhim.DisplayMemberPath = "MaPhim";
            cb_MaPhim.SelectedValuePath = "MaPhim";
            cb_TenPhim.ItemsSource = LphimPUB;
            cb_TenPhim.DisplayMemberPath = "TenPhim";
            cb_TenPhim.SelectedValuePath = "MaPhim";
            TheLoaiPhim_BUL tl_bul = new TheLoaiPhim_BUL();
            LtlPUB = tl_bul.GetTheLoai();
 
            cb_XuatTheLoai.ItemsSource = LtlPUB;
            cb_XuatTheLoai.DisplayMemberPath = "TenLP";
            cb_XuatTheLoai.SelectedValuePath = "MaLP";
            cb_XuatTheLoai.SelectedItem = LtlPUB[LtlPUB.Count - 1];
            ManageInput(false);
            //btn_ChonAnh.Visibility = System.Windows.Visibility.Hidden;
        }

        private void cb_MaPhim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_TenPhim.SelectedIndex != cb_MaPhim.SelectedIndex)
                cb_TenPhim.SelectedIndex = cb_MaPhim.SelectedIndex;
            

            string _MaPhim = "";
            if (cb_MaPhim.SelectedValue != null)
            {
                _MaPhim = cb_MaPhim.SelectedValue.ToString();
            }
            Phim_BUL phim_bul = new Phim_BUL();
            ManageLabelXuat(true);
            ManageInput(true);
            if (_MaPhim != "")
            {
                
                Phim_Pub _tempPhim = phim_bul.GetPhimTheoMaPhim(_MaPhim);
                lb_XuatTenPhim.Text = _tempPhim.TenPhim;
                //lb_XuatTheLoai.Content = _tempPhim.TheLoai;
                lb_XuatNoiDung.Text = _tempPhim.NoiDung;
                lb_XuatNuocSanXuat.Text = _tempPhim.NuocSanXuat;
                lb_XuatThoiLuong.Text = _tempPhim.ThoiLuong.ToString();
                lb_XuatDoTuoiQuyDinh.Text = _tempPhim.TuoiQuyDinh.ToString();
                lb_XuatDaoDien.Text = _tempPhim.DaoDien;
                lb_XuatDienVien.Text = _tempPhim.DienVien;
                //lb_XuatNamPhatHanh.Content = _tempPhim.NamPhatHanh.Year;
                cb_XuatTheLoai.SelectedValue = _tempPhim.TheLoai;
                datepicker_NgayKhoiChieu.SelectedDate = _tempPhim.NgayChieu;
                lb_XuatNamPhatHanh.Text = _tempPhim.NamPhatHanh.ToString();
                //lb_XuatNgayKhoiChieu.Content = _tempPhim.NgayChieu.ToShortDateString();
                img_Poster.Source = GetHinhAnhTuPoster(_tempPhim.Poster);
                m_Poster = _tempPhim.Poster;
            }
        }

        private BitmapImage GetHinhAnhTuPoster(string _Poster)
        {
            BitmapImage bImg = new BitmapImage();
            Stream bm_Stream = new FileStream("../Debug/Image/Film Poster/" + _Poster, FileMode.Open);
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



        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            KT_NhapPhim();
            if (_checkNhap._warningMsg == "")
            {
            Phim_Pub phim_pub = new Phim_Pub();
            Phim_BUL phim_bul = new Phim_BUL();

            phim_pub.MaPhim = cb_MaPhim.SelectedValue.ToString();
            phim_pub.TenPhim = lb_XuatTenPhim.Text;
            phim_pub.NgayChieu = datepicker_NgayKhoiChieu.SelectedDate.Value;
            phim_pub.NamPhatHanh = int.Parse(lb_XuatNamPhatHanh.Text);
            phim_pub.NoiDung = lb_XuatNoiDung.Text;
            phim_pub.NuocSanXuat = lb_XuatNuocSanXuat.Text;
            phim_pub.DaoDien = lb_XuatDaoDien.Text;
            phim_pub.DienVien = lb_XuatDienVien.Text;
            phim_pub.ThoiLuong = int.Parse(lb_XuatThoiLuong.Text);
            phim_pub.TuoiQuyDinh = int.Parse(lb_XuatDoTuoiQuyDinh.Text);
            phim_pub.TheLoai = cb_XuatTheLoai.SelectedValue.ToString();
            phim_pub.Poster = m_Poster;
            if (filmPosterURI != null)
            {
                UpdatePoster(filmPosterURI, m_Poster);
            }

            phim_bul.Update(phim_pub);
            MessageBox.Show("Thay đổi thành công");
            }
            else
            {
                MessageBox.Show("Xin vui lòng xem lại chính xác thông tin phim");
            }

        }

        private void UpdatePoster(Uri _uri, string _Index)
        {
            FileStream stream = new FileStream("../Debug/Image/Film Poster/" + _Index, FileMode.Create);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            //TextBlock myTextBlock = new TextBlock();
            //myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Frames.Add(BitmapFrame.Create(_uri));
            encoder.Save(stream);
            stream.Flush();
            stream.Close();
        }

        private void cb_TheLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Phim_Pub> m_ListFilm;
            string TheLoai = cb_XuatTheLoai.SelectedValue.ToString();
            cb_MaPhim.ItemsSource = null;
            ManageLabelXuat(true);
            ManageInput(false);
            Phim_BUL phim_bul = new Phim_BUL();
            m_ListFilm = phim_bul.GetMaPhimTheoTheLoai(TheLoai);
            cb_MaPhim.ItemsSource = m_ListFilm;
            cb_MaPhim.DisplayMemberPath = "MaPhim";
            cb_MaPhim.SelectedValuePath = "MaPhim";
        }

        private void btn_ChonAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            string fileLink;
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";

            Nullable<bool> result = dlg.ShowDialog();
            if (result != null)
            {
                fileLink = dlg.FileName;
                if (fileLink != "")
                {
                    filmPosterURI = new Uri(fileLink);
                    img_Poster.Source = new BitmapImage(filmPosterURI);
                } 
            }

        }

        private void ManageLabelXuat(bool _Input)
        {
            if (_Input)
            {
                lb_XuatDaoDien.Text = "";
                lb_XuatDienVien.Text = "";
                lb_XuatDoTuoiQuyDinh.Text = "";
                //lb_XuatNamPhatHanh.Content = "";
                //lb_XuatNgayKhoiChieu.Content = "";
                lb_XuatNoiDung.Text = "";
                lb_XuatNuocSanXuat.Text = "";
                lb_XuatTenPhim.Text = "";
                lb_XuatThoiLuong.Text = "";
                cb_XuatTheLoai.SelectedItem = null;
                img_Poster.Source = null;
                datepicker_NgayKhoiChieu.SelectedDate = null;
                lb_XuatNamPhatHanh.Text = null;
                //lb_XuatTheLoai.Content = "";
            }
        }

        private void ManageInput(bool _Enable)
        {
            if (_Enable)
            {
                cb_XuatTheLoai.Visibility = System.Windows.Visibility.Visible;
                btn_ChonAnh.Visibility = System.Windows.Visibility.Visible;
                lb_xuatTheLoai.Visibility = System.Windows.Visibility.Visible;
                lb_XuatThoiLuong.Visibility = System.Windows.Visibility.Visible;
                lb_XuatNamPhatHanh.Visibility = System.Windows.Visibility.Visible;
                datepicker_NgayKhoiChieu.Visibility = System.Windows.Visibility.Visible;
                lb_XuatDaoDien.Visibility = System.Windows.Visibility.Visible;
                lb_XuatDienVien.Visibility = System.Windows.Visibility.Visible;
                lb_XuatDoTuoiQuyDinh.Visibility = System.Windows.Visibility.Visible;
                lb_XuatNoiDung.Visibility = System.Windows.Visibility.Visible;
                lb_XuatNuocSanXuat.Visibility = System.Windows.Visibility.Visible;
                lb_XuatTenPhim.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                cb_XuatTheLoai.Visibility = System.Windows.Visibility.Hidden;
                btn_ChonAnh.Visibility = System.Windows.Visibility.Hidden;
                lb_xuatTheLoai.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatThoiLuong.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatNamPhatHanh.Visibility = System.Windows.Visibility.Hidden;
                datepicker_NgayKhoiChieu.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatDaoDien.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatDienVien.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatDoTuoiQuyDinh.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatNoiDung.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatNuocSanXuat.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatTenPhim.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void cb_TenPhim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                   if (cb_MaPhim.SelectedIndex != cb_TenPhim.SelectedIndex)            
            cb_MaPhim.SelectedIndex = cb_TenPhim.SelectedIndex;
        }
        private CheckNhapPhim _checkNhap = new CheckNhapPhim();
        private void KT_NhapPhim()
        {
            _checkNhap.Check_Nhap(lb_XuatTenPhim, cb_XuatTheLoai, lb_XuatNoiDung, lb_XuatThoiLuong, lb_XuatDienVien, lb_XuatDaoDien, lb_XuatNuocSanXuat, lb_XuatDoTuoiQuyDinh, lb_XuatNamPhatHanh, filmPosterURI);

            warning_Tenphim.Source = _checkNhap._ten._checkImage;
            warning_Theloai.Source = _checkNhap._theloai._checkImage;
            warning_Noidung.Source = _checkNhap._noidung._checkImage;
            warning_Thoiluong.Source = _checkNhap._thoiluong._checkImage;
            warning_Dienvien.Source = _checkNhap._dienvien._checkImage;
            warning_Daodien.Source = _checkNhap._daodien._checkImage;
            warning_Nuocsx.Source = _checkNhap._nuocsx._checkImage;
            warning_Tuoi.Source = _checkNhap._tuoiquydinh._checkImage;
            warning_Namphathanh.Source = _checkNhap._namphathanh._checkImage;
            warning_Poster.Source = _checkNhap._poster._passIcon;

            _checkNhap._poster._warningMsg = null;

            warning_Label1.Content = _checkNhap._ten._warningMsg;
            warning_Label10.Content = _checkNhap._theloai._warningMsg;
            warning_Label2.Content = _checkNhap._noidung._warningMsg;
            warning_Label3.Content = _checkNhap._thoiluong._warningMsg;
            warning_Label4.Content = _checkNhap._dienvien._warningMsg;
            warning_Label5.Content = _checkNhap._daodien._warningMsg;
            warning_Label6.Content = _checkNhap._nuocsx._warningMsg;
            warning_Label7.Content = _checkNhap._tuoiquydinh._warningMsg;
            warning_Label8.Content = _checkNhap._namphathanh._warningMsg;
            warning_Label9.Content = _checkNhap._poster._warningMsg;

            _checkNhap._warningMsg = _checkNhap._ten._warningMsg + _checkNhap._theloai._warningMsg + _checkNhap._noidung._warningMsg + _checkNhap._thoiluong._warningMsg +
                _checkNhap._dienvien._warningMsg + _checkNhap._daodien._warningMsg
     + _checkNhap._nuocsx._warningMsg +
           _checkNhap._tuoiquydinh._warningMsg +
            _checkNhap._namphathanh._warningMsg +
             _checkNhap._poster._warningMsg;

        }

        private void DeletePhim(object sender, RoutedEventArgs e)
        {
            Phim_BUL _phim = new Phim_BUL();
            _phim.Delete(cb_MaPhim.SelectedValue.ToString());
            MessageBox.Show("Xóa Thành Công - Nhấn OK để tiếp tục");
            this.Close();
        }

    }
}
