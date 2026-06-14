using System;
using System.Collections.Generic;
using System.Text;

namespace HRApplicantSystem.Models
{
    public static class Session
    {
        public static int UserID { get; set; }

        public static string FullName { get; set; }

        public static string RoleName { get; set; }


        public static void Clear()
        {
            UserID = 0;
            RoleName = null;
            FullName = null;
        }
    }
}