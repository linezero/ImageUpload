<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UpLoadWebApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>wcf 图片上传demo</title>
    <script src="uploadify/jquery.js" type="text/javascript"></script>
    <script src="uploadify/jquery.uploadify.min.js" type="text/javascript"></script>
    <link href="uploadify/uploadify.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="upload" />
        <br />
    <input id="file_upload" name="file_upload" type="file" multiple="true"/>
    </div>
    </form>
    <script type="text/javascript">
		$(function() {
			$('#file_upload').uploadify({
			    swf : '/uploadify/uploadify.swf',
			    uploader : 'UploadHandler.ashx',
			    buttonText : '选择图片',
			    fileExt : '*.jpg;*.png;*.gif;*.jpeg',
			    cancelImg: '/uploadify/uploadify-cancel.png',
			    onUploadSuccess : function (file, data, response) {
			        alert(data);  
			    }
			});
		});
    </script>
</body>
</html>
