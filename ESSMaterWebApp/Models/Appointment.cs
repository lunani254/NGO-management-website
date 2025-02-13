namespace ESSMaterWebApp.Models;

public partial class Appointment
{
    /// <summary>
    /// Unique identifier for the appointment.
    /// </summary>
    public int AppointmentId { get; set; }

    /// <summary>
    /// Type of service for the appointment.
    /// </summary>
    public string ServiceType { get; set; } = null!;

    /// <summary>
    /// First name of the person who made the appointment.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Surname of the person who made the appointment.
    /// </summary>
    public string Surname { get; set; } = null!;

    /// <summary>
    /// Email address of the person who made the appointment.
    /// </summary>
    public string EmailAddress { get; set; } = null!;

    /// <summary>
    /// Phone number of the person who made the appointment.
    /// </summary>
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// Country of the person who made the appointment.
    /// </summary>
    public string Country { get; set; } = null!;

    /// <summary>
    /// Province of the person who made the appointment.
    /// </summary>
    public string Province { get; set; } = null!;

    /// <summary>
    /// City of the person who made the appointment.
    /// </summary>
    public string City { get; set; } = null!;

    /// <summary>
    /// Suburb of the person who made the appointment.
    /// </summary>
    public string Suburb { get; set; } = null!;

    /// <summary>
    /// Date and time when the appointment was submitted.
    /// </summary>
    public DateTime SubmissionDate { get; set; }

    /// <summary>
    /// Date and time of the appointment.
    /// </summary>
    public DateTime AppointmentDate { get; set; }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 