using System.Text.Json.Serialization;

namespace SharedModels.Models.EventParticipants;

public class ParticipantEdge
{
    [JsonPropertyName("node")]
    public ParticipantNode Node { get; set; }
}