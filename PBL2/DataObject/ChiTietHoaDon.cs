using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public class ChiTietHoaDon : INotifyPropertyChanged
    {
        public string MaHD { get; set; }
        public int MaMon { get; set; }
        //property phu: ten mon
        public string TenMon {
            get
            {
                return Mons.Get(MaMon)?.TenMon??"";
            }
            private set { } 
        }

        private int _SoLuong;
        public int SoLuong
        {
            get => _SoLuong;
            set
            {
                _SoLuong = value;
                OnPropertyChanged(nameof(SoLuong));
            }
        }
        public decimal DonGia { get; set; }

        //property phu: tong tien
        public decimal TongTien
        {
            get => SoLuong * DonGia;
            private set { }
        }

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }

}
