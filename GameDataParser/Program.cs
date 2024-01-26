using System.Text.Json;

var app = new GameDataParserApp();

app.run();
Console.ReadKey();

public class GameDataParserApp
{
    private UserInteraction _userInteraction = new UserInteraction();
    public void run()
    {
        _userInteraction.AskUserAFileName();

        var fileNameFromUser = _userInteraction.GetFileNameFromUser();

        var fetchFile = File.ReadAllText(fileNameFromUser);

        var videoGamesList = JsonSerializer.Deserialize<List<VideoGame>>(fetchFile);

        if(videoGamesList.Count > 0 )
        {
            Console.WriteLine();
            Console.WriteLine("Loaded games are:");
            foreach(var singleGame in videoGamesList)
            {
                Console.WriteLine(singleGame);
            }
        }
        else
        {
            Console.WriteLine("No games are present in the input file.");
        }
    }
}

public class UserInteraction
{
    public void AskUserAFileName()
    {
        Console.WriteLine("Enter the name of the file you want to read:");
    }

    public string GetFileNameFromUser() => Console.ReadLine();
}

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString() => $"{Title}, released in: {ReleaseYear}, rating: {Rating}";
}