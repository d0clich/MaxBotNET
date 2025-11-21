namespace MaxBot.Objects.Types;

public class UploadType: BaseType<UploadType>
{
    public static readonly UploadType Image = new UploadType("image");
    public static readonly UploadType Video = new UploadType("video");
    public static readonly UploadType Audio = new UploadType("audio");
    public static readonly UploadType File = new UploadType("file");
    private UploadType(string type) : base(type)
    {

    }
}