using System.Text.Json.Serialization;

namespace SharedModels.Models.EventParticipants;
#nullable disable
public class ParticipantEdge
{
    [JsonPropertyName("node")]
    public ParticipantNode Node { get; set; }
}