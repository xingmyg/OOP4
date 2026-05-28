public class Playlist : SongCollection
{
    public Person Owner;

    public Playlist(Person owner, string title)
    {
        Owner = owner;
        Title = title;
    }

    public void Add(iPlayable playable) => playables.Add(playable);

    public void Remove(iPlayable playable) => playables.Remove(playable);

    public override string ToString() => $"Playlist: {Title}, Owner: {Owner.Naam}";
}