public class Person
{
    // Properties
    public string Naam { get; set; }
    private List<Person> Friends { get; set; }
    public List<Playlist> Playlists { get; set; }
    protected Playlist? CurrentPlaylist { get; set; } 
    

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

    public void AddFriend(Person person) => Friends.Add(person);
    public void RemoveFriend(Person person) => Friends.Remove(person);
}