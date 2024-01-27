namespace GameDataParser.FileInteraction
{
    public class PrintLoadedGames
    {
        public void PrintGamesList(List<VideoGame> list)
        {
            if (list.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Loaded games are:");
                foreach (var singleGame in list)
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
}
