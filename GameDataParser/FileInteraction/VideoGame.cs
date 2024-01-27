namespace GameDataParser.FileInteraction
{
    //CLASSE PER FORMATTAZIONE DELLA STAMPA PER I GIOCHI
    public class VideoGame
    {
        public string Title { get; init; }
        public int ReleaseYear { get; init; }
        public decimal Rating { get; init; }

        //METODO PER FORMATTARE LA STRINGA DA STAMPARE
        public override string ToString() => $"{Title}, released in: {ReleaseYear}, rating: {Rating}";
    }
}
