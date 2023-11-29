namespace UserPortal.Models.User
{
    public class UserResponseModel
    {
       
        public class BusinessRule
        {
            public int Key { get; set; }
            public object Value { get; set; }
        }

        public class CurrentPeriod
        {
            public int Id { get; set; }
            public int Type { get; set; }
            public string Code { get; set; }
            public DateTime BeginDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Status { get; set; }
        }

        public class Data
        {
            public string UserId { get; set; }
            public string CurrentUserId { get; set; }
            public int CardId { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string EMail { get; set; }
            public string PositionDescription { get; set; }
            public bool Impersonating { get; set; }
            public string ApplicationRole { get; set; }
            public bool CanImpersonate { get; set; }
            public List<BusinessRule> BusinessRules { get; set; }
            public int ResponsibilityUnitType { get; set; }
            public int ResponsibilityUnitId { get; set; }
            public int ParentResponsibilityUnitId { get; set; }
            public int BusinessUnitId { get; set; }
            public int PSId { get; set; }
            public string PSName { get; set; }
            public bool IsAdmin { get; set; }
            public string RespUnitTypeCode { get; set; }
            public CurrentPeriod CurrentPeriod { get; set; }
            public List<string> Permissions { get; set; }
            public int OrganizationId { get; set; }
            public List<int> ProductIds { get; set; }
            public string LensConnection { get; set; }
            public int ExternalUserType { get; set; }
        }

        public class User
        {
            public bool success { get; set; }
            public Data data { get; set; }
        }




    }
}
