public class Client
{
    public iPlayable CurrentlyPlaying;
    public int CurrentTime;
    public bool Playing;
    public bool Shuffle;
    public bool Repeat;
    private SuperUser ActiveUser;
    private List<Album> AllAlbums;
    private List<Song> AllSongs;
    private List<Person> AllUsers;

    public Client(List<Person> allUsers, List<Album> allAlbums, List<Song> allSongs)
    {
        AllUsers = allUsers;
        AllAlbums = allAlbums;
        AllSongs = allSongs;
    }

    public void SetActiveUser(Person person) => ActiveUser = (SuperUser)person;

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
    public void Stop() { Playing = false; CurrentTime = 0; }
    public void NextSong() { }
    public void SetShuffle(bool shuffle) => Shuffle = shuffle;
    public void SetRepeat(bool repeat) => Repeat = repeat;

    public Playlist CreatePlaylist(string title) => ActiveUser.CreatePlayList(title);
    public void ShowPlaylists() { }
    public void SelectPlaylist(int index) => ActiveUser.SelectPlaylist(index);
    public void RemovePlaylist(int index) => ActiveUser.RemovePlayList(index);
    public void AddToPlaylist(int index) => ActiveUser.AddToPlayList(AllSongs[index]);
    public void ShowSongsInPlaylist(int index) { }
    public void RemoveFromPlaylist(int index) => ActiveUser.RemoveFromPlayList(AllSongs[index]);

    public void ShowFriends() { }
    public void SelectFriend() { }
    public void AddFriend(int index) => ActiveUser.AddFriend(AllUsers[index]);
    public void RemoveFriend(int index) => ActiveUser.RemoveFriend(AllUsers[index]);
}