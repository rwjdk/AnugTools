using System.Text.Json.Serialization;

namespace SharedModels.Models.EventParticipants;

public class ParticipantList
{
    [JsonPropertyName("edges")]
    public ParticipantEdge[] Edges { get; set; }
}