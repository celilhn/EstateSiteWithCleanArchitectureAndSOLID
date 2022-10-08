using System;
using static Domain.Constants.Constants;

namespace Domain.Common
{
    public class ExtendedBaseModel
    {
        public int Id { get; set; }
        public DateTime InsertionDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public StatusCodes Status { get; set; }
    }
}
