using BlazorApp.Model;

namespace BlazorApp.Services;

public class ParticipationWinnerSelector
{
    public async Task<Participant> SelectWinner(List<Participant> participants, bool includeHosts)
    {
        await Task.CompletedTask;
        var possibleWinners = participants;
        if (!includeHosts)
        {
            possibleWinners = participants.Where(x => !x.EventHost).ToList();
        }

        var random = new Random(DateTime.Now.Millisecond);
        return possibleWinners[random.Next(possibleWinners.Count)];
    }
}