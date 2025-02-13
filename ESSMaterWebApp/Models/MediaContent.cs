namespace ESSMaterWebApp.Models;

public partial class MediaContent
{
    /// <summary>
    /// Unique identifier for the media content.
    /// </summary>
    public int MediaId { get; set; }

    /// <summary>
    /// Title of the media content.
    /// </summary>
    public string MediaTitle { get; set; } = null!;

    /// <summary>
    /// Description of the media content.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Type of media content.
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// URL of the media content.
    /// </summary>
    public string Url { get; set; } = null!;
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 