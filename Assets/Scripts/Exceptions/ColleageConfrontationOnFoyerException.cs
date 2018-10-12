using System;
using System.Runtime.Serialization;

[Serializable]
internal class ColleageConfrontationOnFoyerException : Exception
{
    public ColleageConfrontationOnFoyerException()
    {
    }

    public ColleageConfrontationOnFoyerException(string message) : base(message)
    {
    }

    public ColleageConfrontationOnFoyerException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ColleageConfrontationOnFoyerException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}