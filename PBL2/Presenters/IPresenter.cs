using PBL2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Presenters
{
    public interface IPresenter<IView, IModel>
    {
        IView View { get; set; }
        IModel Model { get; set; }
    }
}
