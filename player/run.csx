using System.Net;

public static HttpResponseMessage Run(
    HttpRequestMessage req,
    dynamic playerDoc,
    TraceWriter log)
{
    return req.CreateResponse(HttpStatusCode.OK, (playerDoc != null).ToString());
}

