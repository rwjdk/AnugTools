namespace BlazorApp.Model;

public class Participant
{
    public string Name { get; }
    public bool EventHost { get; }
    public string Url { get; }

    public Participant(string name, bool eventHost, string url)
    {
        Name = name;
        EventHost = eventHost;
        Url = url;
    }
}