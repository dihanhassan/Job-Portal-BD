namespace JobPortal.API.Models.Log
{
    public class CustomLog
    {
        public int ? LogId { get; set; }
        public string UserID {  get; set; }
        public DateTime ActionTime = DateTime.Now;
        public string ? ActionType { get; set; } = string.Empty;
        public string ? ActionField { get; set; } = string.Empty;

        public string ? jsonPayload { get; set; } = string.Empty;

    }
}
