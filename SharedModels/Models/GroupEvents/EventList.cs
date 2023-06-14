using System.Text.Json.Serialization;

namespace SharedModels.Models.GroupEvents;
#nullable disable
public class EventList
{
    [JsonPropertyName("edges")]
    public EventEdge[] Edges { get; set; }
}