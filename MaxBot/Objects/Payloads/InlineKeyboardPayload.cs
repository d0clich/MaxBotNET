using System.Text.Json.Serialization;
using MaxBot.Objects.Buttons;

namespace MaxBot.Objects.Payloads
{
    public class InlineKeyboardPayload : Payload
    {
        [JsonPropertyName("buttons")]
        public List<List<Button>> Buttons { get; set; } = new();

        public void CreateRow()
        {
            var row = Buttons.LastOrDefault();
            if (row == null || row.Count != 0)
                Buttons.Add(new List<Button>());
        }

        public void AddButton(Button button)
        {
            var row = Buttons.LastOrDefault();
            if (row == null)
                throw new ArgumentNullException(nameof(row), "Create row before adding buttons");

            row.Add(button);
        }
    }
}
