using MySql.Data.MySqlClient;
using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Models
{
    public class MenuPageModel
    {
        private List<ChiTietHoaDon> chiTietHoaDons = new List<ChiTietHoaDon>();

        public List<ChiTietHoaDon> GetChiTietHoaDons()
        {
            return chiTietHoaDons;
        }
        public void addChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            chiTietHoaDons.Add(chiTietHoaDon);
        }
        public void removeChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            chiTietHoaDons.Remove(chiTietHoaDon);
        }
        public void clearChiTietHoaDons()
        {
            chiTietHoaDons.Clear();
        }

        public List<Mon> GetMons()
        {
            return Mons.GetAll();
        }
        public List<Mon> GetMons(string tenMon, int maDanhMuc)
        {
            Query query= Mons.select()
                .Join(DanhMuc_Mons.TableName, $"{Mons.TableName}.{Mons.MaMon} = {DanhMuc_Mons.TableName}.{DanhMuc_Mons.MaMon}")
                .Join(DanhMucs.TableName, $"{DanhMuc_Mons.TableName}.{DanhMuc_Mons.MaDM} = {DanhMucs.TableName}.{DanhMucs.MaDM}")
                .Where($"{DanhMucs.TableName}.{DanhMucs.MaDM} = {maDanhMuc} AND {Mons.TenMon} LIKE '%{tenMon}%'");

            MySqlDataReader reader = query.ExecuteToDataReader();
            if (reader == null) return new List<Mon>();
            return Mons.ToList(reader);
        }
        public List<Mon> GetMons(string tenMon)
        {
            Query query = Mons.select()
                .Where($" {Mons.TenMon} LIKE '%{tenMon}%'");

            MySqlDataReader reader = query.ExecuteToDataReader();
            if (reader == null) return new List<Mon>();
            return Mons.ToList(reader);
        }

    }
}
