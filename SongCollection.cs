using System.Collections.Generic;

public class SongCollection
{
    // Fields
    public string Title;
    private List<iPlayable> playables;

    // Constructor
    public SongCollection(string title)
    {
        Title = title;
    }

    // Methods
    public override string ToString()
    {
        return "";
    }

    public List<iPlayable> ShowPlayables()
    {

    }
}