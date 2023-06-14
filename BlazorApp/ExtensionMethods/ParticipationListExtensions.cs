using SharedModels.Models.EventParticipants;

namespace BlazorApp.ExtensionMethods;

public static class ParticipationListExtensions
{
    public static IReadOnlyList<Participant> OrderByWinnersThenName(this IEnumerable<Participant> participants)
    {
        return participants.OrderByDescending(x => x.Winner).ThenBy(x => x.Name).ToList();
    }
}