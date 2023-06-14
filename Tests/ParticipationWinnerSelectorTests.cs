using SharedModels.Models.EventParticipants;

namespace Tests;

public class ParticipationWinnerSelectorTests
{
    [Fact]
    public void IsRandom()
    {
        for (int x = 0; x < 1000; x++)
        {
            Dictionary<string, int> winners = new Dictionary<string, int>();
            var selector = new BlazorApp.Services.ParticipationWinnerSelector();
            const int draws = 10000;
            const int participantCount = 20;
            for (int i = 0; i < draws; i++)
            {
                var list = new List<Participant>();
                for (int count = 0; count < participantCount; count++)
                {
                    list.Add(new Participant($"Participant {count}", false, string.Empty));
                }
                list.Add(new Participant("Host 1", true, string.Empty));
                list.Add(new Participant("Host 2", true, string.Empty));
                list.Add(new Participant("Host 3", true, string.Empty));
                selector.MarkParticipantsAsWinners(list, false, 1);

                Participant winner = list.First(x => x.Winner);
                Assert.False(winner.EventHost);

                if (winners.ContainsKey(winner.Name))
                {
                    winners[winner.Name]++;
                }
                else
                {
                    winners.Add(winner.Name, 1);
                }
            }

            const decimal averageNumberOfWins = (decimal)draws / (decimal)participantCount * 1.0M;

            Assert.Equal(participantCount, winners.Count); //Statistically this could fail but very very unlikely
            foreach (var winner in winners)
            {
                Assert.InRange(winner.Value, averageNumberOfWins - 100, averageNumberOfWins + 100); //+/- 100 wins Statistically this could fail but quite unlikely
            }
        }
    }
}