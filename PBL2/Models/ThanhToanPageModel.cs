using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class ThanhToanPageModel: System.ComponentModel.INotifyPropertyChanged
    {
        public AccountModel acc { get; set; }
        public OrderModel order { get; set; }

        private decimal _TienThanhToan = 0;

        public decimal TienThanhToan { 
            get
            {
                return _TienThanhToan;
            }
            set 
            {
                _TienThanhToan = value;
                TienThua = _TienThanhToan - order.Total;
                OnPropertyChanged(nameof(TienThanhToan));
                OnPropertyChanged(nameof(TienThua));
            } 
        }
        public decimal TienThua { 
            get => TienThanhToan - order.Total; 
            set { } }

        public ThanhToanPageModel(AccountModel acc, OrderModel order)
        {
            this.acc = acc;
            this.order = order;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
