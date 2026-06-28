public interface IPlayable
{
    string Title { get; set; }
    int Length { get;}
    void Play();
    void Pause();

    void Stop();
}