public class Playlist : SongCollection
{
    public Person Owner;

    public Playlist(Person owner, string title) : base(title)
    {
        Owner = owner;
        Title = title;
    }

    public void Add(IPlayable playable) => playables.Add(playable);
    public void Remove(IPlayable playable) => playables.Remove(playable);

    public override string ToString() => $"Playlist: {Title}, Owner: {Owner.Naam}";
}