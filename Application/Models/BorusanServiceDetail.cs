using System.Collections.Generic;

namespace Application.Models
{
    public class BorusanServiceDetail
    {
        public string SsoApiUrl { get; set; }
        public string RealmID { get; set; }
        public string SshUrl { get; set; }
        public string InformMeApi { get; set; }
        public string AppID { get; set; }
        public string ApplicationID { get; set; }
        public List<string> MakeCodes { get; set; }
    }
}
