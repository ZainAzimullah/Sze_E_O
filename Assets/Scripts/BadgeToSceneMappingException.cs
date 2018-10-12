using System;
using System.Runtime.Serialization;

[Serializable]
internal class BadgeToSceneMappingException : Exception
{
    public BadgeToSceneMappingException()
    {
    }

    public BadgeToSceneMappingException(string message) : base(message)
    {
    }

    public BadgeToSceneMappingException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected BadgeToSceneMappingException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}