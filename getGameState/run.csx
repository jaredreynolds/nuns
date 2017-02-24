#r "Newtonsoft.Json"

using Newtonsoft.Json;

public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log)
{
    var gameStateSerialized = JsonConvert.SerializeObject(new GameState { WaitingForThieves = true }, Formatting.Indented);
    req.CreateResponse(HttpStatusCode.OK, gameStateSerialized);
}

public class GameState
{
    public bool WaitingForThieves { get; set; }
}