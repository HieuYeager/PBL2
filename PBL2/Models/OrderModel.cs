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
        public string MaHD { get; set; } = "";
        public List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();
        public int maBan { get; set; } = 1;
        public decimal Total
        {
            get { return orderDetails.Sum(x => x.tongTien); }
            private set { }
        }

        public OrderModel() { }

        public OrderModel(HoaDon hd) 
        {
            this.MaHD = hd.MaHD;
            if(hd.MaBan != null) this.maBan = Convert.ToInt32(hd.MaBan);
            
            this.orderDetails = new List<OrderDetailModel>();
            DataTable dt = MySQL_DB.Instance.Select("chitiethoadon", "*",  $"MaHD = '{hd.MaHD}'");
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    //mon model
                    MonModel mon = new MonModel();
                    DataTable dtmon = MySQL_DB.Instance.Select("mon", "*", $"MaMon = '{row["MaMon"]}' LIMIT 1");
                    mon.MaMon = Convert.ToInt32(dtmon.Rows[0]["MaMon"]);
                    mon.TenMon = dtmon.Rows[0]["TenMon"].ToString();
                    mon.GiaBan = Convert.ToDecimal(dtmon.Rows[0]["GiaBan"]);
                    mon.DonVi = dtmon.Rows[0]["DonVi"].ToString();
                    mon.URLImage = dtmon.Rows[0]["URL_anh"].ToString();
                    //order detail model
                    OrderDetailModel orderDetail = new OrderDetailModel();
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
