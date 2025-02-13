namespace ESSMaterWebApp.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Request identifier.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the request identifier should be shown.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 