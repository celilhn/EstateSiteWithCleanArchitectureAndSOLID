using System;

namespace Application.Models
{
    public class Captcha
    {
        public bool success { get; set; }
        public DateTime challenge_ts { get; set; }
        public string hostname { get; set; }
    }
}
