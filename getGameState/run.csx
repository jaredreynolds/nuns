using System.Net;

public static HttpResponseMessage Run(
    HttpRequestMessage req,
    dynamic gameDoc,
    TraceWriter log)
{
    var gameIdFound = gameDoc != null;
    var gameState = new GameState { WaitingForThieves = true, GameIdFound = gameIdFound };

    return req.CreateResponse(HttpStatusCode.OK, gameState);
}

public class GameState
{
    public bool WaitingForThieves { get; set; }
    public bool GameIdFound { get; set; }
}