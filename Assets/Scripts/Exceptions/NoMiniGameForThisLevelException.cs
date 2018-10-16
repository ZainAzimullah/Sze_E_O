using System;
using System.Runtime.Serialization;

[Serializable]
internal class NoMinigameRecorderForThisLevel : Exception
{
    public NoMinigameRecorderForThisLevel()
    {
    }

    public NoMinigameRecorderForThisLevel(string message) : base(message)
    {
    }

    public NoMinigameRecorderForThisLevel(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NoMinigameRecorderForThisLevel(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}