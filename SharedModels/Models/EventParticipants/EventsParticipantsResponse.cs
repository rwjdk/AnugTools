using System.Text.Json.Serialization;

namespace SharedModels.Models.EventParticipants;
#nullable disable
public class EventsParticipantsResponse
{
    [JsonPropertyName("event")]
    public ParticipantsRoot Root { get; set; }
}