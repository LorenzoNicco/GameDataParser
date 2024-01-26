﻿using GameDataParser.FileInteraction;
using GameDataParser.UserInteraction;
using System.Text.Json;

public class GameDataParserApp
{
    private UserInteraction _userInteraction = new UserInteraction();
    bool FileReadFlag = false;
    string fetchFile = default;
    string fileNameFromUser = default;

    public void run()
    {
        do
        {
            try
            {
                _userInteraction.AskUserAFileName();

                fileNameFromUser = _userInteraction.GetFileNameFromUser();

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

        List<VideoGame> videoGamesList = default;

        try
        {
            videoGamesList = JsonSerializer.Deserialize<List<VideoGame>>(fetchFile);
        }
        catch(JsonException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"JSON in the {fileNameFromUser}  was not in a valid format. JSON body:");
            Console.WriteLine(fetchFile);

            Console.ForegroundColor = ConsoleColor.White;

            throw new JsonException($"{ex.Message} The file is: {fileNameFromUser}", ex);
        }

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