namespace KISSMp3MoverBefore.Factories
{
    using System;
    using Contracts;
    using Strategies.RenameStrategies;

    public class FileRenameStrategyFactory : IFileRenameStrategyFactory
    {
        public IFileRenameStrategy Get(string type)
        {
            switch (type)
            {
                case "RemoveArtist": return new RemoveArtistRenameStrategy();
                default: throw new ArgumentException("Invalid move strategy");
            }
        }
    }
}
