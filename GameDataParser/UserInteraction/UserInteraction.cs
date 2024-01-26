namespace GameDataParser.UserInteraction
{    public class UserInteraction
    {
        public void AskUserAFileName()
        {
            Console.WriteLine("Enter the name of the file you want to read:");
        }

        public string GetFileNameFromUser() => Console.ReadLine();
    }
}
