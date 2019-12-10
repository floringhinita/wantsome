namespace KISSMp3MoverBefore.Factories
{
    using System;
    using Contracts;
    using Strategies.SelectStrategies;

    public class FileSelectStrategyFactory : IFileSelectStrategyFactory
    {
        public IFileSelectStrategy Get(string type)
        {
            switch (type)
            {
                case "ArtistDashSong": return new ArtistDashSongStrategy();
                default: throw new ArgumentException("Invalid move strategy");
            }
        }
    }
}
