using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantSystem
{
    public static class ApplicantSession
    {
        public static int AccountID { get; set; }

        public static int ApplicantID { get; set; }

        public static string ApplicantName { get; set; }

        public static string Email { get; set; }

        public static string FirstName { get; set; }

        public static string LastName { get; set; }

        public static string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public static void Clear()
        {
            AccountID = 0;
            ApplicantID = 0;
            Email = null;
            FirstName = null;
            LastName = null;
        }
    }
}
