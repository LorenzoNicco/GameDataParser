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

        var fileNameFromUser = Console.ReadLine();

        var fetchFile = File.ReadAllText(fileNameFromUser);

        var videoGamesList = JsonSerializer.Deserialize<List<VideoGame>>(fetchFile);
    }
}

public class UserInteraction
{
    public void AskUserAFileName()
    {
        Console.WriteLine("Enter the name of the file you want to read:");
    }
}

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }
}