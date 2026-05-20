public class Person
{
    // Properties
    public string Naam { get; set; }
    public List<Person> Friends { get; set; }
    public List<Playlist> Playlists { get; set; }

    // Constructor
    public Person(string naam)
    {
        Naam = naam;
        Friends = new List<Person>();
        Playlists = new List<Playlist>();
    }

    // Methoden
    public List<Person> ShowFriends()
    {
        return Friends;
    }

    public Playlist SelectPlaylist(int index)
    {
        return Playlists[index];
    }

    public override string ToString()
    {
        return $"Person: {Naam}, Friends: {Friends.Count}, Playlists: {Playlists.Count}";
    }
}