using System.IO;
using System.Web.Mvc;

namespace YiHe.Web.Core.FineUploader
{
    [ModelBinder(typeof(ModelBinder))]
    public class FineUpload
    {
        public string Filename { get; set; }
        public Stream InputStream { get; set; }

        public void SaveAs(string destination, bool overwrite = false, bool autoCreateDirectory = true)
        {
            if (autoCreateDirectory)
            {
                var directory = new FileInfo(destination).Directory;
                if (directory != null) directory.Create();
            }

            using (var file = new FileStream(destination, overwrite ? FileMode.Create : FileMode.CreateNew))
                InputStream.CopyTo(file);
        }

        public class ModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var request = controllerContext.RequestContext.HttpContext.Request;
                var formUpload = request.Files.Count > 0;

                // find filename
                var xFileName = request.Headers["X-File-Name"];
                var qqFile = request["qqfile"];
                var fileBase = request.Files[0];
                if (fileBase != null)
                {
                    var formFilename = formUpload ? fileBase.FileName : null;

                    var upload = new FineUpload
                                 {
                                     Filename = xFileName ?? qqFile ?? formFilename,
                                     InputStream = formUpload ? fileBase.InputStream : request.InputStream
                                 };

                    return upload;
                }
                return null;
            }
        }

    }
}
