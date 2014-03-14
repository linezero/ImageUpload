using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace UploadWcfService
{
    // 注意: 如果更改此处的接口名称 "IUpLoadService"，也必须更新 Web.config 中对 "IUpLoadService" 的引用。
    [ServiceContract]
    public interface IUpLoadService
    {
        [OperationContract(Action = "UploadFile")]
        UploadResult UploadFile(FileUploadMessage request);
    }


    [MessageContract]
    public class FileUploadMessage
    {
        /// <summary>
        /// 传过来的文件名
        /// </summary>
        [MessageHeader]
        public string FileName;

        /// <summary>
        /// 传过来的文件
        /// </summary>
        [MessageBodyMember]
        public Stream FileData;

        /// <summary>
        /// 用户id
        /// </summary>
        [MessageHeader]
        public int UserId;
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    [MessageContract]
    public class UploadResult
    {
        [MessageBodyMember]
        public bool Result;

        [MessageBodyMember]
        public int Id;
    }
}
