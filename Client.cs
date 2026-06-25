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
    if (playlists == null) return;

    for (int i = 0; i < playlists.Count; i++)
        Console.WriteLine($"{i}: {playlists[i]}");
}
    public void SelectPlaylist(int index) => ActiveUser?.SelectPlaylist(index);
    public void RemovePlaylist(int index) => ActiveUser?.RemovePlayList(index);
    public void AddToPlaylist(int index) => ActiveUser?.AddToPlayList(AllSongs[index]);
    public void ShowSongsInPlaylist(int index)
{
    var playlists = ActiveUser?.ShowPlaylists();
    if (playlists == null || index >= playlists.Count) return;

    var songs = playlists[index].ShowPlayables();
    for (int i = 0; i < songs.Count; i++)
        Console.WriteLine($"{i}: {songs[i]}");
}
    public void RemoveFromPlaylist(int index) => ActiveUser?.RemoveFromPlayList(AllSongs[index]);

    public void ShowFriends()
{
    var friends = ActiveUser?.ShowFriends();
    if (friends == null || friends.Count == 0)
    {
        Console.WriteLine("Geen vrienden gevonden.");
        return;
    }
    for (int i = 0; i < friends.Count; i++)
        Console.WriteLine($"{i}: {friends[i].Naam}");
}
   public List<Person>? GetFriends() => ActiveUser?.ShowFriends();
    public void AddFriend(int index) => ActiveUser?.AddFriend(AllUsers[index]);
   public void RemoveFriend(int index) => ActiveUser?.RemoveFriend(GetFriends()[index]);
}