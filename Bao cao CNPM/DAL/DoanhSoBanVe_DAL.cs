using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBLIC;
using System.Data.SqlClient;

namespace DAL
{
    public class DoanhSoBanVe_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public DoanhSoBanVe_DAL()
        {
            m_sqlConnect.connect();
        }

        public void DeleteTable()
        {
            string deleteCommand = "DELETE FROM DOANHSOBANVE";
            m_sqlConnect.executeNonQuery(deleteCommand);
            GetIndex_DAL.SetSTT(1);
        }

        public void Insert(DoanhSoBanVe_Pub _info)
        {
            _info.SoTT = GetIndex_DAL.GetSTT();


            string insertCommand = @"INSERT INTO  DOANHSOBANVE(STT, MAPHIM, LOAISC, SOLUONG, DOANHSO) VALUES('" +
                _info.SoTT + "', '" +
                _info.TenPhim + "', '" +
                _info.LoaiSC + "', '" +
                _info.SoLuong + "', '" +
                _info.DoanhSo + "')";

            m_sqlConnect.executeNonQuery(insertCommand);

            GetIndex_DAL.SetSTT(GetIndex_DAL.GetSTT() + 1);
        }
    }
}
