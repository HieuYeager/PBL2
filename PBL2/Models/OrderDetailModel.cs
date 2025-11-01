using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class OrderDetailModel: INotifyPropertyChanged, IModel
    {
        public MonModel monModel { get; set; }

        public string TenMon => monModel?.TenMon;
        public decimal tongTien { get; set; }

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
                    tongTien = monModel.GiaBan * soLuong;
                    OnPropertyChanged(nameof(soLuong));
                    OnPropertyChanged(nameof(tongTien));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

    }
}
