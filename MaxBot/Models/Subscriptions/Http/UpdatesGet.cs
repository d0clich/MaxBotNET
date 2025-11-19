using MaxBot.Objects.Types;

namespace MaxBot.Models.Subscriptions.Http
{
    public class UpdatesGet
    {
        public UpdatesGet(UpdateType[]? types = null, int? limit = null, int? timeout = null, int? marker = null)
        {
            Limit = limit;
            Timeout = timeout;
            Marker = marker;
            Types = types;
        }

        public int? Limit { get; set; }
        public int? Timeout { get; set; } 
        public int? Marker { get; set; }
        public UpdateType[]? Types { get; set; }

    }
}
