using PBL2.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class OrderModel
    {
        public string MaHD { get; set; }
        public List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();

        public decimal Total
        {
            get { return orderDetails.Sum(x => x.tongTien); }
            private set { }
        }

        public OrderModel() { }

        public OrderModel(HoaDon hd) 
        {
            this.MaHD = hd.MaHD;
            this.orderDetails = new List<OrderDetailModel>();
            DataTable dt = MySQL_DB.Instance.Select("chitiethoadon", $"MaHD = '{hd.MaHD}'");
            foreach (DataRow row in dt.Rows)
            {
                OrderDetailModel orderDetail = new OrderDetailModel();
                try
                {
                    //mon model
                    MonModel mon = new MonModel();
                    DataTable dtmon = MySQL_DB.Instance.Select("mon", "*", $"MaMon = '{row["MaMon"]}' LIMIT 1");
                    foreach (DataRow rowmon in dtmon.Rows)
                    {
                        mon.MaMon = Convert.ToInt32(rowmon["MaMon"]);
                        mon.TenMon = rowmon["TenMon"].ToString();
                        mon.GiaBan = Convert.ToDecimal(rowmon["GiaBan"]);
                        mon.DonVi = rowmon["DonVi"].ToString();
                        mon.URLImage = rowmon["URL_anh"].ToString();
                    }
                    orderDetail.monModel = mon;
                    orderDetail.soLuong = Convert.ToInt32(row["SoLuong"]);
                    orderDetail.tongTien = Convert.ToDecimal(row["TongTien"]);
                    this.orderDetails.Add(orderDetail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
