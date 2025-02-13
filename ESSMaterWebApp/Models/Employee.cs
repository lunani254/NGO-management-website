namespace ESSMaterWebApp.Models;

public partial class Employee
{
    /// <summary>
    /// Unique identifier for the employee.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// First name of the employee.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Surname of the employee.
    /// </summary>
    public string Surname { get; set; } = null!;

    /// <summary>
    /// Email address of the employee.
    /// </summary>
    public string EmailAddress { get; set; } = null!;

    /// <summary>
    /// Phone number of the employee.
    /// </summary>
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// Role of the employee.
    /// </summary>
    public string Role { get; set; } = null!;

    /// <summary>
    /// Job description of the employee.
    /// </summary>
    public string JobDescription { get; set; } = null!;
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 