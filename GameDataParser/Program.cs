using System.Text.Json;

var app = new GameDataParserApp();

app.run();
Console.ReadKey();

public class GameDataParserApp
{
    private UserInteraction _userInteraction = new UserInteraction();
    bool FileReadFlag = false;
    string fetchFile = default;
    public void run()
    {
        do
        {
            try
            {
                _userInteraction.AskUserAFileName();

                var fileNameFromUser = _userInteraction.GetFileNameFromUser();

                fetchFile = File.ReadAllText(fileNameFromUser);

                FileReadFlag = true;
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("File name cannot be null.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("File name cannot be empty.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found.");
            }
        }
        while (!FileReadFlag);

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