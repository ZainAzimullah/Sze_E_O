using System;
using System.Runtime.Serialization;

[Serializable]
internal class NoInteractionControllerForThisLevelException : Exception
{
    public NoInteractionControllerForThisLevelException()
    {
    }

    public NoInteractionControllerForThisLevelException(string message) : base(message)
    {
    }

    public NoInteractionControllerForThisLevelException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NoInteractionControllerForThisLevelException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}