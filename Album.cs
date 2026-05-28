public class Album : SongCollection
{
    private List<Artist> Artists;

    public Album(List<Artist> artists, string title, List<Song> songs)
    {
        Artists = artists;
        Title = title;
    }

    public List<Artist> ShowArtists() => Artists;

    public override string ToString() => $"Album: {Title}, Artists: {Artists.Count}";
}