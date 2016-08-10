<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditActivity.aspx.cs" Inherits="Uwin.admin.Resorces.EditActivity" %>

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
            var editor = K.create('#ActivityContent', {
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
    <script src="../../js/jquery-2.1.4.min.js"></script>
    <script src="../../js/jqueryui/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="../../js/jqueryui/jquery-ui.css"/>
    <script type="text/javascript">

        $(function () {

            $("#<%= ActivityStime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });

        });

    </script>
    
    <script type="text/javascript">

        $(function () {

            $("#<%= AcrtivityEtime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });

        });

    </script>
     
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">活动名称</label>
            <div class="controls"><asp:TextBox ID="ActivityName" placeholder=" 请输入活动名称" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>

         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
         <div class="control-group">
       
       
            <label class="laber_from">活动类型</label>
            <div class="controls">
                
                <asp:DropDownList ID="ActivityAffliType" runat="server" AutoPostBack="true" class="input_from" >

                    <asp:ListItem Text="推介" Value="2"></asp:ListItem>
                    <asp:ListItem Text="报名" Value="3"></asp:ListItem>
                    <asp:ListItem Text="调查" Value="4"></asp:ListItem>
                </asp:DropDownList><p class="help-block"></p></div>
        
        
        </div>

                    <div class="control-group">
       
       
            <label class="laber_from">所属分站</label>
            <div class="controls">
                
                <asp:DropDownList ID="ActivityAffiStation" runat="server" AutoPostBack="true" class="input_from" >

                </asp:DropDownList><p class="help-block"></p></div>
        
        
        </div>
                    </ContentTemplate></asp:UpdatePanel>
        <div class="control-group">
            <label class="laber_from">浏览数</label>
            <div class="controls"><asp:TextBox ID="ActivityClick" placeholder=" 请输入浏览数" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">点赞数</label>
            <div class="controls"><asp:TextBox ID="ActivityZan" placeholder=" 请输入点赞数" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">分享数</label>
            <div class="controls"><asp:TextBox ID="ActivityShare" placeholder=" 请输入分享数" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">开始时间</label>
            <div class="controls"><asp:TextBox ID="ActivityStime" placeholder=" 请输入开始时间" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">结束时间</label>
            <div class="controls"><asp:TextBox ID="AcrtivityEtime" placeholder=" 请输入结束时间" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
       
       
            <label class="laber_from">当前状态</label>
            <div class="controls">
                
                <asp:DropDownList ID="ActivityState" runat="server" AutoPostBack="true" class="input_from" >

                    <asp:ListItem Text="进行中" Value="1"></asp:ListItem>
                    <asp:ListItem Text="已结束" Value="2"></asp:ListItem>
                </asp:DropDownList><p class="help-block"></p></div>
        
        
        </div>
        <div class="control-group">
            <label class="laber_from">活动展示图</label>
            <div class="controls"><asp:FileUpload ID="ActivityThumb" runat="server"  CssClass="input w250"/><p class="help-block"></p></div>
        </div>
        
        <div class="control-group">
            
            <div class="controls">

                <asp:TextBox id="ActivityContent" name="ActivityContent" TextMode="MultiLine" runat="server"></asp:TextBox>
               <%-- <asp:TextBox ID="Content" TextMode="MultiLine" Height="200px" class="input_from" runat="server"></asp:TextBox>--%>
                <p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="EditBtn" runat="server" class="btn btn-success" Text="更新" style="width:120px;" OnClick="EditBtn_Click" /></div>
        </div>
    
</div>
    </form>
</body>
</html>

