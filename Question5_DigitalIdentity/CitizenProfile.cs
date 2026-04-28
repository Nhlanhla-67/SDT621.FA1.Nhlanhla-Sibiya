using System;
using System.Drawing;
using System.Windows.Forms;

namespace Question5_DigitalIdentity
{
    // The CitizenProfile Class logic as requested in the brief
    public class CitizenProfile
    {
        public string FullName { get; set; }
        public string IDNumber { get; set; }
        public int Age { get; private set; }
        public string CitizenshipStatus { get; set; }

        public CitizenProfile(string fullName, string idNumber, string citizenshipStatus)
        {
            FullName = fullName;
            IDNumber = idNumber;
            CitizenshipStatus = citizenshipStatus;
            CalculateAge();
        }

        private void CalculateAge()
        {
            if (IDNumber.Length >= 6 && long.TryParse(IDNumber.Substring(0, 6), out _))
            {
                int year = int.Parse(IDNumber.Substring(0, 2));
                int month = int.Parse(IDNumber.Substring(2, 2));
                int day = int.Parse(IDNumber.Substring(4, 2));

                int currentYear = DateTime.Now.Year;
                int fullYear = year + (year > (currentYear % 100) ? 1900 : 2000);
                
                try 
                {
                    DateTime dob = new DateTime(fullYear, month, day);
                    Age = currentYear - dob.Year;
                    if (DateTime.Now.DayOfYear < dob.DayOfYear) Age--;
                } 
                catch 
                {
                    Age = 0; // Fallback for invalid ID dates
                }
            }
        }

        public string ValidateID()
        {
            if (IDNumber.Length != 13) return "Invalid ID. Must be 13 digits.";
            if (!long.TryParse(IDNumber, out _)) return "Invalid ID. Must be numeric.";
            return $"Valid ID. Citizen is {Age} years old.";
        }
    }

    // The User Interface Logic
    public partial class Form1 : Form
    {
        TextBox txtName, txtID, txtSummary;
        ComboBox cmbCitizenship;
        Button btnValidate, btnGenerate;
        Label lblValidation;
        CitizenProfile currentProfile;

        public Form1()
        {
            this.Text = "Home Affairs Digital Identity Processor";
            this.Size = new Size(550, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightSalmon; // Matching the brief's background color

            Label lblTitle = new Label { Text = "Home Affairs Digital Identity Processor", ForeColor = Color.DarkGreen, Font = new Font("Arial", 14, FontStyle.Bold), Location = new Point(50, 20), AutoSize = true };
            this.Controls.Add(lblTitle);

            Label lblName = new Label { Text = "Enter your Name:", Location = new Point(50, 70), AutoSize = true };
            txtName = new TextBox { Location = new Point(200, 65), Width = 250 };
            this.Controls.Add(lblName); this.Controls.Add(txtName);

            Label lblID = new Label { Text = "Enter your ID:", Location = new Point(50, 110), AutoSize = true };
            txtID = new TextBox { Location = new Point(200, 105), Width = 250 };
            this.Controls.Add(lblID); this.Controls.Add(txtID);

            Label lblCitizen = new Label { Text = "Choose your Citizen:", Location = new Point(50, 150), AutoSize = true };
            cmbCitizenship = new ComboBox { Location = new Point(200, 145), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCitizenship.Items.AddRange(new string[] { "South African", "Permanent Resident", "Visitor" });
            this.Controls.Add(lblCitizen); this.Controls.Add(cmbCitizenship);

            btnValidate = new Button { Text = "Validate ID", Location = new Point(200, 190), BackColor = Color.Green, ForeColor = Color.White, AutoSize = true };
            btnValidate.Click += BtnValidate_Click;
            this.Controls.Add(btnValidate);

            lblValidation = new Label { Location = new Point(200, 230), AutoSize = true };
            this.Controls.Add(lblValidation);

            txtSummary = new TextBox { Location = new Point(200, 270), Width = 250, Height = 120, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };
            this.Controls.Add(txtSummary);

            btnGenerate = new Button { Text = "Generate profile", Location = new Point(200, 410), BackColor = Color.Green, ForeColor = Color.White, AutoSize = true };
            btnGenerate.Click += BtnGenerate_Click;
            this.Controls.Add(btnGenerate);
        }

        private void BtnValidate_Click(object sender, EventArgs e)
        {
            string status = cmbCitizenship.SelectedItem != null ? cmbCitizenship.SelectedItem.ToString() : "South African";
            currentProfile = new CitizenProfile(txtName.Text, txtID.Text, status);
            lblValidation.Text = currentProfile.ValidateID();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (currentProfile != null)
            {
                txtSummary.Text = "==== DIGITAL CITIZEN SUMMARY ====\r\n" +
                                  $"Name: {currentProfile.FullName}\r\n" +
                                  $"ID Number: {currentProfile.IDNumber}\r\n" +
                                  $"Age: {currentProfile.Age}\r\n" +
                                  $"Citizenship: {currentProfile.CitizenshipStatus}\r\n" +
                                  $"Validation: {currentProfile.ValidateID()}\r\n" +
                                  "Processed at: Home Affairs Digital Desk\r\n" +
                                  $"Timestamp: {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}";
            }
        }
    }
}