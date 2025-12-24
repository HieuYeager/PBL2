using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class OrderDetailModel: INotifyPropertyChanged
    {
        public MonModel monModel { get; set; }

        public int maMon { get => monModel.MaMon; }
        public string TenMon => monModel?.TenMon;
        public decimal giaBan { get => monModel.GiaBan; }
        //public int soLuong { get; set; } = 0 ;
        private int _soLuong = 0;
        //so luong thay doi
        public int soLuong
        {
            get => _soLuong;
            set
            {
                if (_soLuong != value)
                {
                    _soLuong = value;
                    tongTien = giaBan * soLuong;
                    OnPropertyChanged(nameof(soLuong));
                    OnPropertyChanged(nameof(tongTien));
                }
            }
        }
        public decimal tongTien { 
            get => giaBan * soLuong;
            set => OnPropertyChanged(nameof(tongTien));}

        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

    }
}
