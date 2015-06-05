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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyException m_Exception;
        List<TheLoaiPhim_Pub> LtlPUB;
        Uri filmPosterURI;
        //string filename;
        public MainWindow()
        {
            InitializeComponent();
            TheLoaiPhim_BUL tl_bul = new TheLoaiPhim_BUL();
            LtlPUB = tl_bul.GetTheLoai();
            cb_TheLoai.ItemsSource = LtlPUB;
            cb_TheLoai.DisplayMemberPath = "TenLP";
            cb_TheLoai.SelectedValuePath = "MaLP";
            lb_MaNV.Content = VarGlobal.g_NhanVienPub.MaNV;
            lb_TenNV.Content = VarGlobal.g_NhanVienPub.HoTen; ;
            datepicker_NgayKhoiChieu.SelectedDate = DateTime.Now;

        }

        //private string IncreaseIndexBy1(string _StringInput, string _StartIndex)
        //{
        //    string result = "";
        //    if (_StringInput == "")
        //    {
        //        result = _StartIndex + "1";
        //    }
        //    else
        //    {
        //        result = _StartIndex + _StringInput;
        //    }
        //    return result;
        //}

        private CheckNhapPhim _checkNhap = new CheckNhapPhim();

        private void KT_NhapPhim()
        {
            _checkNhap.Check_Nhap(tb_TenPhim, cb_TheLoai, tb_NoiDung, tb_ThoiLuong, tb_DienVien, tb_DaoDien, tb_NuocSanXuat, tb_DoTuoiQuyDinh, tb_NamPhatHanh, filmPosterURI);

            warning_Tenphim.Source = _checkNhap._ten._checkImage;
            warning_Theloai.Source = _checkNhap._theloai._checkImage;
            warning_Noidung.Source = _checkNhap._noidung._checkImage;
            warning_Thoiluong.Source = _checkNhap._thoiluong._checkImage;
            warning_Dienvien.Source = _checkNhap._dienvien._checkImage;
            warning_Daodien.Source = _checkNhap._daodien._checkImage;
            warning_Nuocsx.Source = _checkNhap._nuocsx._checkImage;
            warning_Tuoi.Source = _checkNhap._tuoiquydinh._checkImage;
                 warning_Namphathanh.Source = _checkNhap._namphathanh._checkImage;
            warning_Poster.Source = _checkNhap._poster._checkImage;
 
            
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

        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            Phim_Pub phim = new Phim_Pub();
            Phim_BUL phim_bul = new Phim_BUL();
            //Phim_BUL phim_reader = new Phim_BUL();
            //m_Exception.ShowMessageBox();
            KT_NhapPhim();

            if (_checkNhap._warningMsg == "")
            {
            
                    phim.DaoDien = tb_DaoDien.Text;
                    phim.DienVien = tb_DienVien.Text;
                    phim.TenPhim = tb_TenPhim.Text;
                    phim.TheLoai = cb_TheLoai.SelectedValue.ToString();
                    phim.NgayChieu = datepicker_NgayKhoiChieu.SelectedDate.Value;
                    phim.NamPhatHanh = int.Parse(tb_NamPhatHanh.Text);
                    //phim.Poster = filename;
                    phim.Poster = GetIndex_BUL.GetIndexPhim().ToString() + ".png";
                    phim.ThoiLuong = int.Parse(tb_ThoiLuong.Text);
                    phim.NoiDung = tb_NoiDung.Text;
                    phim.NuocSanXuat = tb_NuocSanXuat.Text;
                    phim.TuoiQuyDinh = int.Parse(tb_DoTuoiQuyDinh.Text);
                  
                    CreatePoster(filmPosterURI);
                   
                    phim_bul.Insert(phim);
                    MessageBox.Show("Nhập thành công");
                    this.Close();
                }
            else
            {
                MessageBox.Show("Xin vui lòng nhập lại chính xác thông tin phim");
            }
          
        }

        private void CreatePoster(Uri _uri)
        {
            FileStream stream = new FileStream("../Debug/Image/Film Poster/" + GetIndex_BUL.GetIndexPhim().ToString() + ".png", FileMode.Create);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            //TextBlock myTextBlock = new TextBlock();
            //myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Frames.Add(BitmapFrame.Create(_uri));
            encoder.Save(stream);
            stream.Flush();
            stream.Close();
        }

        private void btn_ChonAnh_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            string fileLink;
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            //Image tempImage = new Image();
            // Get the selected file name and display in a TextBox 

            if (result != null)
            {
                fileLink = dlg.FileName;
                try
                {
                    filmPosterURI = new Uri(fileLink);
                    img_Poster.Source = new BitmapImage(filmPosterURI);
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn file ảnh");
                }
            }
            ////tempImage.Source = new BitmapImage(uri);
            ////if (tempImage.Source.Height > 800)
            ////{
            ////    throw new Exception("Thằng Lép nhiều chuyện vl");
            ////}
            ////save hình
            //FileStream stream = new FileStream("../Debug/Image/" + GetIndex_BUL.GetIndexPhim().ToString() + ".png", FileMode.Create);
            //PngBitmapEncoder encoder = new PngBitmapEncoder();
            ////TextBlock myTextBlock = new TextBlock();
            ////myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            //encoder.Interlace = PngInterlaceOption.On;
            //encoder.Frames.Add(BitmapFrame.Create(uri));
            //encoder.Save(stream);
            //stream.Flush();
            //stream.Close();
            //img_Poster.Source = new BitmapImage(new Uri(stream.Name));
            //filename = stream.Name;
            //tb_LinkAnh.Text = filename;
        }
    }
}
