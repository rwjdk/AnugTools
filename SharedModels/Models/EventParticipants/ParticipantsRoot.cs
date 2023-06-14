using System.Text.Json.Serialization;

namespace SharedModels.Models.EventParticipants;

public class ParticipantsRoot
{
    [JsonPropertyName("tickets")]
    public ParticipantList Tickets { get; set; }
}