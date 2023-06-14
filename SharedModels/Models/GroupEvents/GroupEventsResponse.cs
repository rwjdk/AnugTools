using System.Text.Json.Serialization;

namespace SharedModels.Models.GroupEvents;
#nullable disable
public class GroupEventsResponse
{
    [JsonPropertyName("groupByUrlname")]
    public GroupEventRoot Root { get; set; }

    public IReadOnlyList<Event> GetAllEvents()
    {
        var result = Root.Past.Edges.Select(x => x.Node).ToList();
        result.AddRange(Root.Upcoming.Edges.Select(x=> x.Node));
        return result.OrderByDescending(x=> x.Date).ToList();
    }
}