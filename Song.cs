public class Song : IPlayable
{
	// Properties
	public string Title { get; set; }
	public List<Artist> Artists { get; set; }
	public Genre SongGenre { get; set; }
	private int Duur { get; set; }

	// Constructor
	public Song(string title, List<Artist> artists, int duur, Genre songGenre)
	{
		Title = title;
		Artists = artists;
		Duur = duur;
		SongGenre = songGenre;
	}

	// IPlayable methoden
	public void Play() { }
	public void Pause() { }
	public void Next() { }
	public void Stop() { }
	public int Length { get; set; }

	public override string ToString()
	{
		return $"Song: {Title}, Duur: {Duur}, Genre: {SongGenre}";
	}
}