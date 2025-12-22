using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Views.QLTonKho
{
    public partial class XemCanhBao : Form
    {
        public XemCanhBao()
        {
            InitializeComponent();
        }

        public void SetDataSource(DataTable dtCanhBao)
        {
            if (dataGridView1 != null)
            {
                this.dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtCanhBao;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Lỗi: Control dataGridView1 chưa được khởi tạo.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // bỏ qua header

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
        }
    }
}
