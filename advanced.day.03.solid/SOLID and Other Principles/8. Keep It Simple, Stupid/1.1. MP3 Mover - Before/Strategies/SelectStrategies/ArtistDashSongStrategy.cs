namespace KISSMp3MoverBefore.Strategies.SelectStrategies
{
    using System;
    using Contracts;

    public class ArtistDashSongStrategy : IFileSelectStrategy
    {
        public bool CanBeSelected(string fileName)
        {
            return fileName.IndexOf(" - ", StringComparison.Ordinal) >= 0 && fileName.ToLower().EndsWith("mp3");
        }
    }
}
