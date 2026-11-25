namespace FlexibleNotification.Shared
{
    public class Result
    {
        public bool IsSuccess { get; init; }
        public string Message { get; init; } = string.Empty;
        public bool IsFailure => !IsSuccess;
    }
}
