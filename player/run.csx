using System.Net;

public static async HttpResponseMessage Run(
    HttpRequestMessage req,
    dynamic playerDoc,
    object newPlayerDoc,
    TraceWriter log)
{
    switch (req.Method)
    {
        case "POST":
            if (playerDoc != null)
            {
                log.Info(req, "player", "Player already exists: {0}", new[] { playerDoc.id });
                return req.CreateResponse(HttpStatusCode.Conflict, "Player already exists");
            }

            dynamic reqData = await req.Content.ReadAsAsync<object>();

            newPlayerDoc = new
            {
                displayName = reqData.displayName,
                id = Guid.NewGuid()
            };

            return req.CreateResponse(HttpStatusCode.OK, newPlayerDoc);
            break;
        default:
            return req.CreateResponse(HttpStatusCode.BadRequest, null);
            break;
    }
}
