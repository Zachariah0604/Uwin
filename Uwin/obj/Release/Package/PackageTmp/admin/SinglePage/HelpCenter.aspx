<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelpCenter.aspx.cs" Inherits="Uwin.admin.SinglePage.HelpCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen" />
    <link href="../../kindeditor/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="../../kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="../../kindeditor/kindeditor-all.js" type="text/javascript"></script>
    <script src="../../kindeditor/plugins/code/prettify.js" type="text/javascript"></script>  
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor = K.create('#Content', {
                //上传管理
                uploadJson: '../../kindeditor/asp.net/upload_json.ashx',
                //文件管理
                fileManagerJson: '../../kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                //设置编辑器创建后执行的回调函数
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                },
                //上传文件后执行的回调函数,获取上传图片的路径
                afterUpload: function (url) {
                    alert(url);
                },
                //编辑器高度
                width: '700px',
                //编辑器宽度
                height: '450px;',
                //配置编辑器的工具栏
                items: [
                'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
                'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
                'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
                'anchor', 'link', 'unlink', '|', 'about'
                ]
            });
            prettyPrint();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="div_from_aoto">
         <div class="control-group">
            
            <div class="controls">

                <asp:TextBox id="Content" name="Content" TextMode="MultiLine" runat="server"></asp:TextBox>
               <%-- <asp:TextBox ID="Content" TextMode="MultiLine" Height="200px" class="input_from" runat="server"></asp:TextBox>--%>
                <p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="内容不能为空" ControlToValidate="Content"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="AddBtn" runat="server" class="btn btn-success" Text="提交" style="width:120px;" OnClick="AddBtn_Click" /></div>
        </div>
     </div>
    </form>
</body>
</html>
