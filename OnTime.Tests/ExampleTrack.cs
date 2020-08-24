using System;

namespace OnTime.Tests
{
    public class ExampleTrack : ITrack
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
    }
}