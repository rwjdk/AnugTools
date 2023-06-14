using System.Text.Json.Serialization;

namespace SharedModels.Models.GroupEvents;

public class GroupEventRoot
{
    [JsonPropertyName("upcomingEvents")]
    public EventList Upcoming { get; set; }
    [JsonPropertyName("pastEvents")]
    public EventList Past { get; set; }
}