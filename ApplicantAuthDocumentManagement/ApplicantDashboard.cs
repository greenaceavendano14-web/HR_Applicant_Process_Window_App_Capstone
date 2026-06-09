using System;
using System.Windows.Forms;

namespace ApplicantAuthDocumentManagement.Forms
{
    public partial class ApplicantDashboard : Form
    {
        public ApplicantDashboard()
        {
            InitializeComponent();
            lblApplicationID.Text = "Application ID: APP-001";
            lblDateApplied.Text = "Date Applied: June 10, 2026";

            LoadApplicantData();
        }

        private void LoadApplicantData()
        {
            // Application Summary
            lblApplicant.Text = "Applicant: Juan Dela Cruz";
            lblPosition.Text = "Position: Software Developer";

            // Current Status
            lblStatus.Text = "Under Initial Screening";

            // Interview Schedule
            lblInterview.Text =
                "Date: June 20, 2026\r\n" +
                "Time: 9:00 AM\r\n" +
                "Location: HR Office";

            // Missing Documents
            lstDocs.Items.Clear();
            lstDocs.Items.Add("Transcript of Records");
            lstDocs.Items.Add("NBI Clearance");

            // Recent Updates
            lstUpdates.Items.Clear();
            lstUpdates.Items.Add("June 10 - Application Submitted");
            lstUpdates.Items.Add("June 12 - Under Initial Screening");
            lstUpdates.Items.Add("June 14 - Interview Scheduled");
        }

        private void lblApplicant_Click(object sender, EventArgs e)
        {
        }

        private void grpInterview_Enter(object sender, EventArgs e)
        {

        }

        private void grpInfo_Enter(object sender, EventArgs e)
        {

        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }
        private void btnProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Applicant Profile Opened!");
        }
    }
}