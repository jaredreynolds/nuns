using System.Net;

public static async Task<HttpResponseMessage> Run(
    HttpRequestMessage req,
    dynamic playerDoc,
    out object newPlayerDoc,
    TraceWriter log)
{
    log.Info($"{req.Method}");

    switch (req.Method.ToString().ToUpper())
    {
        case "POST":
            if (playerDoc != null)
            {
                log.Info($"Player already exists: {playerDoc.id}");
                return req.CreateResponse(HttpStatusCode.Conflict, "Player already exists");
            }

            dynamic reqData = await req.Content.ReadAsAsync<object>();

            newPlayerDoc = new
            {
                displayName = reqData.displayName,
                id = Guid.NewGuid()
            };

            return req.CreateResponse(HttpStatusCode.OK, newPlayerDoc);
        default:
            return req.CreateResponse(HttpStatusCode.BadRequest, "Unsupported method");
    }
}
