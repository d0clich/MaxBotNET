using MaxBot.Objects.Buttons;

namespace MaxBot.Objects.Payloads
{
    public class InlineKeyboardAttachmentRequestPayload: Payload
    {
        Button[,] Buttons { get; set; } = new Button[,] { };
    }
}
