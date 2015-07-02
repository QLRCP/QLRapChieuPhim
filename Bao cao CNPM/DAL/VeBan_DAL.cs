using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VeBan_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();



        public VeBan_DAL()
        {
            m_sqlConnect.connect();
        }

        public String GetMa(string _startString, int m_Index)
        {

            if (m_Index <= 0)
            {
                return _startString + "000" + 1;
            }
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

        public void Insert(VeBan_Pub _info)
        {
            int _index = GetIndex_DAL.GetIndexVeBan();
            _info.MaVe = GetMa("VE", _index + 1);
            string insertCommand = @"INSERT INTO  VEBAN(MAVE, MANV, MAKH, MAGHE, MASC, GIAVE,NGAYCHIEU,GIOCHIEU,TENPHIM, LOAISC, PHONGCHIEU) VALUES('" +
                _info.MaVe + "', '" +
                _info.MaNV + "', '" +
                _info.MaKH + "', '" +
                _info.MaGhe + "', '" +
                _info.MaSC + "', '" +

                _info.GiaVe + "', '" +
                _info.NgayChieu.ToShortDateString() + "', '" +
                _info.GioChieu.ToShortTimeString() + "', N'" +
                _info.TenPhim + "', '" +
                 _info.LoaiSC + "', '" +
                _info.PhongChieu + "')";

            m_sqlConnect.executeNonQuery(insertCommand);

            GetIndex_DAL.SetIndexVeBan(_index + 1);

        }

        public List<VeBan_Pub> GetVeTuLoaiSCvaTenPhim(string _LoaiSC, string _TenPhim)
        {
            List<VeBan_Pub> LvebanPUb = new List<VeBan_Pub>();
            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@_LoaiSC", _LoaiSC));
            Lparameter.Add(new SqlParameter("@_TenPhim", _TenPhim));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("[GetVeTuLoaiSCvaTenPhim]", Lparameter);

            while (reader.Read())
            {
                VeBan_Pub result = new VeBan_Pub();
                result.MaVe = reader["MaVe"].ToString();
                result.MaGhe = reader["MaGhe"].ToString();
                result.GiaVe = float.Parse(reader["GiaVe"].ToString());
                result.LoaiSC = reader["LoaiSC"].ToString();
                result.NgayChieu = DateTime.Parse(reader["NgayChieu"].ToString());
                result.GioChieu = DateTime.Parse(reader["GioChieu"].ToString());
                result.TenPhim = reader["TenPhim"].ToString();
                result.PhongChieu = reader["PhongChieu"].ToString();
                // result.MaPDV = reader["MaPDV"].ToString();
                result.MaKH = reader["MaKH"].ToString();
                result.MaNV = reader["MaNV"].ToString();
                result.MaSC = reader["MaSC"].ToString();
                LvebanPUb.Add(result);
            }

            reader.Close();
            return LvebanPUb;
        }
    }
}
