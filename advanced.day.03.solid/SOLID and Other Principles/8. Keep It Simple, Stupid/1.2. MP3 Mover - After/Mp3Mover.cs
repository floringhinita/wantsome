namespace KISSMp3MoverAfter
{
    using System;
    using System.IO;

    public static class Mp3Mover
    {
        public static void Main()
        {
            const string directoryPath = @"C:\MyMusic\";

            foreach (var fileName in Directory.EnumerateFiles(directoryPath))
                if (fileName.IndexOf(" - ", StringComparison.Ordinal) >= 0 && fileName.ToLower().EndsWith("mp3"))
                {
                    File.Move(fileName, fileName.Substring(fileName.IndexOf(" - ", StringComparison.Ordinal) + 3));
                    var artist = fileName.Substring(0, fileName.IndexOf(" - ", StringComparison.Ordinal));
                    File.Move(fileName, artist + "/" + fileName);
                }
        }
    }
}
