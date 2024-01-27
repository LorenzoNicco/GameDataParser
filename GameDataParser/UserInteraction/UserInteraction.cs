namespace GameDataParser.UserInteraction
{
    //CLASSE PER INTERAZIONE CON L'UTENTE
    public class UserInteraction
    {
        //METODO PER RICHIESTA DI INPUT DALL'UTENTE
        public void AskUserAFileName()
        {
            Console.WriteLine("Enter the name of the file you want to read:");
        }

        //METODO PER PRENDERE L'INPUT DELL'UTENTE
        public string GetFileNameFromUser() => Console.ReadLine();
    }
}
