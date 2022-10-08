using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class AdminUserRequestLimit
    {
        public int LoginMinuteLimit { get; set; }
        public int LoginInCorrectLimit { get; set; }
        public int ForgotPasswordMinuteLimit { get; set; }
        public int ForgotPasswordInCorrect { get; set; }
    }
}
