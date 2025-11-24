using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MaxBot.Objects.Types
{
    [JsonConverter(typeof(BaseTypeConverter<FormatType>))]
    public class FormatType : BaseType<FormatType>
    {
        public static FormatType HTML = new FormatType("html");
        public static FormatType Markdown = new FormatType("markdown");
        private FormatType(string  format) : base(format) { }
    }
}
