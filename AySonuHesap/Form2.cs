using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AySonuHesap
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Con = new Functions();
            ShowPeople();
        }

        Functions Con;

        private void ShowPeople()
        {
            string Query = "select * from Kisiler";
            peopleListDataGridView.DataSource = Con.GetData(Query);
        }

        private void peopleAddButton_Click(object sender, EventArgs e)
        {
            if (peopleAddTextBox.Text != "")
            {
                try
                {
                    string Name = peopleAddTextBox.Text;
                    string Query = "insert into Kisiler values('{0}')";
                    Query = string.Format(Query, Name);
                    Con.SetData(Query);
                    MessageBox.Show("Kişi Başarıyla Eklendi.");
                    peopleAddTextBox.Text = "";
                    ShowPeople();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kayıt Yapmak İstediğiniz Kişinin Ad Soyad Bilgilerini Giriniz !!!");
            }
        }

        int Key = 0;
        private void peopleListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < peopleListDataGridView.Rows.Count)
            {
                DataGridViewRow selectedRow = peopleListDataGridView.Rows[e.RowIndex];

                peopleDeleteTextBox.Text = selectedRow.Cells[1].Value?.ToString();
                peopleUpdateTextBoxOldName.Text = selectedRow.Cells[1].Value?.ToString();

                if (peopleDeleteTextBox.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(selectedRow.Cells[0].Value); // ID sütununu alıyoruz
                }
            }
        }

        private void peopleDeleteButton_Click(object sender, EventArgs e)
        {
            if (Key != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Kişiyi Silmek İstediğinize Emin Misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string Name = peopleDeleteTextBox.Text;
                        string Query = "Delete from Kisiler where Id = '{0}'";
                        Query = string.Format(Query, Key);
                        Con.SetData(Query);
                        MessageBox.Show("Kişi Başarıyla Silindi.");
                        peopleDeleteTextBox.Text = "";
                        peopleUpdateTextBoxOldName.Text = "";
                        ShowPeople();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Kişi Silme İşlemi İptal Edildi.");
                    peopleDeleteTextBox.Text = "";
                    peopleUpdateTextBoxOldName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Silinecek Kişi Seçilmedi !!!");
            }
        }

        private void peopleUpdateButton_Click(object sender, EventArgs e)
        {
            if (peopleUpdateTextBoxOldName.Text != "" && peopleUpdateTextBoxNewName.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Kişiyi Güncellemeyi Onaylıyor Musunuz?", "Güncelleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string Name = peopleUpdateTextBoxNewName.Text;
                        string Query = "Update Kisiler set AdSoyad = '{0}' where Id = '{1}'";
                        Query = string.Format(Query, Name, Key);
                        Con.SetData(Query);
                        MessageBox.Show("Kişi Başarıyla Güncellendi.");
                        peopleUpdateTextBoxOldName.Text = "";
                        peopleUpdateTextBoxNewName.Text = "";
                        peopleDeleteTextBox.Text = "";
                        ShowPeople();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Kişi Güncelleme İşlemi İptal Edildi.");
                    peopleUpdateTextBoxOldName.Text = "";
                    peopleUpdateTextBoxNewName.Text = "";
                    peopleDeleteTextBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Güncellemek İstediğiniz Ad Soyad Bilgisini Giriniz !!!");
            }
        }
    }
}
