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

//songs
List<Song> songs = new List<Song>
{
    song1, song2, song3, song4, song5, song6, song7, song8, song9, song10
};

//albums
List<Album> albums = new List<Album>
{
    new Album(new List<Artist> { artist1 }, "Divide", new List<Song> { song1, song2, song3 }),
    new Album(new List<Artist> { artist1 }, "Plus", new List<Song> { song4, song5, song6 }),
};

SuperUser user1 = new SuperUser("Jij");
SuperUser user2 = new SuperUser("Donald");
SuperUser user3 = new SuperUser("Maud");
SuperUser user4 = new SuperUser("Joris");
SuperUser user5 = new SuperUser("Lisa");

List<Person> users = new List<Person> { user2, user3, user4, user5 };

Client client = new Client(users, albums, songs);
client.SetActiveUser(user1);

while (true)
{
    Console.WriteLine("\nWat wil je doen?");
    Console.WriteLine("1. Albums bekijken");
    Console.WriteLine("2. Alle nummers bekijken");
    Console.WriteLine("3. Playlist maken");
    Console.WriteLine("4. Vrienden beheren");
    Console.WriteLine("0. Stoppen");

    int HoofdKeuze = int.Parse(Console.ReadLine() ?? "0");

    if (HoofdKeuze == 0)
    {
        Console.WriteLine("Tot ziens!");
        break;
    }
    else if (HoofdKeuze == 1)
    {
        Console.WriteLine("\nKies een album:");
        for (int i = 0; i < albums.Count; i++)
            Console.WriteLine($"{i + 1}. {albums[i]}");

        int AlbumKeuze = int.Parse(Console.ReadLine() ?? "0");

        if (AlbumKeuze >= 1 && AlbumKeuze <= albums.Count)
            albums[AlbumKeuze - 1].Play();
    }
    else if (HoofdKeuze == 2)
    {
        Console.WriteLine("\nKies een nummer:");
        for (int i = 0; i < songs.Count; i++)
            Console.WriteLine($"{i + 1}. {songs[i]}");

        int NummerKeuze = int.Parse(Console.ReadLine() ?? "0");

        if (NummerKeuze >= 1 && NummerKeuze <= songs.Count)
        {
            client.SelectSong(NummerKeuze - 1);
            client.Play();

            Console.WriteLine("Volgende nummer? (j/n)");
            if (Console.ReadLine() == "j")
                client.NextSong();
            else
                Console.WriteLine("Geen volgend nummer geselecteerd.");

            Console.WriteLine("Stop? (j/n)");
            if (Console.ReadLine() == "j")
                client.StopSong();
            else
                Console.WriteLine("Nummer wordt niet gestopt.");
        }
    }
    else if (HoofdKeuze == 3)
    {
        Console.WriteLine("\nGeef je playlist een naam:");
        string? Input = Console.ReadLine();
        string Naam = string.IsNullOrWhiteSpace(Input) ? "Mijn Playlist" : Input;
        client.CreatePlaylist(Naam);

        bool Doorgaan = true;
        while (Doorgaan)
        {
            Console.WriteLine("\nKies een nummer om toe te voegen (of 0 om te stoppen):");
            for (int i = 0; i < songs.Count; i++)
                Console.WriteLine($"{i + 1}. {songs[i]}");

            int SongKeuze = int.Parse(Console.ReadLine() ?? "0");

            if (SongKeuze == 0)
            {
                Doorgaan = false;
            }
            else if (SongKeuze >= 1 && SongKeuze <= songs.Count)
            {
                client.AddToPlaylist(SongKeuze - 1);
                Console.WriteLine($"{songs[SongKeuze - 1].Title} toegevoegd!");
            }
        }

        client.ShowSongsInPlaylist(0);
    }
    else if (HoofdKeuze == 4)
    {
        while (true)
        {
            Console.WriteLine("\nWat wil je doen?");
            Console.WriteLine("1. Vriend toevoegen");
            Console.WriteLine("2. Vriend verwijderen");
            Console.WriteLine("3. Vrienden bekijken");
            Console.WriteLine("0. Terug naar hoofdmenu");

            int VriendKeuze = int.Parse(Console.ReadLine() ?? "0");

            if (VriendKeuze == 1)
            {
                Console.WriteLine("\nKies een gebruiker om toe te voegen als vriend:");
                for (int i = 0; i < users.Count; i++)
                    Console.WriteLine($"{i + 1}. {users[i].Naam}");

                int UserKeuze = int.Parse(Console.ReadLine() ?? "0");

                if (UserKeuze >= 1 && UserKeuze <= users.Count)
                {
                    client.AddFriend(UserKeuze - 1);
                    Console.WriteLine($"{users[UserKeuze - 1].Naam} toegevoegd als vriend!");
                }
            }
            else if (VriendKeuze == 2)
            {
                var Vrienden = client.GetFriends();
                if (Vrienden == null || Vrienden.Count == 0)
                {
                    Console.WriteLine("Je hebt nog geen vrienden.");
                }
                else
                {
                    client.ShowFriends();
                    Console.WriteLine("\nKies een nummer om te verwijderen:");

                    int VerwijderKeuze = int.Parse(Console.ReadLine() ?? "0");

                    if (VerwijderKeuze >= 0 && VerwijderKeuze < Vrienden.Count)
                    {
                        client.RemoveFriend(VerwijderKeuze);
                        Console.WriteLine("Vriend verwijderd.");
                    }
                    else
                    {
                        Console.WriteLine("Ongeldige keuze.");
                    }
                }
            }
            else if (VriendKeuze == 3)
            {
                client.ShowFriends();
            }
            else if (VriendKeuze == 0)
            {
                break;
            }
        }
    }
    else
    {
        Console.WriteLine("Ongeldige keuze");
    }
}