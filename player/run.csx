using System.Net;

public static HttpResponseMessage Run(
    HttpRequestMessage req,
    dynamic playerDoc,
    TraceWriter log)
{
    var player = new Player { DisplayName = playerDoc.displayName };
    return req.CreateResponse(HttpStatusCode.OK, player);
}

public class Player
{
    public string DisplayName { get; set; }
}
