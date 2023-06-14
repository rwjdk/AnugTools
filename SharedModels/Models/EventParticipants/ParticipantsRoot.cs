using System.Text.Json.Serialization;

namespace SharedModels.Models.EventParticipants;
#nullable disable
public class ParticipantsRoot
{
    [JsonPropertyName("tickets")]
    public ParticipantList Tickets { get; set; }
}