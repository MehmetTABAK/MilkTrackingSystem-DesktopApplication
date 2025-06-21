using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AySonuHesap
{
    public partial class Form4 : Form
    {
        private Functions Con;
        private DateTime currentMonth = DateTime.Now;

        public Form4()
        {
            InitializeComponent();
            Con = new Functions();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            lblAyYil.Text = currentMonth.ToString("MMMM yyyy");
            CreateTableLayout();
            LoadTableData();
        }

        private void CreateTableLayout()
        {
            tblMainPanel.Controls.Clear();
            tblMainPanel.RowStyles.Clear();
            tblMainPanel.ColumnStyles.Clear();

            int dayCount = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            tblMainPanel.ColumnCount = dayCount + 2;

            string query = "SELECT COUNT(*) FROM Kisiler";
            int personCount = Convert.ToInt32(Con.GetScalarData(query));
            tblMainPanel.RowCount = personCount + 2;

            for (int col = 0; col < tblMainPanel.ColumnCount; col++)
            {
                if (col == 0)
                    tblMainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
                else if (col == tblMainPanel.ColumnCount - 1)
                    tblMainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60));
                else
                    tblMainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            }

            for (int row = 0; row < tblMainPanel.RowCount; row++)
            {
                tblMainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
            }

            AddHeaderCells();
        }

        private void AddHeaderCells()
        {
            tblMainPanel.Controls.Add(new Label
            {
                Text = "Ad Soyad",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            }, 0, 0);

            for (int day = 1; day <= DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month); day++)
            {
                tblMainPanel.Controls.Add(new Label
                {
                    Text = day.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, day, 0);
            }

            tblMainPanel.Controls.Add(new Label
            {
                Text = "Toplam",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            }, tblMainPanel.ColumnCount - 1, 0);
        }

        private void LoadTableData()
        {
            string query = "SELECT Id, AdSoyad FROM Kisiler ORDER BY AdSoyad";
            DataTable people = Con.GetData(query);

            for (int row = 0; row < people.Rows.Count; row++)
            {
                int personId = Convert.ToInt32(people.Rows[row]["Id"]);
                string personName = people.Rows[row]["AdSoyad"].ToString();

                Label nameLabel = new Label
                {
                    Text = personName,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                tblMainPanel.Controls.Add(nameLabel, 0, row + 1);

                decimal total = 0;

                for (int day = 1; day <= DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month); day++)
                {
                    DateTime date = new DateTime(currentMonth.Year, currentMonth.Month, day);
                    var cellPanel = CreateDayCell(personId, date, ref total);
                    tblMainPanel.Controls.Add(cellPanel, day, row + 1);
                }

                tblMainPanel.Controls.Add(new Label
                {
                    Text = total.ToString("N1"),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.DarkSlateGray,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                }, tblMainPanel.ColumnCount - 1, row + 1);

                // Add border line after each person row
                for (int col = 0; col < tblMainPanel.ColumnCount; col++)
                {
                    var borderPanel = new Panel { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.DarkGray };
                    var control = tblMainPanel.GetControlFromPosition(col, row + 1);
                    if (control != null)
                        control.Controls.Add(borderPanel);
                }
            }
        }

        private Panel CreateDayCell(int personId, DateTime date, ref decimal total)
        {
            Panel panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(2), BackColor = Color.White };

            TextBox txtSabah = new TextBox
            {
                Width = 40,
                Margin = new Padding(0, 0, 1, 0),
                Font = new Font("Segoe UI", 8),
                Tag = new { PersonId = personId, Date = date, Period = "Sabah" }
            };
            txtSabah.TextChanged += TxtSut_TextChanged;

            TextBox txtAksam = new TextBox
            {
                Width = 40,
                Margin = new Padding(1, 0, 0, 0),
                Font = new Font("Segoe UI", 8),
                Tag = new { PersonId = personId, Date = date, Period = "Aksam" }
            };
            txtAksam.TextChanged += TxtSut_TextChanged;

            panel.Controls.Add(txtSabah);
            panel.Controls.Add(txtAksam);

            txtSabah.Dock = DockStyle.Left;
            txtAksam.Dock = DockStyle.Right;

            string query = "SELECT Sabah, Aksam FROM SutKayitlari WHERE KisiId = @PersonId AND Tarih = @Date";
            SqlParameter[] parameters = {
        new SqlParameter("@PersonId", personId),
        new SqlParameter("@Date", date)
    };
            DataTable dt = Con.GetDataWithParameters(query, parameters);
            if (dt.Rows.Count > 0)
            {
                decimal sabah = dt.Rows[0]["Sabah"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["Sabah"]) : 0;
                decimal aksam = dt.Rows[0]["Aksam"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["Aksam"]) : 0;

                txtSabah.Text = sabah > 0 ? sabah.ToString() : "";
                txtAksam.Text = aksam > 0 ? aksam.ToString() : "";

                total += sabah + aksam;
            }

            return panel;
        }

        private void TxtSut_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            dynamic tag = txt.Tag;

            if (decimal.TryParse(txt.Text, out decimal value))
            {
                string query = @"IF EXISTS (SELECT 1 FROM SutKayitlari WHERE KisiId = @PersonId AND Tarih = @Date)
                        UPDATE SutKayitlari SET " + tag.Period + @" = @Value WHERE KisiId = @PersonId AND Tarih = @Date
                        ELSE
                        INSERT INTO SutKayitlari (KisiId, Tarih, " + tag.Period + @") VALUES (@PersonId, @Date, @Value)";

                SqlParameter[] parameters = {
            new SqlParameter("@PersonId", tag.PersonId),
            new SqlParameter("@Date", tag.Date),
            new SqlParameter("@Value", value)
        };

                Con.SetDataWithParameters(query, parameters);
                UpdateTotal(tag.PersonId);
            }
            else if (string.IsNullOrEmpty(txt.Text))
            {
                string query = @"UPDATE SutKayitlari SET " + tag.Period + @" = 0 
                       WHERE KisiId = @PersonId AND Tarih = @Date";

                SqlParameter[] parameters = {
            new SqlParameter("@PersonId", tag.PersonId),
            new SqlParameter("@Date", tag.Date)
        };

                Con.SetDataWithParameters(query, parameters);
                UpdateTotal(tag.PersonId);
            }
        }

        private void UpdateTotal(int personId)
        {
            string query = @"SELECT SUM(Sabah + Aksam) FROM SutKayitlari 
                           WHERE KisiId = @PersonId AND 
                           YEAR(Tarih) = @Year AND MONTH(Tarih) = @Month";

            SqlParameter[] parameters = {
                new SqlParameter("@PersonId", personId),
                new SqlParameter("@Year", currentMonth.Year),
                new SqlParameter("@Month", currentMonth.Month)
            };

            object result = Con.GetScalarData(query, parameters);
            decimal total = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

            int rowIndex = GetPersonRowIndex(personId);
            if (rowIndex > 0)
            {
                var totalLabel = tblMainPanel.GetControlFromPosition(tblMainPanel.ColumnCount - 1, rowIndex) as Label;
                if (totalLabel != null)
                {
                    totalLabel.Text = total.ToString("N1");
                }
            }
        }

        private int GetPersonRowIndex(int personId)
        {
            for (int row = 1; row < tblMainPanel.RowCount; row++)
            {
                var label = tblMainPanel.GetControlFromPosition(0, row) as Label;
                if (label != null)
                {
                    string query = "SELECT Id FROM Kisiler WHERE AdSoyad = @Name";
                    SqlParameter[] parameters = { new SqlParameter("@Name", label.Text) };
                    int id = Convert.ToInt32(Con.GetScalarData(query, parameters));

                    if (id == personId)
                    {
                        return row;
                    }
                }
            }
            return -1;
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            LoadData();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            LoadData();
        }

        private void btnPersonManagement_Click(object sender, EventArgs e)
        {
            Form2 personelForm = new Form2();
            if (personelForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}