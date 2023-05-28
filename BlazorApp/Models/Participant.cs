namespace BlazorApp.Models;


public class Participant
{
    public string Name { get; }
    public bool EventHost { get; }
    public string Url { get; }
    public bool Winner { get; set; }

    public Participant(string name, bool eventHost, string url)
    {
        Name = name;
        EventHost = eventHost;
        Url = url;
    }
}