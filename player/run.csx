using System.Net;

public static HttpResponseMessage Run(
    HttpRequestMessage req,
    dynamic playerDoc,
    TraceWriter log)
{
    var player = new Player { Display = playerDoc.displayName };
    return req.CreateResponse(HttpStatusCode.OK, player);
}

public class Player
{
    public string Display { get; set; }
}
