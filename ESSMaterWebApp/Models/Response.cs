namespace ESSMaterWebApp.Models;

public partial class Response
{
    /// <summary>
    /// Unique identifier for the response.
    /// </summary>
    public int ResponseId { get; set; }

    /// <summary>
    /// Response text.
    /// </summary>
    public string? Response1 { get; set; }

    /// <summary>
    /// Date when the response was submitted.
    /// </summary>
    public DateTime? SubmissionDate { get; set; }

    /// <summary>
    /// Value indicating whether the response is "Strongly Disagree".
    /// </summary>
    public bool? StronglyDisagree { get; set; }

    /// <summary>
    /// Value indicating whether the response is "Disagree".
    /// </summary>
    public bool? Disagree { get; set; }

    /// <summary>
    /// Value indicating whether the response is "Neutral".
    /// </summary>
    public bool? Neutral { get; set; }

    /// <summary>
    /// Value indicating whether the response is "Agree".
    /// </summary>
    public bool? Agree { get; set; }

    /// <summary>
    /// Value indicating whether the response is "Strongly Agree".
    /// </summary>
    public bool? StronglyAgree { get; set; }

    /// <summary>
    /// Identifier of the associated question.
    /// </summary>
    public int? ResponseQuestionId { get; set; }

    /// <summary>
    /// Identifier of the associated questionnaire.
    /// </summary>
    public int? ResponseQuestionnaireId { get; set; }

    /// <summary>
    /// Associated question.
    /// </summary>
    public virtual Question? ResponseQuestion { get; set; }

    /// <summary>
    /// Associated questionnaire.
    /// </summary>
    public virtual Questionnaire? ResponseQuestionnaire { get; set; }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 