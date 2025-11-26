using MaxBot.Objects.Users;

namespace MaxBot.Objects
{
    public class Callback
    {
        public long Timestamp { get; set; }
        public string CallbackId { get; set; }
        public string Payload { get; set; }
        public User User { get; set; }
    }
}
