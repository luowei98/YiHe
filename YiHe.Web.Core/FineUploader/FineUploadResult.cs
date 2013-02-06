using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;


namespace YiHe.Web.Core.FineUploader
{
    /// <remarks>
    /// Docs at https://github.com/valums/file-uploader/blob/master/server/readme.md
    /// </remarks>
    public class FineUploaderResult : ActionResult
    {
        public const string RESPONSE_CONTENT_TYPE = "text/plain";

        private readonly bool success;
        private readonly string error;
        private readonly bool? preventRetry;
        private readonly JObject otherData;

        public FineUploaderResult(bool success, object otherData = null, string error = null, bool? preventRetry = null)
        {
            this.success = success;
            this.error = error;
            this.preventRetry = preventRetry;

            if (otherData != null)
                this.otherData = JObject.FromObject(otherData);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = RESPONSE_CONTENT_TYPE;

            response.Write(BuildResponse());
        }

        public string BuildResponse()
        {
            JObject response = otherData ?? new JObject();
            response["success"] = success;

            if (!string.IsNullOrWhiteSpace(error))
                response["error"] = error;

            if (preventRetry.HasValue)
                response["preventRetry"] = preventRetry.Value;

            return response.ToString();
        }
    }
}