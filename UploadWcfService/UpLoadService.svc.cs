using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Configuration;
using System.Drawing;

namespace UploadWcfService
{
    // 注意: 如果更改此处的类名 "UpLoadService"，也必须更新 Web.config 中对 "UpLoadService" 的引用。
    public class UpLoadService : IUpLoadService
    {
        public UploadResult UploadFile(FileUploadMessage request)
        {
            UploadResult result = new UploadResult();            
            Stream sourceStream = request.FileData;
            FileStream targetStream = null;     
            //判断数据流是否有
            if (!sourceStream.CanRead)
            {                
                result.Result = false;
                return result;
            }            
            string directory;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SavePath"]))
                directory = ConfigurationManager.AppSettings["SavePath"]+@"\";
            else
                directory = AppDomain.CurrentDomain.BaseDirectory;
            string dateString = DateTime.Now.Year.ToString() + @"\";
            string extension = Path.GetExtension(request.FileName);
            Guid guid = Guid.NewGuid();            
            string fileName = guid.ToString() + extension;
            directory = directory + dateString;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string filePath = Path.Combine(directory, fileName);
            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //read from the input stream in 4K chunks
                //and save to output stream
                const int bufferLen = 4096;
                byte[] buffer = new byte[bufferLen];
                int count = 0;
                while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();
                result.Result = true;
            }
            try
            {
                Image img = Image.FromFile(filePath);//检测是否为图片
                if (img.Height < 1 || img.Width < 1)
                {
                    File.Delete(filePath);
                    result.Result = false;
                    return result;
                }
            }
            catch (Exception)
            {
                File.Delete(filePath);
                result.Result = false;
            }           
            return result;
        }
    }
}
