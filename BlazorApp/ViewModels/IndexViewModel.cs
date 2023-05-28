﻿using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.ViewModels;

public class IndexViewModel
{
    private readonly ParticipationFileHandler _fileHandler;
    private readonly ParticipationWinnerSelector _participationWinnerSelector;
    internal bool ShouldDrawWinnerBeDisabled => Participants == null;
    internal bool IncludeHostsInDraw { get; set; }
    internal IReadOnlyList<Participant>? Participants { get; private set; }
    public int NumerOfWinnerToSelect { get; set; } = 1;

    public IndexViewModel(ParticipationFileHandler fileHandler, ParticipationWinnerSelector participationWinnerSelector)
    {
        _fileHandler = fileHandler;
        _participationWinnerSelector = participationWinnerSelector;
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
}