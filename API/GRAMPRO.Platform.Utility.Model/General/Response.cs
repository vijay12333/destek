namespace GRAMPRO.Platform.Utility.Model
{
    public class Response
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public ApiStatus Status { get; set; }
        public string Message { get; set; }

    }
     public class AuthResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

    }


    public enum ApiStatus
    {
        success = 1,
        fail = 0,
        exception = 0

    }
}