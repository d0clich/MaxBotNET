using System.Text.Json.Serialization;
using MaxBot.Objects.Buttons;

namespace MaxBot.Objects.Payloads
{
    public class InlineKeyboardPayload : Payload
    {
        public InlineKeyboardPayload(List<List<Button>> buttons = null)
        {
            Buttons = buttons ?? [];
        }

        [JsonPropertyName("buttons")]
        public List<List<Button>> Buttons { get;}

        public void CreateRow()
        {
            var row = Buttons.LastOrDefault();
            if (row is not { Count: 0 })
                Buttons.Add([]);
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
