namespace ESSMaterWebApp.Models;

public partial class Questionnaire
{
    /// <summary>
    /// Unique identifier for the questionnaire.
    /// </summary>
    public int QuestionnaireId { get; set; }

    /// <summary>
    /// Collection of diagnoses associated with the questionnaire.
    /// </summary>
    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    /// <summary>
    /// Collection of responses associated with the questionnaire.
    /// </summary>
    public virtual ICollection<Response> Responses { get; set; } = new List<Response>();
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 