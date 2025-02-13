namespace ESSMaterWebApp.Models;

public partial class DonationInterest
{
    /// <summary>
    /// Unique identifier for the donation.
    /// </summary>
    public int DonationId { get; set; }

    /// <summary>
    /// First name of the donor.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Surname of the donor.
    /// </summary>
    public string Surname { get; set; } = null!;

    /// <summary>
    /// Country of the donor.
    /// </summary>
    public string Country { get; set; } = null!;

    /// <summary>
    /// Email address of the donor.
    /// </summary>
    public string EmailAddress { get; set; } = null!;

    /// <summary>
    /// Phone number of the donor.
    /// </summary>
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// Amount pledged by the donor.
    /// </summary>
    public string? AmountPledged { get; set; }

    /// <summary>
    /// Date when the donation was submitted.
    /// </summary>
    public DateTime DateSubmitted { get; set; }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 