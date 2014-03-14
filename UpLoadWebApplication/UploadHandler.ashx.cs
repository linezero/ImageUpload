using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace UpLoadWebApplication
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                UpLoadService.UpLoadServiceClient ser = new UpLoadWebApplication.UpLoadService.UpLoadServiceClient();
                UpLoadService.FileUploadMessage request = new UpLoadService.FileUploadMessage();
                Stream stream = context.Request.Files[0].InputStream;
                request.FileData = stream;
                request.FileName = context.Request.Files[0].FileName;
                UpLoadService.IUpLoadService channel = ser.ChannelFactory.CreateChannel();
                UpLoadService.UploadResult result = channel.UploadFile(request);
                if (result.Result)
                {
                    context.Response.Write("ok");
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}