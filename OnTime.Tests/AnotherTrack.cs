using System;

namespace OnTime.Tests
{
    public class AnotherTrack : ITrack
    {
        public int Title { get; set; }
        public DateTime Start { get; }
        public DateTime Stop { get; }
    }
}