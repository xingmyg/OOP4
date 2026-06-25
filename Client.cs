public class Client
{
    public IPlayable? CurrentlyPlaying;
    public int CurrentTime;
    public bool Playing;
    public bool Shuffle;
    public bool Repeat;
    private SuperUser? ActiveUser;
    private List<Album> AllAlbums;
    private List<Song> AllSongs;
    private List<Person> AllUsers;

    public Client(List<Person> allUsers, List<Album> allAlbums, List<Song> allSongs)
    {
        AllUsers = allUsers;
        AllAlbums = allAlbums;
        AllSongs = allSongs;
    }

    public void SetActiveUser(Person user) => ActiveUser = (SuperUser)user;

    public void ShowAllAlbums() { }
    public void ShowAllSongs() { }
    public void ShowAllUsers() { }

    public void SelectAlbum(int index) => CurrentlyPlaying = AllAlbums[index];
    public void SelectSong(int index) => CurrentlyPlaying = AllSongs[index];
    public void SelectUser(int index) => SetActiveUser(AllUsers[index]);

    public void ShowUserPlaylists() { }
    public void SelectUserPlaylists(int index) { }

    public void Play() => Playing = true;
    public void Pause() => Playing = false;
    public void StopSong()
    {
        CurrentlyPlaying?.Stop();
        CurrentlyPlaying = null;
        Playing = false;
    }
    public void NextSong()
    {
        if (CurrentlyPlaying == null) return;

        int HuidigIndex = AllSongs.IndexOf((Song)CurrentlyPlaying);
        if (HuidigIndex + 1 < AllSongs.Count)
        {
            SelectSong(HuidigIndex + 1);
            CurrentlyPlaying?.Play();
        }
        else
        {
            Console.WriteLine("Geen volgend nummer beschikbaar.");
        }
    }
    
    public void SetShuffle(bool shuffle) => Shuffle = shuffle;
    public void SetRepeat(bool repeat) => Repeat = repeat;

    public Playlist? CreatePlaylist(string title) => ActiveUser?.CreatePlayList(title);
    public void ShowPlaylists()
{
    var playlists = ActiveUser?.ShowPlaylists();
    if (playlists == null || playlists.Count == 0)
    {
        Console.WriteLine("Je hebt nog geen playlists.");
        return;
    }

    for (int i = 0; i < playlists.Count; i++)
        Console.WriteLine($"{i + 1}. {playlists[i]}");

    Console.WriteLine("\nKies een playlist (of 0 om terug te gaan):");
    int keuze = int.Parse(Console.ReadLine() ?? "0");

    if (keuze >= 1 && keuze <= playlists.Count)
    {
        ShowSongsInPlaylist(keuze - 1);

        Console.WriteLine("\nWil je deze playlist afspelen? (j/n)");
        if (Console.ReadLine() == "j")
        {
            CurrentlyPlaying = playlists[keuze - 1];
            CurrentlyPlaying.Play();
        }
    }
}
    public void SelectPlaylist(int index) => ActiveUser?.SelectPlaylist(index);
    public void RemovePlaylist(int index) => ActiveUser?.RemovePlayList(index);
    public void AddToPlaylist(int index) => ActiveUser?.AddToPlayList(AllSongs[index]);
    public void ShowSongsInPlaylist(int index)
{
    var songs = ActiveUser?.SelectPlaylist(index).GetSongs();

    if (songs == null || songs.Count == 0)
    {
        Console.WriteLine("Deze speellijst is leeg.");
        return;
    }

    foreach (var song in songs)
        Console.WriteLine(song);
}
    public void RemoveFromPlaylist(int index) => ActiveUser?.RemoveFromPlayList(AllSongs[index]);

    public void ShowFriends() { }
    public void SelectFriend() { }
    public void AddFriend(int index) => ActiveUser?.AddFriend(AllUsers[index]);
    public void RemoveFriend(int index) => ActiveUser?.RemoveFriend(AllUsers[index]);
}