using System;

namespace OnTime
{
    public interface ITrack
    {
        DateTime Start { get; }
        DateTime Stop { get; }
    }
}