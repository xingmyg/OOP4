public class SuperUser : Person
{
    private Playlist? CurrentPlaylist { get; set; }

    public SuperUser(string naam) : base(naam) { }

    public Playlist CreatePlayList(string name)
    {
        var playlist = new Playlist(this, name);
        ShowPlaylists().Add(playlist);
        CurrentPlaylist = playlist;
        return playlist;
    }
    public void RemovePlayList(int index) => ShowPlaylists().RemoveAt(index);
    public void AddToPlayList(IPlayable playable) => CurrentPlaylist?.Add(playable);
    public void RemoveFromPlayList(IPlayable playable) => CurrentPlaylist?.Remove(playable); 
    public void AddFriend(Person person)
    {
        if (ShowFriends().Contains(person))
        {
            Console.WriteLine("Deze gebruiker is al een vriend.");
            return;
        }
        ShowFriends().Add(person);
    }
    public void RemoveFriend(Person person) => ShowFriends().Remove(person);
}