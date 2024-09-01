using BlazorApp.Services;
using Microsoft.AspNetCore.Components.Forms;
using SharedModels.Models.EventParticipants;
using SharedModels.Models.GroupEvents;

namespace BlazorApp.ViewModels;

public class IndexViewModel
{
    private readonly ParticipationFileHandler _fileHandler;
    private readonly ParticipationWinnerSelector _participationWinnerSelector;
    private readonly BackendCaller _backendCaller;
    internal bool ShouldDrawWinnerBeDisabled => Participants == null;
    internal bool IncludeHostsInDraw { get; set; }
    internal IReadOnlyList<Participant>? Participants { get; private set; }
    internal IReadOnlyList<Event>? Events { get; private set; }
    public int NumerOfWinnerToSelect { get; set; } = 1;

    public IndexViewModel(ParticipationFileHandler fileHandler, ParticipationWinnerSelector participationWinnerSelector, BackendCaller backendCaller)
    {
        _fileHandler = fileHandler;
        _participationWinnerSelector = participationWinnerSelector;
        _backendCaller = backendCaller;
    }

    internal async Task UploadFiles(IBrowserFile file)
    {
        Participants = await _fileHandler.ParseFile(file);
    }

    internal void ChooseWinner()
    {
        if (Participants == null)
        {
            return;
        }

        _participationWinnerSelector.MarkParticipantsAsWinners(Participants, IncludeHostsInDraw, NumerOfWinnerToSelect);
    }

    internal string RowStyle(Participant participant, int _)
    {
        return participant.Winner ? "background-color:#FCE2A1" : string.Empty;
    }

    public async Task LoadEvents()
    {
        Events = await _backendCaller.GetEvents();
    }

    public async Task LoadParticipants(Event @event)
    {
        Participants = await _backendCaller.GetParticipants(@event);
    }
}