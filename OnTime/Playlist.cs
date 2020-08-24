using System;
using System.Collections.Generic;
using System.Linq;

namespace OnTime
{
    public class Playlist<T> where T : class, ITrack
    {
        private readonly LinkedList<T> _tracks;
        private T _current;

        public Playlist(string title = null)
        {
            Title = title ?? Guid.NewGuid().ToString();
            _tracks = new LinkedList<T>();
        }

        public string Title { get; }

        public T Current()
        {
            return _current;
        }

        public TR Current<TR>() where TR : class, ITrack
        {
            return _current as TR;
        }

        public T Next()
        {
            return _tracks.FirstOrDefault() ?? default;
        }

        public bool TryGetNext(out T track)
        {
            var next = _tracks.FirstOrDefault();
            if (next != null)
            {
                track = next;
                return true;
            }

            track = default;
            return false;
        }

        public void AddTracks(IEnumerable<T> tracks)
        {
            var notYetPlayed = tracks.Where(track => track.Stop >= DateTime.UtcNow.AddHours(2));
            foreach (var track in notYetPlayed) _tracks.AddLast(track);
            var first = _tracks.FirstOrDefault();
            if (_current is null && first != null) _current = first;
            _tracks.RemoveFirst();
        }

        public void PopTrack()
        {
            if (TryGetNext(out _))
            {
                _current = _tracks.First();
                _tracks.RemoveFirst();
            }
        }
    }
}