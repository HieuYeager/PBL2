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

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e) { }

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

            string fixedImagePath = $"C:\\Users\\Your_Username\\Desktop\\cappuccino.jpg";

            foreach (var item in items)
            {
                // Kích thước thẻ (Card)
                Panel cardPanel = new Panel();
                cardPanel.Size = new Size(300, 100); // TĂNG CHIỀU NGANG LÊN 300
                cardPanel.Margin = new Padding(10);
                cardPanel.BorderStyle = BorderStyle.FixedSingle;
                cardPanel.BackColor = Color.White;
                cardPanel.Tag = item.MaMon;

                // 1. PictureBox (Hình ảnh) - Chiếm cột TRÁI (1/3 chiều ngang)
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(100, 100); // Kích thước ảnh 100x100
                pictureBox.Location = new Point(0, 0);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.BackColor = Color.SandyBrown;

                // ... (Logic tải ảnh giữ nguyên) ...

                // 2. Label Tên món - Bắt đầu từ cột PHẢI (vị trí x=110)
                Label nameLabel = new Label();
                nameLabel.Text = item.ItemName;
                nameLabel.Location = new Point(110, 15); // x=110, y=15
                nameLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                nameLabel.AutoSize = true;

                // 3. Label Giá - Bắt đầu từ cột PHẢI, ngay dưới tên
                Label priceLabel = new Label();
                priceLabel.Text = item.Price.ToString("N0") + " VNĐ";
                priceLabel.Location = new Point(110, 45); // x=110, y=45
                priceLabel.Font = new Font("Arial", 10);

                // 4. Button (Dấu cộng) - Đặt ở góc dưới bên phải của cột PHẢI
                Button addButton = new Button();
                addButton.Text = "+";
                addButton.Font = new Font("Arial", 14, FontStyle.Bold);
                addButton.Size = new Size(30, 30);
                addButton.Location = new Point(255, 60); // Đặt ở gần góc dưới bên phải (255 = 300 - 30 - đệm)

                // Thêm các control con vào Panel
                cardPanel.Controls.Add(pictureBox);
                cardPanel.Controls.Add(nameLabel);
                cardPanel.Controls.Add(priceLabel);
                cardPanel.Controls.Add(addButton);

                try
                {
                    // Thay thế item.ImagePath bằng đường dẫn cố định
                    if (System.IO.File.Exists(fixedImagePath))
                    {
                        // Tải ảnh thành công từ Desktop
                        pictureBox.Image = Image.FromFile(fixedImagePath);
                    }
                    else
                    {
                        // Báo lỗi nếu file trên Desktop không tồn tại
                        // Lỗi này giúp bạn biết được tên file/đường dẫn đã sai
                        MessageBox.Show($"Lỗi: Không tìm thấy file ảnh tại đường dẫn cố định: {fixedImagePath}", "Lỗi Tải Ảnh Cục Bộ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi khi tải ảnh (ví dụ: file bị khóa)
                    MessageBox.Show($"Lỗi không xác định khi tải ảnh: {ex.Message}", "Lỗi Tải Ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Thêm Panel (thẻ) vào FlowLayoutPanel
                menuFlowPanel.Controls.Add(cardPanel);

                try
                {
                    if (!string.IsNullOrEmpty(item.ImagePath) && System.IO.File.Exists(item.ImagePath))
                    {
                        pictureBox.Image = Image.FromFile(item.ImagePath);
                    }
                }
                catch { /* Bỏ qua lỗi load ảnh */ }

                // 5. Thêm các control con vào Panel
                cardPanel.Controls.Add(pictureBox);
                cardPanel.Controls.Add(nameLabel);
                cardPanel.Controls.Add(priceLabel);
                cardPanel.Controls.Add(addButton);


                // 6. Thêm Panel (thẻ) vào FlowLayoutPanel
                menuFlowPanel.Controls.Add(cardPanel);
            }
        }
        //
    }
}
