namespace CollegeApp.Exceptions;

//public class CustomException(string Message) : Exception(Message)
//{
//}


public class CustomException : Exception
{
    public CustomException(string Message) : base(Message) { }
}
