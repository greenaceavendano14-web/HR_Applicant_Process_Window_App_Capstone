using System;
using System.Drawing;
using System.Windows.Forms;

namespace ApplicantAuthDocumentManagement.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            lblMessage.Text = "";

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please enter a valid email address.";
                txtEmail.Focus();
                return;
            }

        }
    }
}