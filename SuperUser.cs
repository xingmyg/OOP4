public class SuperUser : Person
{
    public SuperUser(string naam) : base(naam) { }

    public Playlist CreatePlayList(string name)
    {
        var playlist = new Playlist(this, name);
        Playlists.Add(playlist);
        return playlist;
    }

    public void RemovePlayList(int index) => Playlists.RemoveAt(index);
    public void AddToPlayList(IPlayable playable) => CurrentPlaylist?.Add(playable);
    public void RemoveFromPlayList(IPlayable playable) => CurrentPlaylist?.Remove(playable);
}