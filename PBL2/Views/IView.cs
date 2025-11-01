using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PBL2.Models;
using PBL2.Presenters;
namespace PBL2.Views
{
    public interface IView<IPresenter, IModel>
    {
        IPresenter Presenter { get; }
        IModel Model { get; }
    }
}
