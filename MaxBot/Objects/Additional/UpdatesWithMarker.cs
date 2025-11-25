using System.Collections;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Additional
{
    public class UpdatesWithMarker: IEnumerable<Update>
    {
        [JsonPropertyName("marker")]
        public long Marker { get; set; }
        [JsonPropertyName("updates")]
        public Update[] Updates { get; set; } = null!;

        public IEnumerator<Update> GetEnumerator()
        {
            return Updates.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Updates.GetEnumerator();
        }
    }
}
