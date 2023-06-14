using System.Text.Json.Serialization;

namespace SharedModels.Models.GroupEvents;

public class EventEdge
{
    [JsonPropertyName("node")]
    public Event Node { get; set; }
}