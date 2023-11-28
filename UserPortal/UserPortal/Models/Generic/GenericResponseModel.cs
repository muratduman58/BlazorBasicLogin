namespace UserPortal.Models.Generic
{
    public class GenericResponseModel
    {
        public bool isOk { get; set; }
        public string Message { get; set; }
        public object Model { get; set; }
    }
}
