using System.Net;

public static HttpResponseMessage Run(
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
                newPlayerDoc = null;
                return req.CreateResponse(HttpStatusCode.Conflict, "Player already exists");
            }

            var contentTask = req.Content.ReadAsAsync<object>();
            contentTask.Wait();
            dynamic reqData = contentTask.Result;

            newPlayerDoc = new
            {
                displayName = reqData.displayName,
                id = Guid.NewGuid()
            };

            return req.CreateResponse(HttpStatusCode.OK, newPlayerDoc);
        default:
            newPlayerDoc = null;
            return req.CreateResponse(HttpStatusCode.BadRequest, "Unsupported method");
    }
}
