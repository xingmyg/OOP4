// Artists
Artist artist1 = new Artist("Ed Sheeran");

// Songs
Song song1 = new Song("Shape of You", new List<Artist> { artist1 }, 234, Genre.Pop);
Song song2 = new Song("Perfect", new List<Artist> { artist1 }, 263, Genre.Pop);
Song song3 = new Song("Thinking Out Loud", new List<Artist> { artist1 }, 281, Genre.Pop);
Song song4 = new Song("Bad Habits", new List<Artist> { artist1 }, 231, Genre.Pop);
Song song5 = new Song("Shivers", new List<Artist> { artist1 }, 207, Genre.Pop);
Song song6 = new Song("Castle on the Hill", new List<Artist> { artist1 }, 261, Genre.Pop);
Song song7 = new Song("Galway Girl", new List<Artist> { artist1 }, 170, Genre.Pop);
Song song8 = new Song("Don't", new List<Artist> { artist1 }, 219, Genre.Pop);
Song song9 = new Song("Lego House", new List<Artist> { artist1 }, 193, Genre.Pop);
Song song10 = new Song("Photograph", new List<Artist> { artist1 }, 258, Genre.Pop);

List<Song> songs = new List<Song> 
{ 
    song1, song2, song3, song4, song5, song6, song7, song8, song9, song10 
};

// Albums
List<Album> albums = new List<Album>
{
    new Album(new List<Artist> { artist1 }, "Divide", new List<Song> { song1, song2, song3 }),
    new Album(new List<Artist> { artist1 }, "Plus", new List<Song> { song4, song5, song6 }),
};

//user
SuperUser user = new SuperUser("Jij");

Console.WriteLine("Wat wil je doen?");
Console.WriteLine("1. Albums bekijken");
Console.WriteLine("2. Alle nummers bekijken");
Console.WriteLine("3. Playlist maken");

int hoofdKeuze = int.Parse(Console.ReadLine() ?? "0");

if (hoofdKeuze == 1)
{
    // Stap 1 - Album kiezen
    Console.WriteLine("\nKies een album:");
    for (int i = 0; i < albums.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {albums[i]}");
    }

    int albumKeuze = int.Parse(Console.ReadLine() ?? "0");

    if (albumKeuze >= 1 && albumKeuze <= albums.Count)
    {
        Album gekozenAlbum = albums[albumKeuze - 1];
        gekozenAlbum.Play();
    }
}
else if (hoofdKeuze == 2)
{
    // Alle nummers tonen
    Console.WriteLine("\nKies een nummer:");
    for (int i = 0; i < songs.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {songs[i]}");
    }

    int nummerKeuze = int.Parse(Console.ReadLine() ?? "0");

    if (nummerKeuze >= 1 && nummerKeuze <= songs.Count)
    {
        songs[nummerKeuze - 1].Play();
    }
}
else if (hoofdKeuze == 3)
{
    // playlist maken en nummers erin zetten
    Console.WriteLine("\nGeef je playlist een naam:");
    string naam = Console.ReadLine() ?? "Mijn Playlist";
    Playlist playlist = user.CreatePlayList(naam);

    bool doorgaan = true;
    while (doorgaan == true)
    {
        Console.WriteLine("\nKies een nummer om toe te voegen (of 0 om te stoppen):");
        for (int i = 0; i < songs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {songs[i]}");
        }

        int songKeuze = int.Parse(Console.ReadLine() ?? "0");

        if (songKeuze == 0)
        {
            doorgaan = false;
        }
        else if (songKeuze >= 1 && songKeuze <= songs.Count)
        {
            user.AddToPlayList(songs[songKeuze - 1]);
            Console.WriteLine($"{songs[songKeuze - 1].Title} toegevoegd aan {playlist.Title}!");
        }
    }

    Console.WriteLine($"\nJouw playlist '{playlist.Title}':");
    foreach (var item in playlist.ShowPlayables())
    {
        Console.WriteLine(item);
    }
}
else
{
    Console.WriteLine("Ongeldige keuze");
}