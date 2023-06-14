using System.Text.Json.Serialization;

namespace SharedModels.Models.GroupEvents;

public class EventList
{
    [JsonPropertyName("edges")]
    public EventEdge[] Edges { get; set; }
}