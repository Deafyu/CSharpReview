namespace CSharpReview;

public class InvalidPayloadException : Exception
{
    public InvalidPayloadException()
    {
    }

    public InvalidPayloadException(string reason)
        : base(reason)
    {
    }
}