public class SongCollection : IPlayable
{
    public string Title { get; set; }
    protected List<IPlayable> playables;
    public int Length => playables?.Sum(p => p.Length) ?? 0;

    public SongCollection(string title)
    {
        Title = title;
        playables = new List<IPlayable>();
    }

    public void Play()
{
    Console.WriteLine($"Album {Title} wordt afgespeeld:");
    foreach (var playable in playables)
    {
        playable.Play();
    }
}
    public void Pause() { }
    public void Next() { }
    public void Stop() { }

    public List<IPlayable> ShowPlayables() => playables;

    public override string ToString() => Title;
}