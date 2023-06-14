using System.Text.Json.Serialization;

namespace SharedModels.Models.EventParticipants;

public class EventsParticipantsResponse
{
    [JsonPropertyName("event")]
    public ParticipantsRoot Root { get; set; }
}