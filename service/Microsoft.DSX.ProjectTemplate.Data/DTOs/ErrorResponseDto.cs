namespace Microsoft.DSX.ProjectTemplate.Data.DTOs
{
    /// <summary>
    /// JSON format for a HTTP 400-500 response from the API.
    /// </summary>
    public class ErrorResponseDto
    {
        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Inner exception message.
        /// </summary>
        public string InnerExceptionMessage { get; set; }

        /// <summary>
        /// This property is only available in <code>local</code> and <code>dev</code> environments.
        /// </summary>
        public string StackTrace { get; set; }
    }
}
