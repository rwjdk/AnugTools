using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using SharedModels.Models.EventParticipants;
using SharedModels.Models.GroupEvents;

namespace AzureFunctionBackend;

public class MeetupEventService
{
    private readonly GraphQLHttpClient _client;

    public MeetupEventService()
    {
        _client = new GraphQLHttpClient("https://api.meetup.com/gql", new SystemTextJsonSerializer());
    }

    public async Task<IReadOnlyList<Event>> GetLast10Events()
    {
        var request = new GraphQLRequest
        {
            Query = @"
            {
              groupByUrlname(urlname: ""anugdk"") {
                upcomingEvents(input: { first: 1000 }) {
                    edges {
                        node {
                            id,
                            title    
                            status
                            dateTime            
                        }
                    }
                }   
                pastEvents(input: { first: 1000}) {
                    edges {
                        node {
                            id,
                            title    
                            status
                            dateTime            
                        }
                    }
                }    
              }
            }"
        };

        var response = await _client.SendQueryAsync<GroupEventsResponse>(request);
        return response.Data.GetAllEvents().Take(10).ToList();
    }

    public async Task<IReadOnlyList<Event>> GetLast10Events(int eventId)
    {
        var request = new GraphQLRequest
        {
            Query = @"
            {
              groupByUrlname(urlname: ""anugdk"") {
                upcomingEvents(input: { first: 1000 }) {
                    edges {
                        node {
                            id,
                            title    
                            eventUrl
                            dateTime            
                        }
                    }
                }   
                pastEvents(input: { first: 1000}) {
                    edges {
                        node {
                            id,
                            title    
                            eventUrl
                            dateTime            
                        }
                    }
                }    
              }
            }"
        };

        var response = await _client.SendQueryAsync<GroupEventsResponse>(request);
        return response.Data.GetAllEvents().Take(10).ToList();
    }

    public async Task<IReadOnlyList<Participant>> GetParticipantsForEvent(string eventId)
    {
        var request = new GraphQLRequest
        {
            Query = @$"
            {{
              event(id: ""{eventId}"") {{
                tickets(input: {{first: 1000}}) {{
                  edges {{
                    node {{
                      user {{
                        name
                        isLeader
                        memberUrl
                      }}
                    }}
                  }}
                }}
              }}
            }}",
        };

        var response = await _client.SendQueryAsync<EventsParticipantsResponse>(request);
        return response.Data.Root.Tickets.Edges.Select(x => x.Node.User).ToList();
    }
}