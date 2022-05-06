namespace LogMiddleWare.Models
{
#nullable disable
    public class LogVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Ip { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public string QueryString { get; set; }
        public string Schema { get; set; }
        public string Event { get; set; }
    }
}
