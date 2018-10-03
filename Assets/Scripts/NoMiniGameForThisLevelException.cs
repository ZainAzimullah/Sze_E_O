using System;
using System.Runtime.Serialization;

[Serializable]
internal class NoMiniGameForThisLevelException : Exception
{
    public NoMiniGameForThisLevelException()
    {
    }

    public NoMiniGameForThisLevelException(string message) : base(message)
    {
    }

    public NoMiniGameForThisLevelException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NoMiniGameForThisLevelException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}