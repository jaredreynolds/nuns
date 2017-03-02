#r "Newtonsoft.Json"

using System.Net;
using Newtonsoft.Json;

public static HttpResponseMessage Run(
    HttpRequestMessage req,
    dynamic gameDoc,
    TraceWriter log)
{
    var gameIdFound = gameDoc != null;

    var gameStateSerialized = JsonConvert.SerializeObject(
        new GameState { WaitingForThieves = true, GameIdFound = gameIdFound },
        Formatting.Indented);
    return req.CreateResponse(HttpStatusCode.OK, gameStateSerialized);
}

public class GameState
{
    public bool WaitingForThieves { get; set; }
    public bool GameIdFound { get; set; }
}