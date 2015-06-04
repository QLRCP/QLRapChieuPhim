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

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for Giao_dien_chinh_sua_nhan_vien.xaml
    /// </summary>
    public partial class Giao_dien_chinh_sua_nhan_vien : Window
    {
        private List<PhongBan_Pub> _LphongbanPub;
        FileStream stream;
        String _pathOld;
        int _index;
        public Giao_dien_chinh_sua_nhan_vien()
        {
            InitializeComponent();

            PhongBan_BUL _phongbanBUL = new PhongBan_BUL();

            _LphongbanPub = _phongbanBUL.GetPB();
            cbb_MaPB.ItemsSource = _LphongbanPub;
            cbb_MaPB.DisplayMemberPath = "TenPB";
            cbb_MaPB.SelectedValuePath = "MaPB";

            cbb_MaPB.SelectedIndex = -1;
            _index = GetIndex_BUL.GetIndex();
            datePicker_NamSinh.SelectedDate = DateTime.Now.AddYears(-20);
        }

        private void btn_ChonAnh_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            string filename;

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                filename = dlg.FileName;
                var uri = new Uri(filename);
                stream = new FileStream("../Debug/Image/" + (_index + 1) + ".png", FileMode.Create);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Interlace = PngInterlaceOption.On;
                encoder.Frames.Add(BitmapFrame.Create(uri));
                encoder.Save(stream);
                stream.Flush();
                stream.Close();
                filename = stream.Name;
                img_AnhNhanVien.Source = new BitmapImage(new Uri(dlg.FileName.ToString()));
                tb_LinkAnh.Text = (_index + 1).ToString() + ".png";
            }
        }

        private void checkBox_Nam_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox_Nam.IsChecked == true)
                checkBox_Nu.IsChecked = false;
        }

        private void checkBox_Nu_Checked(object sender, RoutedEventArgs e)
        {
            if(checkBox_Nu.IsChecked == true)
                checkBox_Nam.IsChecked = false;
        }


        private CheckNhap _checkNhap = new CheckNhap();

        private void KT_Nhap()
        {
            _checkNhap.Check_Nhap(tb_TenNhanVien, tb_SoDienThoai, tb_Email, tb_QueQuan, tb_DiaChi, tb_CMND, cbb_ChucVu, cbb_PhongBan, tb_LinkAnh);

            warning_Hoten.Source = _checkNhap._hoten._checkImage;
            warning_Diachi.Source = _checkNhap._diachi._checkImage;
            warning_Sdt.Source = _checkNhap._sdt._checkImage;
            warning_Email.Source = _checkNhap._email._checkImage;
            warning_Quequan.Source = _checkNhap._quequan._checkImage;
            warning_Cmnd.Source = _checkNhap._cmnd._checkImage;
            warning_CV.Source = _checkNhap._cv._checkImage;
            warning_PB.Source = _checkNhap._pb._checkImage;
            warning_Image.Source = _checkNhap._ava._checkImage;

            warning_Label9.Content = _checkNhap._ava._warningMsg;
            warning_Label1.Content = _checkNhap._hoten._warningMsg;
            warning_Label2.Content = _checkNhap._sdt._warningMsg;
            warning_Label3.Content = _checkNhap._email._warningMsg;
            warning_Label4.Content = _checkNhap._quequan._warningMsg;
            warning_Label5.Content = _checkNhap._diachi._warningMsg;
            warning_Label6.Content = _checkNhap._cmnd._warningMsg;
            warning_Label7.Content = _checkNhap._cv._warningMsg;
            warning_Label8.Content = _checkNhap._pb._warningMsg;
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            NhanVien_Pub _nhanvienPub = new NhanVien_Pub();
            NhanVien_BUL _nhanvienBUL = new NhanVien_BUL();
            KT_Nhap();            
            if(_checkNhap._warningMsg=="")
            {
                NhanVien_Pub _nhanvienPubTemp = new NhanVien_Pub();
                _nhanvienPubTemp = _nhanvienBUL.GetNV(cbb_MaNV.SelectedValue.ToString());
                _pathOld = _nhanvienPubTemp.HinhAnh.ToString();

                _nhanvienPub.MaNV = _nhanvienPubTemp.MaNV;
                _nhanvienPub.HoTen = tb_TenNhanVien.Text.ToString();
                _nhanvienPub.NamSinh = DateTime.Parse(datePicker_NamSinh.Text);
                if (checkBox_Nam.IsChecked == true)
                    _nhanvienPub.GioiTinh = true;
                else
                    _nhanvienPub.GioiTinh = false;
                _nhanvienPub.DienThoai = tb_SoDienThoai.Text.ToString();
                _nhanvienPub.Email = tb_Email.Text.ToString();
                _nhanvienPub.QueQuan = tb_QueQuan.Text.ToString();
                _nhanvienPub.DiaChi = tb_DiaChi.Text.ToString();
                _nhanvienPub.CMND = tb_CMND.Text.ToString();
                _nhanvienPub.MaCV = cbb_ChucVu.SelectedValue.ToString();
                _nhanvienPub.MaPB = cbb_PhongBan.SelectedValue.ToString();

                NhanVien_BUL _pnhanvienBUL1 = new NhanVien_BUL();
                NhanVien_Pub _nhanvienPubSwap = new NhanVien_Pub();

                _nhanvienPubSwap = _pnhanvienBUL1.GetNV(cbb_ChucVu.SelectedValue.ToString());

                _nhanvienPub.NgayVaoLam = DateTime.Parse(datePicker_NgayVaoLam.Text);
                _nhanvienPub.HinhAnh = tb_LinkAnh.Text;
                _nhanvienPub.MatKhau = _nhanvienPubTemp.MatKhau;


                if (_nhanvienPub.MaCV == "CV0001")
                {
                    _nhanvienBUL.ResetChucVu(cbb_PhongBan.SelectedValue.ToString());
                }

                _nhanvienBUL.Update(_nhanvienPub);

                if (_nhanvienPubTemp.HinhAnh != _pathOld)
                    GetIndex_BUL.SetIndex(_index + 1);
                MessageBox.Show("Chỉnh Sửa Thành Công - Nhấn OK để tiếp tục");
                this.Close();

            }
        else
            {
                MessageBox.Show("Xin vui lòng khiểm tra lại thông tin đã nhập");
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

        private void cbb_MaPB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string _maPB = null ;
            if (cbb_MaPB.SelectedValue.ToString() != null)
            {
                _maPB = cbb_MaPB.SelectedValue.ToString();

                List<NhanVien_Pub> _LnhanvienPub = new List<NhanVien_Pub>();
                NhanVien_BUL _nhanvienBUL = new NhanVien_BUL();

                if (cbb_MaPB.SelectedIndex != 0)
                {
                    _LnhanvienPub = _nhanvienBUL.GetNVTheoPB(_maPB);
                    cbb_MaNV.ItemsSource = _LnhanvienPub;
                    cbb_TenNV.ItemsSource = _LnhanvienPub; //combobox 2
                }
                else
                {
                    _LnhanvienPub = _nhanvienBUL.GetNVTheoPB("PB0001");
                    cbb_MaNV.ItemsSource = _LnhanvienPub;
                    cbb_TenNV.ItemsSource = _LnhanvienPub; //
                }
                cbb_MaNV.DisplayMemberPath = "MaNV";                //hiển thị tên lên Combobox
                cbb_MaNV.SelectedValuePath = "MaNV";

                cbb_TenNV.DisplayMemberPath = "HoTen";                //hiển thị tên lên Combobox
                cbb_TenNV.SelectedValuePath = "MaNV";

                if ((cbb_MaNV.SelectedIndex == -1) || (cbb_TenNV.SelectedIndex == -1))
                {
                    tb_TenNhanVien.Text = "";
                    datePicker_NamSinh.Text = "";

                    tb_SoDienThoai.Text = "";
                    tb_Email.Text = "";
                    tb_QueQuan.Text = "";
                    tb_DiaChi.Text = "";
                    tb_CMND.Text = "";
                    cbb_ChucVu.SelectedIndex = -1;
                    datePicker_NgayVaoLam.Text = "";

                    #region.Reset gioitinh
                    checkBox_Nam.IsChecked = false;
                    checkBox_Nu.IsChecked = false;

                    cbb_MaNV.SelectedIndex = 0;
                    cbb_TenNV.SelectedIndex = 0;
                }
                
            }
            #endregion
        }

        private void cbb_MaPB_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void cbb_MaNV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbb_TenNV.SelectedIndex != cbb_MaNV.SelectedIndex)
            {
                 cbb_TenNV.SelectedIndex=cbb_MaNV.SelectedIndex;
            }

            #region.Reset gioitinh
            checkBox_Nam.IsChecked = false;
            checkBox_Nu.IsChecked = false;
            #endregion

            NhanVien_Pub _nhanvienPub = new NhanVien_Pub();
            NhanVien_BUL _nhanvienBUL = new NhanVien_BUL();
            
            if(cbb_MaNV.SelectedValue != null)
            {
                this.btn_Submit.IsEnabled = true;
                this.btn_ChonAnh.IsEnabled = true;

                _nhanvienPub = _nhanvienBUL.GetNV(cbb_MaNV.SelectedValue.ToString());

                cbb_PhongBan.ItemsSource = _LphongbanPub;
                cbb_PhongBan.DisplayMemberPath = "TenPB";
                cbb_PhongBan.SelectedValuePath = "MaPB";
                cbb_PhongBan.SelectedValue = cbb_MaPB.SelectedValue;

                _pathOld = _nhanvienPub.HinhAnh;
                tb_LinkAnh.Text = _pathOld;
                #region.Fill data into textbox
                tb_TenNhanVien.Text = _nhanvienPub.HoTen;
                datePicker_NamSinh.Text = _nhanvienPub.NamSinh.ToShortDateString();
                if (_nhanvienPub.GioiTinh)
                    checkBox_Nam.IsChecked = true;
                else
                    checkBox_Nu.IsChecked = true;
                tb_SoDienThoai.Text = _nhanvienPub.DienThoai;
                tb_Email.Text = _nhanvienPub.Email;
                tb_QueQuan.Text = _nhanvienPub.QueQuan;
                tb_DiaChi.Text = _nhanvienPub.DiaChi;
                tb_CMND.Text = _nhanvienPub.CMND;

                NhanVien_BUL _pnhanvienBUL1 = new NhanVien_BUL();
                NhanVien_Pub _nhanvienPubSwap = new NhanVien_Pub();

                datePicker_NgayVaoLam.Text = _nhanvienPub.NgayVaoLam.ToShortDateString();
                img_AnhNhanVien.Source = GetHinhAnhTuPoster(_nhanvienPub.HinhAnh);

                List<ChucVu_Pub> _LchucvuPub = new List<ChucVu_Pub>();
                ChucVu_BUL _pchucvuBUL = new ChucVu_BUL();

                _LchucvuPub = _pchucvuBUL.GetCV();
                cbb_ChucVu.ItemsSource = _LchucvuPub;
                cbb_ChucVu.DisplayMemberPath = "TenCV";
                cbb_ChucVu.SelectedValuePath = "MaCV";
                cbb_ChucVu.SelectedValue = _nhanvienPub.MaCV;
                #endregion
            }
        }

        private void cbb_ChucVu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteNV(object sender, RoutedEventArgs e)
        {
            if (cbb_MaNV.SelectedIndex != -1)
            {
                if (VarGlobal.g_NhanVienPub.MaNV != cbb_MaNV.SelectedValue.ToString())
                {
                                    NhanVien_BUL _nhanvien = new NhanVien_BUL();
                _nhanvien.Delete(cbb_MaNV.SelectedValue.ToString());
                MessageBox.Show("Xóa Thành Công - Nhấn OK để tiếp tục");
                tb_TenNhanVien.Text = "";
                datePicker_NamSinh.Text = "";

                tb_SoDienThoai.Text = "";
                tb_Email.Text = "";
                tb_QueQuan.Text = "";
                tb_DiaChi.Text = "";
                tb_CMND.Text = "";
                cbb_ChucVu.SelectedIndex = -1;
                datePicker_NgayVaoLam.Text = "";
                checkBox_Nam.IsChecked = false;
                checkBox_Nu.IsChecked = false;
                cbb_MaNV.SelectedIndex = cbb_MaNV.SelectedIndex - 1;
                }
                else
                {
                    MessageBox.Show("Không Thể Xóa Chính Mình - Nhấn OK để tiếp tục");
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Nhân Viên - Nhấn OK để tiếp tục");
            }
        }


        private void cbb_TenNV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             if (cbb_TenNV.SelectedIndex!=cbb_MaNV.SelectedIndex)
             {
                 cbb_MaNV.SelectedIndex = cbb_TenNV.SelectedIndex;
             }
        }


    }
}