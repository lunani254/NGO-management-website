namespace ESSMaterWebApp.Models;

public partial class Diagnosis
{
    /// <summary>
    /// Unique identifier for the diagnosis.
    /// </summary>
    public int DiagnosisId { get; set; }

    /// <summary>
    /// Details of the assessment.
    /// </summary>
    public string? AssessmentDetails { get; set; }

    /// <summary>
    /// Identifier for the related diagnosis questionnaire.
    /// </summary>
    public int? DiagnosisQuestionnaireId { get; set; }

    /// <summary>
    /// Related diagnosis questionnaire.
    /// </summary>
    public virtual Questionnaire? DiagnosisQuestionnaire { get; set; }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 