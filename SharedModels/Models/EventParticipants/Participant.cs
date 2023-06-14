using System.Text.Json.Serialization;

namespace SharedModels.Models.EventParticipants;

public class Participant
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("isLeader")]
    public bool EventHost { get; set; }
    [JsonPropertyName("memberUrl")]
    public string Url { get; set; }
    public bool Winner { get; set; }

    public Participant(string name, bool eventHost, string url)
    {
        Name = name;
        EventHost = eventHost;
        Url = url;
    }

    public Participant()
    {
        //Serialization
    }
}