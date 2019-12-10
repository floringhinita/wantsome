namespace KISSMp3MoverBefore
{
    using Factories;

    public class Mp3MoverProgram
    {
        public static void Main()
        {
            var mp3Mover = Mp3Mover.Instance;
            mp3Mover.DirectoryPath = @"C:\MyMusic\";
            mp3Mover.SelectStrategy = new FileSelectStrategyFactory().Get("ArtistDashSong");
            mp3Mover.RenameStrategy = new FileRenameStrategyFactory().Get("RemoveArtist");
            mp3Mover.MoveStrategy = new FileMoveStrategyFactory().Get("Normal");
            mp3Mover.Start();
        }
    }
}
