using System.Net;

public static HttpResponseMessage Run(
    HttpRequestMessage req,
    dynamic playerDoc,
    TraceWriter log)
{
    string displayName = "";

    switch (req.Method)
    {
        case "POST":
            if (playerDoc != null)
            {
                log.Info(req, "player", "Player already exists: {0}", new[] { playerDoc.id });
                return req.CreateResponse(HttpStatusCode.Conflict, "Player already exists");
            }
            displayName = playerDoc.displayName;
            break;
    }

    var player = new Player { DisplayName = displayName };
    return req.CreateResponse(HttpStatusCode.OK, player);
}

public class Player
{
    public string DisplayName { get; set; }
}
