namespace LogMiddleWare.Data.Entities
{
#nullable disable
    public class LogEvent
    {

        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
        public string Event { get; set; }
        public string Ip { get; set; }
        public string UserName { get; set; }
        public string QueryString { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}