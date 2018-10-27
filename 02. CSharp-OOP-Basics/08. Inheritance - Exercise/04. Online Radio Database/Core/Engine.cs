using System;
using System.Collections.Generic;
using System.Text;
using Exercise.Exceptions;

namespace Exercise.Core
{
    public class Engine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int totalSeconds = 0;
            int songsCounter = 0;

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                string artistName = data[0];
                string songName = data[1];
                int minutes = 0;
                int seconds = 0;

                bool isMinutes = int.TryParse(data[2].Split(":")[0], out minutes);
                bool isSeconds = int.TryParse(data[2].Split(":")[1], out seconds);

                if (!isMinutes || !isSeconds)
                {
                    InvalidSongLengthException ex = new InvalidSongLengthException();
                    Console.WriteLine(ex.Message);
                    continue;
                }

                try
                {
                    Song radio = new Song(artistName, songName, minutes, seconds);
                    Console.WriteLine("Song added.");
                    totalSeconds += (minutes * 60) + seconds;
                    songsCounter++;
                }
                catch (Exception ex)
                {
                    if (ex is InvalidSongException || ex is InvalidArtistNameException ||
                        ex is InvalidSongNameException || ex is InvalidSongLengthException ||
                        ex is InvalidSongMinutesException || ex is InvalidSongSecondsException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            Console.WriteLine($"Songs added: {songsCounter}");
            var time = TimeSpan.FromSeconds(totalSeconds);
            Console.WriteLine($"Playlist length: {time.Hours}h {time.Minutes}m {time.Seconds}s");
        }
    }
}
