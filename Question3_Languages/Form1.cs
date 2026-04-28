using System;
using System.Drawing;
using System.Windows.Forms;

namespace Question3_Languages
{
    public partial class Form1 : Form
    {
        ListBox lstLanguages;
        TextBox txtLanguage;
        Button btnAdd;
        Button btnRemove;
        Label lblTimestamp;

        public Form1()
        {
            // Setup the Main Form Window
            this.Text = "Favourite Programming Languages";
            this.Size = new Size(450, 420);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "My Favourite Programming Languages";
            lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitle.Location = new Point(45, 20);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            // ListBox (pre-loaded with some languages)
            lstLanguages = new ListBox();
            lstLanguages.Location = new Point(50, 60);
            lstLanguages.Size = new Size(330, 140);
            lstLanguages.Items.AddRange(new string[] { "C#", "Python", "Java", "JavaScript", "Go" });
            this.Controls.Add(lstLanguages);

            // TextBox for input
            txtLanguage = new TextBox();
            txtLanguage.Location = new Point(50, 215);
            txtLanguage.Size = new Size(330, 25);
            this.Controls.Add(txtLanguage);

            // Add Button
            btnAdd = new Button();
            btnAdd.Text = "Add Language";
            btnAdd.Location = new Point(50, 255);
            btnAdd.Size = new Size(110, 35);
            btnAdd.BackColor = Color.DodgerBlue;
            btnAdd.ForeColor = Color.White;
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            // Remove Button
            btnRemove = new Button();
            btnRemove.Text = "Remove";
            btnRemove.Location = new Point(170, 255);
            btnRemove.Size = new Size(110, 35);
            btnRemove.BackColor = Color.Crimson;
            btnRemove.ForeColor = Color.White;
            btnRemove.Click += BtnRemove_Click;
            this.Controls.Add(btnRemove);

            // Timestamp Label
            lblTimestamp = new Label();
            lblTimestamp.Location = new Point(47, 305);
            lblTimestamp.AutoSize = true;
            lblTimestamp.ForeColor = Color.Gray;
            lblTimestamp.Font = new Font("Arial", 9, FontStyle.Italic);
            this.Controls.Add(lblTimestamp);
        }

        // Method to handle Adding a language
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string newLang = txtLanguage.Text.Trim();

            if (string.IsNullOrWhiteSpace(newLang))
            {
                MessageBox.Show("Please enter a programming language.");
                return;
            }

            if (lstLanguages.Items.Contains(newLang))
            {
                MessageBox.Show("Language already exists in the list.");
                return;
            }

            lstLanguages.Items.Add(newLang);
            txtLanguage.Clear();
        }

        // Method to handle Removing a language
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lstLanguages.SelectedItem != null)
            {
                string removedLang = lstLanguages.SelectedItem.ToString();
                lstLanguages.Items.Remove(lstLanguages.SelectedItem);
                
                // Display the removal time
                lblTimestamp.Text = $"Removed '{removedLang}' at {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}";
            }
            else
            {
                MessageBox.Show("Please select a language to remove.");
            }
        }
    }
}