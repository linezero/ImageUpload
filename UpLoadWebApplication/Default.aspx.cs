using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;


namespace UpLoadWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UpLoadService.UpLoadServiceClient ser = new UpLoadWebApplication.UpLoadService.UpLoadServiceClient();
            UpLoadService.FileUploadMessage request = new UpLoadService.FileUploadMessage();
            request.FileName = FileUpload1.FileName;
            request.FileData = FileUpload1.FileContent;
            UpLoadService.IUpLoadService channel = ser.ChannelFactory.CreateChannel();
            UpLoadService.UploadResult result = channel.UploadFile(request);
            Response.Write(result.Result.ToString());
        }
    }
}
