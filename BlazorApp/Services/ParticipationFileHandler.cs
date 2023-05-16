using BlazorApp.Model;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Services;

public class ParticipationFileHandler
{
    public async Task<List<Participant>> ParseFile(IBrowserFile file)
    {
        var result = new List<Participant>();
        using var streamReader = new StreamReader(file.OpenReadStream());
        var fileContent = await streamReader.ReadToEndAsync();

        var lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines.Skip(1))
        {
            var lineParts = line.Split(new[] { "\t" }, StringSplitOptions.TrimEntries);
            string name = lineParts[0];
            bool eventHost = lineParts[3] == "Yes";
            string url = lineParts[8];

            result.Add(new Participant(name, eventHost, url));
        }

        return result;

    }
}