
namespace Domain.Constants
{
    public class Constants
    {
        public enum CacheArticleTypes
        {
            News = 1,
            MemberShipPlans = 2,
            Adresses = 3,
            Member = 4,
            Property = 5
        }

        public enum UserTypes
        {
            Admin = 1,
            User = 2
        }

        public enum StatusCodes
        {
            Passive = 0,
            Active = 1
        }

        public enum AdminUserTypes
        {
            Unknown = -1,
            All = 0,
            AdminUser = 1,
            CallCenterUser = 2,
            OperationUser = 3,
            ReportUser = 4
        }

        public enum ImageTypes
        {
            PropertyListImage = 1,
            PropertyDetailImage = 2,
            NewsListImage = 3,
            NewsDetailImage = 4,
            MemberListImage = 5,
            MemberDetailImage = 6,
            MyPropertyImage = 7,
            MemberInPropertyImage =8,
        }
        

        /// <summary>
        /// Operation results.
        /// </summary>
        public enum ProcessResults
        {
            /// <summary>
            /// Operations was completed successfully.
            /// </summary>
            Unknown = -1,
            /// <summary>
            /// Test Test
            /// </summary>
            Success = 0,
            ServiceError = 1,
            ServiceSystemError = 2,
            ModelValidationError = 3,
            SystemError = 4,
            Authorization = 5,
            UserNotFound = 6,
            RefreshTokenNotFound = 7,
            NoContent = 8,
            ParameterError = 9
        }

        public enum CodeRequestTypes
        {
            GeneratedCode = 1,
            UploadedCode = 2
        }

        public enum ActionTypes
        {
            Update = 1,
            Create = 2,
            List = 3
        }
    }
}
