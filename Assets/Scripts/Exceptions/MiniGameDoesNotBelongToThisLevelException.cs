using System;
using System.Runtime.Serialization;

[Serializable]
internal class MiniGameDoesNotBelongToThisLevelException : Exception
{
    public MiniGameDoesNotBelongToThisLevelException()
    {
    }

    public MiniGameDoesNotBelongToThisLevelException(string message) : base(message)
    {
    }

    public MiniGameDoesNotBelongToThisLevelException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected MiniGameDoesNotBelongToThisLevelException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}