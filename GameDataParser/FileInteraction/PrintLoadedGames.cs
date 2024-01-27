namespace GameDataParser.FileInteraction
{
    //CLASSE PER STAMPARE I GIOCHI
    public class PrintLoadedGames
    {
        //METODO PER STAMPARE
        public void PrintGamesList(List<VideoGame> list)
        {
            //Se nella lista reperita sono presenti dei giochi, li stampiamo a schermo, uno per riga
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
