using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionBackend;

public class FunctionGetEvents
{
    private readonly ILogger _logger;

    public FunctionGetEvents(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FunctionGetEvents>();
    }

    [Function("FunctionGetEvents")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        var json = JsonSerializer.Serialize(await new MeetupEventService().GetLast10Events());
        await response.WriteStringAsync(json);

        return response;
    }
}