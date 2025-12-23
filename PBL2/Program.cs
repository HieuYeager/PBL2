using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL2.Database;
using PBL2.Views.staffView;

namespace PBL2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            string sql = NhanViens.select()
                .From(NhanViens.TableName).Where($"{NhanViens.MaNV} = 'NV01'")
                .GetSql();
            MessageBox.Show(sql);
        }
    }
}
