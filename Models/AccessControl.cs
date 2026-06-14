using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace HRApplicantSystem.Models
{
    public static class AccessControl
    {
        public static bool RequireRole(string[] allowedRoles)
        {
            foreach (string role in allowedRoles)
            {
                if (Session.RoleName == role)
                    return true;
            }

            MessageBox.Show(
                "You are not authorized to perform this action.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }
    }
}
