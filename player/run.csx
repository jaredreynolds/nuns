using System.Net;

public static HttpResponseMessage Run(
    HttpRequestMessage req,
    dynamic playerDoc,
    TraceWriter log)
{
    log.Info(playerDoc);
    return req.CreateResponse(HttpStatusCode.OK, "Hello?");
}

