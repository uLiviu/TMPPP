﻿namespace Store.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "";
        public string Message { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public User? User { get; set; }
    }
}
