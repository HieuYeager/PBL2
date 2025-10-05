using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;
using MySql.Data.MySqlClient;

namespace PBL2.Views.MenuPage
{
    public partial class Menu : UserControl
    {
        // Kết nối CSDL
        private DbConnector dbConnector = new DbConnector();
        private FlowLayoutPanel menuFlowPanel;

        public Menu()
        {
            InitializeComponent();
            // Tìm điểm kết thúc của menuDrop + một khoảng đệm nhỏ (5 pixels)
            int startY = menuDrop.Bottom + 5;
            menuFlowPanel = new FlowLayoutPanel
            {
                Location = new Point(0, startY), // Bắt đầu ngay dưới menuDrop
                Size = new Size(this.Width, this.Height - startY), // Chiếm hết phần còn lại của UserControl
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right, // Đảm bảo tự điều chỉnh kích thước
                AutoScroll = true,
                BackColor = Color.Transparent // Hoặc màu nền bạn muốn
                //Dock = DockStyle.Fill,
                //AutoScroll = true
            };
            this.Controls.Add(menuFlowPanel);
            // Đảm bảo menuFlowPanel nằm dưới các control tĩnh khác (như menuDrop)
            menuFlowPanel.SendToBack();
            LoadMenuItems();
        }

        //
        public class MenuItem
        {
            //côt MaMon
            public string MaMon { get; set; }
            //cột TenMon
            public string ItemName { get; set; }
            //cột GiaBan
            public decimal Price { get; set; }
            //cột MaDM
            public string MaDM { get; set; }
            //cột HinhAnh
            public string ImagePath { get; set; }
        }

        public class DbConnector
        {
            // !! THAY THẾ CHUỖI KẾT NỐI NÀY !!
            private readonly string connectionString = "Server=localhost;Database=PBL;Uid=root;Pwd=11012004;";

            public List<MenuItem> GetMenuItemsByCategoryName(string categoryName)
            {
                var items = new List<MenuItem>();

                // Truy vấn JOIN Mon và DanhMuc để lấy dữ liệu
                string query = @"
                SELECT 
                    T1.MaMon, T1.TenMon, T1.GiaBan, T1.MaDM, T1.ImagePath 
                FROM Mon AS T1
                JOIN DanhMuc AS T2 ON T1.MaDM = T2.MaDM
                WHERE T2.TenDM = @CategoryName";

                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", categoryName);

                        try
                        {
                            connection.Open();
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    items.Add(new MenuItem
                                    {
                                        MaMon = reader.GetValue(reader.GetOrdinal("MaMon")).ToString(),
                                        ItemName = reader.GetString("TenMon"),
                                        Price = reader.GetDecimal("GiaBan"),
                                        MaDM = reader.GetString("MaDM"),
                                        ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ?
                                                    "" : reader.GetString("ImagePath") // Xử lý nếu ImagePath null
                                    });
                                }
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show($"Lỗi kết nối hoặc truy vấn CSDL: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                return items;
            }
        }
        //

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e) {}

        private void Menu_Load(object sender, EventArgs e)
        {
            //
            // Tải món ăn cho category mặc định
            if (menuDrop.Items.Count > 0)
            {
                DisplayMenuItems(menuDrop.SelectedItem.ToString());
            }
            //
        }
        private void LoadMenuItems()
        {
            // Thêm các category vào ComboBox
            menuDrop.Items.Clear();
            menuDrop.Items.Add("Hot Drink");
            menuDrop.Items.Add("Cafe");
            //menuDrop.Items.Add("Water");

            if (menuDrop.Items.Count > 0)
                menuDrop.SelectedIndex = 0;
        }

        private void menuDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            if (menuDrop.SelectedItem != null)
            {
                string selectedCategory = menuDrop.SelectedItem.ToString();
                DisplayMenuItems(selectedCategory);
            }
            //
        }

        //
        private void DisplayMenuItems(string categoryName)
        {
            // Kiểm tra tên FlowLayoutPanel
            if (menuFlowPanel == null)
            {
                MessageBox.Show("Lỗi: Không tìm thấy 'menuFlowPanel'.", "Lỗi Giao diện", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            menuFlowPanel.Controls.Clear();

            List<MenuItem> items = dbConnector.GetMenuItemsByCategoryName(categoryName);

            foreach (var item in items)
            {
                // 1. Tạo Panel mô phỏng thẻ (Card)
                Panel cardPanel = new Panel();
                cardPanel.Size = new Size(200, 100); // Kích thước cố định cho dễ nhìn
                cardPanel.Margin = new Padding(10);
                cardPanel.BorderStyle = BorderStyle.FixedSingle;
                cardPanel.Tag = item.MaMon; // Lưu mã món ăn vào Tag

                // 2. Tạo Label hiển thị Tên món
                Label nameLabel = new Label();
                nameLabel.Text = item.ItemName;
                nameLabel.Location = new Point(10, 10);
                nameLabel.AutoSize = true;

                // 3. Tạo Label hiển thị Giá
                Label priceLabel = new Label();
                priceLabel.Text = item.Price.ToString("N0") + " VNĐ";
                priceLabel.Location = new Point(10, 40);
                priceLabel.Font = new Font(priceLabel.Font, FontStyle.Bold);

                // 4. (Tùy chọn) Tạo PictureBox (Cần xử lý ImagePath)
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(50, 50);
                pictureBox.Location = new Point(140, 20);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                try
                {
                    if (!string.IsNullOrEmpty(item.ImagePath) && System.IO.File.Exists(item.ImagePath))
                    {
                        pictureBox.Image = Image.FromFile(item.ImagePath);
                    }
                }
                catch { /* Bỏ qua lỗi load ảnh */ }

                // 5. Thêm các control con vào Panel
                cardPanel.Controls.Add(nameLabel);
                cardPanel.Controls.Add(priceLabel);
                cardPanel.Controls.Add(pictureBox);

                // 6. Thêm Panel (thẻ) vào FlowLayoutPanel
                menuFlowPanel.Controls.Add(cardPanel);
            }
        }
        //
    }
}
