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
    /// Interaction logic for Giao_dien_nhap_ve.xaml
    /// </summary>
    public partial class Giao_dien_nhap_ve : Window
    {
        Giao_dien_dang_nhap _dangnhap = new Giao_dien_dang_nhap();
       // List<Phim_Pub> _listPhim;
       // List<SuatChieu_Pub> _listSuatChieu;
        //List<Ghe_Pub> _listGhe;
        //List<PhongChieu_Pub> _listPhongChieu;

        public Giao_dien_nhap_ve()
        {
            InitializeComponent();

        }
        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void checkbox_2D_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_3D.IsChecked = false;
        }

        private void checkbox_3D_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_2D.IsChecked = false;
        }
    }
}
