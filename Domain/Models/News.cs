using System.Collections.Generic;
using Domain.Common;
using static Domain.Constants.Constants;


namespace Domain.Models
{
    public class News : ExtendedBaseModel
    {
        public string Title { get; set; }
        public string FileUrl { get; set; }
        public string FileListUrl { get; set; }
        public string Text { get; set; }
        public UserTypes UserType { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}
