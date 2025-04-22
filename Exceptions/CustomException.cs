namespace CollegeApp.Exceptions;

public class CustomException : Exception
{
    public CustomException(string Message) : base(Message)
    {
    }
}