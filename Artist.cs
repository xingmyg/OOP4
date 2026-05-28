using System;

public class Artist
{
    // Properties
    public string Naam { get; set; }
    private List<Album> Albums { get; set; }
    public int Duur { get; set; }
    private List<Song> Songs { get; set; }

    // Constructor
    public Artist(string naam)
    {
        Naam = naam;
        Albums = new List<Album>();
        Songs = new List<Song>();
    }

    public void AddSong(Song song)
    {
        Songs.Add(song);
    }

    public void AddAlbum(Album album)
    {
        Albums.Add(album);
    }

    public override string ToString()
    {
        return $"Artist: {Naam}, Albums: {Albums.Count}, Songs: {Songs.Count}";
    }
}