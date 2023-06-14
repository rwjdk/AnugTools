using System.Text.Json.Serialization;

namespace SharedModels.Models.EventParticipants;

public class ParticipantNode
{
    [JsonPropertyName("user")]
    public Participant User { get; set; }
}