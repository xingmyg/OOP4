Artist artist1 = new Artist("Ed Sheeran");

List<Song> songs = new List<Song>
{
    new Song("Shape of You", new List<Artist> { artist1 }, 234, Genre.Pop),
    new Song("Perfect", new List<Artist> { artist1 }, 263, Genre.Pop),
    new Song("Thinking Out Loud", new List<Artist> { artist1 }, 281, Genre.Pop),
    new Song("Bad Habits", new List<Artist> { artist1 }, 231, Genre.Pop),
    new Song("Shivers", new List<Artist> { artist1 }, 207, Genre.Pop),
    new Song("Castle on the Hill", new List<Artist> { artist1 }, 261, Genre.Pop),
    new Song("Galway Girl", new List<Artist> { artist1 }, 170, Genre.Pop),
    new Song("Don't", new List<Artist> { artist1 }, 219, Genre.Pop),
    new Song("Lego House", new List<Artist> { artist1 }, 193, Genre.Pop),
    new Song("Photograph", new List<Artist> { artist1 }, 258, Genre.Pop)
};

Console.WriteLine("Kies een nummer:");
for (int i = 0; i < songs.Count; i++)
{
    Console.WriteLine($"{i + 1}. {songs[i]}");
}

int keuze = int.Parse(Console.ReadLine() ?? "0");

if (keuze >= 1 && keuze <= songs.Count)
{
    songs[keuze - 1].Play();
}
else
{
    Console.WriteLine("Ongeldige keuze");
}