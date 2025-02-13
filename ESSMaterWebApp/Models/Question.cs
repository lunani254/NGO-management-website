namespace ESSMaterWebApp.Models;

public partial class Question
{
    /// <summary>
    /// Unique identifier for the question.
    /// </summary>
    public int QuestionId { get; set; }

    /// <summary>
    /// Description of the question.
    /// </summary>
    public string QuestionDescription { get; set; } = null!;

    /// <summary>
    /// Collection of responses associated with the question.
    /// </summary>
    public virtual ICollection<Response> Responses { get; set; } = new List<Response>();
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 