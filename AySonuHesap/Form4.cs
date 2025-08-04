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
        private bool isFirstHalfLoaded = true; // Tracks which half is currently loaded

        public Form4()
        {
            InitializeComponent();
            Con = new Functions();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Determine which half to load based on the current day
            if (DateTime.Now.Day >= 17)
            {
                isFirstHalfLoaded = false;
            }
            else
            {
                isFirstHalfLoaded = true;
            }
            LoadData();
        }

        private void LoadData()
        {
            lblAyYil.Text = currentMonth.ToString("MMMM yyyy") + (isFirstHalfLoaded ? " (1. Yarı)" : " (2. Yarı)");
            CreateTableLayout();
            LoadTableData();
        }

        private void CreateTableLayout()
        {
            tblMainPanel.Controls.Clear();
            tblMainPanel.RowStyles.Clear();
            tblMainPanel.ColumnStyles.Clear();

            int startDay, endDay;

            if (isFirstHalfLoaded)
            {
                startDay = 1;
                endDay = 16;
            }
            else
            {
                startDay = 17;
                endDay = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            }

            int dayCount = endDay - startDay + 1;
            tblMainPanel.ColumnCount = dayCount + 2; // +2 for "Ad Soyad" and "Toplam"

            string query = "SELECT COUNT(*) FROM Kisiler";
            int personCount = Convert.ToInt32(Con.GetScalarData(query));
            tblMainPanel.RowCount = personCount + 2; // +2 for header and extra row

            // Column styles
            tblMainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120)); // "Ad Soyad" column

            for (int col = 0; col < dayCount; col++)
            {
                tblMainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90)); // Day columns
            }

            tblMainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90)); // "Toplam" column

            // Row styles
            for (int row = 0; row < tblMainPanel.RowCount; row++)
            {
                tblMainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
            }

            AddHeaderCells(startDay, endDay);
        }

        private void AddHeaderCells(int startDay, int endDay)
        {
            // Add "Ad Soyad" header
            tblMainPanel.Controls.Add(new Label
            {
                Text = "Ad Soyad",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            }, 0, 0);

            // Add day headers
            for (int day = startDay; day <= endDay; day++)
            {
                tblMainPanel.Controls.Add(new Label
                {
                    Text = day.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                }, day - startDay + 1, 0);
            }

            // Add "Toplam" header only if it's the second half
            if (!isFirstHalfLoaded)
            {
                tblMainPanel.Controls.Add(new Label
                {
                    Text = "Toplam",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                }, tblMainPanel.ColumnCount - 1, 0);
            }
        }

        private void LoadTableData()
        {
            string query = "SELECT Id, AdSoyad FROM Kisiler";
            DataTable people = Con.GetData(query);

            int startDay, endDay;
            if (isFirstHalfLoaded)
            {
                startDay = 1;
                endDay = 16;
            }
            else
            {
                startDay = 17;
                endDay = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            }

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

                for (int day = startDay; day <= endDay; day++)
                {
                    DateTime date = new DateTime(currentMonth.Year, currentMonth.Month, day);
                    var cellPanel = CreateDayCell(personId, date);
                    tblMainPanel.Controls.Add(cellPanel, day - startDay + 1, row + 1);
                }

                if (!isFirstHalfLoaded) // Add total column only for the second half
                {
                    decimal total = GetTotalMilkForPerson(personId);
                    tblMainPanel.Controls.Add(new Label
                    {
                        Text = total.ToString("N1"),
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Color.DarkSlateGray,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold)
                    }, tblMainPanel.ColumnCount - 1, row + 1);
                }
            }
        }

        private Panel CreateDayCell(int personId, DateTime date)
        {
            Panel panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(2), BackColor = Color.White };

            TextBox txtSabah = new TextBox
            {
                Width = 40,
                Margin = new Padding(0, 0, 1, 0),
                Font = new Font("Segoe UI", 8),
                Tag = new { PersonId = personId, Date = date, Period = "Sabah" },
                BackColor = Color.LightGray // Sabah için farklı bir renk
            };
            txtSabah.TextChanged += TxtSut_TextChanged;
            txtSabah.LostFocus += TxtSut_LostFocus;

            TextBox txtAksam = new TextBox
            {
                Width = 40,
                Margin = new Padding(1, 0, 0, 0),
                Font = new Font("Segoe UI", 8),
                Tag = new { PersonId = personId, Date = date, Period = "Aksam" },
                BackColor = Color.LightBlue // Akşam için farklı bir renk
            };
            txtAksam.TextChanged += TxtSut_TextChanged;
            txtAksam.LostFocus += TxtSut_LostFocus;

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
            }

            return panel;
        }

        private void TxtSut_TextChanged(object sender, EventArgs e)
        {
            // This event is primarily for immediate feedback or if you want to save on every text change.
            // For better performance and to avoid rapid database calls, it's often better to save on LostFocus.
        }

        private void TxtSut_LostFocus(object sender, EventArgs e)
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
            }

            // Always update the total after a value changes in the second half
            if (!isFirstHalfLoaded)
            {
                UpdateTotal(tag.PersonId);
            }
        }

        private decimal GetTotalMilkForPerson(int personId)
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
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        private void UpdateTotal(int personId)
        {
            decimal total = GetTotalMilkForPerson(personId);

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
            // Start from row 1 because row 0 is headers
            for (int row = 1; row < tblMainPanel.RowCount; row++)
            {
                var label = tblMainPanel.GetControlFromPosition(0, row) as Label;
                if (label != null)
                {
                    // You need to retrieve the person ID more robustly, not by name lookup.
                    // A better approach would be to store the personId in the Tag of the NameLabel.
                    // For now, let's use the existing (less efficient) method of querying by name.
                    string query = "SELECT Id FROM Kisiler WHERE AdSoyad = @Name";
                    SqlParameter[] parameters = { new SqlParameter("@Name", label.Text) };
                    object result = Con.GetScalarData(query, parameters);
                    if (result != DBNull.Value)
                    {
                        int id = Convert.ToInt32(result);
                        if (id == personId)
                        {
                            return row;
                        }
                    }
                }
            }
            return -1;
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            if (isFirstHalfLoaded)
            {
                // If currently viewing first half, switch to second half of previous month
                currentMonth = currentMonth.AddMonths(-1);
                isFirstHalfLoaded = false;
            }
            else
            {
                // If currently viewing second half, switch to first half of same month
                isFirstHalfLoaded = true;
            }
            LoadData();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            if (isFirstHalfLoaded)
            {
                // If currently viewing first half, switch to second half of same month
                isFirstHalfLoaded = false;
            }
            else
            {
                // If currently viewing second half, switch to first half of next month
                currentMonth = currentMonth.AddMonths(1);
                isFirstHalfLoaded = true;
            }
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