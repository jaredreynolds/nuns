using System.Net;

public static HttpResponseMessage Run(
    HttpRequestMessage req,
    dynamic gameDoc,
    TraceWriter log)
{
    var gameState = new GameState
    {
        Status = (GameStatus)Enum.Parse(typeof(GameStatus), gameDoc.Status)
    };

    return req.CreateResponse(HttpStatusCode.OK, gameState);
}

public class GameState
{
    public GameStatus Status { get; set; }
    public uint Turn { get; set; }
}

public enum GameStatus
{
    Unknown,
    Created,
    PlayersJoining,
    PlayersInvited,
    ThievesTurn,
    ThievesExtraTurn,
    GuardsTurn,
    Finished
}
