using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PBL2.Models;
using PBL2.Presenters;
namespace PBL2.Views
{
    internal interface IView
    {
        //update data form presenter to view
        void UpdateView(IModel model);
    }
}
