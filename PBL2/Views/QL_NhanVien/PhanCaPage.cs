using PBL2.Class;
using PBL2.Models;
using PBL2.Presenters.QL_NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBL2.Views.PhanCa
{


    public partial class PhanCaPage : UserControl
    {
        public QL_NhanVienPresenter Presenter { get; set; }

        public QL_NhanVienPageModel Model { get; set; }

        //back
        public delegate void LoadQLNhanVienDelegate();
        public LoadQLNhanVienDelegate loadQLNhanVienHandler { get; set; }

        // màu khi được chọn
        private readonly Color SelectedBack = Color.FromArgb(70, 101, 87);
        private readonly Color SelectedText = Color.FromArgb(255, 255, 255);

        // màu mặc định (hoặc màu "không chọn")
        private readonly Color DefaultBack = Color.FromArgb(123, 163, 146);
        private readonly Color DefaultText = Color.FromArgb(34, 49, 43);
        //select button
        private Krypton.Toolkit.KryptonButton selectedButton { get; set; }
        private CaLamViec caLamViec { get; set; } = CaLamViec.CaSang;

        private bool dataGridView1_isPainting = false;
        public PhanCaPage(QL_NhanVienPresenter presenter)
        {
            InitializeComponent();
            this.Presenter = presenter;
            this.Model = this.Presenter.Model;

            this.changeButtonColor(this.btnCaSang);

            this.loadCaLamViec();
            //diem danh
            List<Item> caLamList = new List<Item>
            {
                new Item { Text = "Ca sáng", Value = CaLamViec.CaSang },
                new Item { Text = "Ca chiều", Value = CaLamViec.CaChieu },
                new Item { Text = "Ca tối",   Value = CaLamViec.CaToi },
            };

            this.cmBCaLamViec.DataSource = caLamList;
            this.cmBCaLamViec.DisplayMember = "Text";
            this.cmBCaLamViec.ValueMember = "Value";
            this.panelDiemDanh.Size = new Size(0, 0);
        }
        //event
        public void btn_Click(object sender, EventArgs e)
        {
            changeButtonColor((Krypton.Toolkit.KryptonButton)sender);
            if(this.selectedButton == this.btnCaSang)
            {
                this.caLamViec = CaLamViec.CaSang;
            }
            else if (this.selectedButton == this.btnCaChieu)
            {
                this.caLamViec = CaLamViec.CaChieu;
            }
            else if (this.selectedButton == this.btnCaToi)
            {
                this.caLamViec = CaLamViec.CaToi;
            }
            loadCaLamViec();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.loadQLNhanVienHandler?.Invoke();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (this.dataGridView1_isPainting == true) return;
            loadPhanCa(this.caLamViec);
            this.dataGridView1_isPainting = true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Label.Focus();
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                string calamviecKhac = this.Model.CaLamViec.Rows[row.Index]["CaLamViec"]?.ToString();
                if (calamviecKhac != null)
                {
                    string[] caLamViecs = calamviecKhac.Split('|');
                    // Lọc bỏ những ca chứa "CC"
                    var ketQua = caLamViecs
                                    .Where(ca => !ca.EndsWith(this.caLamViec.GetDisplayName()))
                                    .ToList();
                    calamviecKhac = string.Join("|", ketQua);
                }

                string MaNV = this.Model.CaLamViec.Rows[row.Index]["MaNV"]?.ToString();
                List<string> listCaLamViec = new List<string>();
                for (int i = 0; i < 7; i++)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells["T" + (i + 2)];
                    bool isChecked = Convert.ToBoolean(cell.Value);
                    if (isChecked)
                    {
                        string cotDaTick = "T" + (i + 2);
                        string caLamViecStr = cotDaTick + this.caLamViec.GetDisplayName();
                        listCaLamViec.Add(caLamViecStr);
                    }
                }
                string caLamViecFinal = string.Join("|", listCaLamViec);
                if (calamviecKhac != null && calamviecKhac != caLamViecFinal && caLamViecFinal != "") caLamViecFinal += "|" + calamviecKhac;
                this.dataGridView1.Rows[row.Index].Cells["CaLamViec"].Value = caLamViecFinal;
                //MessageBox.Show("Lưu phân ca của nhân viên " + MaNV + " thành "+ this.dataGridView1.Rows[row.Index].Cells["CaLamViec"].Value, "Thoại báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Presenter.updatePhanCa();
            this.loadCaLamViec();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.panelDiemDanh.Size = new Size(0, 0);
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            this.Label.Focus();
            this.panelDiemDanh.Size = new Size(357, 614);
            this.btnChonNgay.PerformClick();

        }

        private void btnChonNgay_Click(object sender, EventArgs e)
        {
            CaLamViec caLamViec = (CaLamViec)this.cmBCaLamViec.SelectedValue;
            this.Presenter.Load_DiemDanh(this.dateTime.Value, caLamViec);
            this.dataGridViewDiemDanh.Columns.Clear();
            this.dataGridViewDiemDanh.DataSource = this.Model.DiemDanh;

            //custom column
            this.dataGridViewDiemDanh.Columns["MaNV"].HeaderText = "Mã";
            this.dataGridViewDiemDanh.Columns["MaNV"].ReadOnly = true;
            this.dataGridViewDiemDanh.Columns["MaNV"].FillWeight = 30;
            this.dataGridViewDiemDanh.Columns["TenNV"].HeaderText = "Tên nhân viên";
            this.dataGridViewDiemDanh.Columns["TenNV"].ReadOnly = true;
            this.dataGridViewDiemDanh.Columns["DiemDanh"].FillWeight = 60;
            this.dataGridViewDiemDanh.Columns["DiemDanh"].HeaderText = "";
            this.dataGridViewDiemDanh.Columns["DiemDanh"].FillWeight = 10;
            this.dataGridViewDiemDanh.Columns["DiemDanh"].ReadOnly = false;

            this.dataGridViewDiemDanh.Columns["Calam"].Visible = false;
            this.dataGridViewDiemDanh.Columns["Ngay"].Visible = false;

        }

        private void UpdateSubmitBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.updateDiemDanh();
            this.btnChonNgay.PerformClick();
        }
        //function
        public void loadCaLamViec()
        {
            this.dataGridView1_isPainting = false;
            this.dataGridView1.Columns.Clear();
            this.Presenter.Load_PhanCa(this.caLamViec);
            this.dataGridView1.DataSource = this.Model.CaLamViec;

            //custom column
            this.dataGridView1.Columns["MaNV"].HeaderText = "Mã";
            this.dataGridView1.Columns["MaNV"].ReadOnly = true;
            this.dataGridView1.Columns["MaNV"].FillWeight = 40;
            this.dataGridView1.Columns["TenNV"].HeaderText = "Tên nhân viên";
            this.dataGridView1.Columns["TenNV"].ReadOnly = true;
            this.dataGridView1.Columns["CaLamViec"].HeaderText = "Ca làm việc";
            this.dataGridView1.Columns["CaLamViec"].ReadOnly = true;
            this.dataGridView1.Columns["CaLamViec"].Visible = false;

            //add column Thu2 --> Cn as bool
            for (int i = 0; i < 7; i++)
            {
                DataGridViewCheckBoxColumn cotThu = new DataGridViewCheckBoxColumn();
                cotThu.Name = "T" + (i + 2);
                if(i ==6)
                {
                    cotThu.HeaderText = "CN";
                }
                else
                {
                    cotThu.HeaderText = "Thứ " + (i + 2);
                }
                this.dataGridView1.Columns.Add(cotThu);
            }

            //cho phep dieu chinh cac cot thu
            for (int i = 0; i < 7; i++)
            {
                this.dataGridView1.Columns["T" + (i + 2)].ReadOnly = false;
                this.dataGridView1.Columns["T" + (i + 2)].FillWeight = 20;
            }
            this.loadPhanCa(this.caLamViec);
        }

        public void loadPhanCa(CaLamViec caLamViec = CaLamViec.CaSang)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                string MaCaLamViec = this.Model.CaLamViec.Rows[row.Index]["CaLamViec"]?.ToString();
                if (MaCaLamViec != null)
                {
                    string[] listCaLamViec = MaCaLamViec.Split('|');
                    foreach (string ca in listCaLamViec)
                    {
                        if (ca.Length == 4)
                        {
                            if (ca.Substring(2, 2) == caLamViec.GetDisplayName())
                            {
                                string cotCanTick = ca.Substring(0, 2);
                                dataGridView1.Rows[row.Index].Cells[cotCanTick].Value = true;
                            }
                        }
                    }

                }
            }
        }
        //function color btn
        private void changeButtonColor(Krypton.Toolkit.KryptonButton button)
        {
            //chang button color
            if (this.selectedButton != null)
            {
                this.ResetButtonAppearance(this.selectedButton);
            }
            this.selectedButton = button;
            this.ApplySelectedAppearance(this.selectedButton);

            this.Label.Focus();
        }
        private void ApplySelectedAppearance(Krypton.Toolkit.KryptonButton btn)
        {
            btn.StateCommon.Back.Color1 = SelectedBack;
            btn.StateCommon.Content.ShortText.Color1 = SelectedText;
        }

        private void ResetButtonAppearance(Krypton.Toolkit.KryptonButton btn)
        {
            if (btn == null) return;
            btn.StateCommon.Back.Color1 = DefaultBack;
            btn.StateCommon.Content.ShortText.Color1 = DefaultText;
        }

    }

    public class Item
    {
        public string Text { get; set; }
        public CaLamViec Value { get; set; }
    }
}
