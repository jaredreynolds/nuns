using System.Net;

public static HttpResponseMessage Run(
    HttpRequestMessage req,
    dynamic gameDoc,
    TraceWriter log)
{
    var gameStatus = (GameStatus)Enum.Parse(typeof(GameStatus), gameDoc.status, true);

    var turn = gameStatus >= GameStatus.Started
        ? (uint)gameDoc.turn
        : 0;

    var Game = new Game
    {
        Status = gameStatus.ToString(),
        Turn = turn
    };

    return req.CreateResponse(HttpStatusCode.OK, Game);
}

public class Game
{
    public string Status { get; set; }
    public uint Turn { get; set; }
}

public enum GameStatus
{
    Unknown,
    Created,
    PlayersJoining,
    PlayersInvited,
    Started,
    ThievesTurn,
    ThievesExtraTurn,
    GuardsTurn,
    Finished
}
