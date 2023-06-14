using System.Text.Json.Serialization;

namespace SharedModels.Models.EventParticipants;
#nullable disable
public class ParticipantNode
{
    [JsonPropertyName("user")]
    public Participant User { get; set; }
}