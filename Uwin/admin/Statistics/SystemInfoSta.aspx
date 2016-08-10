<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemInfoSta.aspx.cs" Inherits="Uwin.admin.Statistics.SystemInfoSta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto" >

        <div class="control-group">
            <label class="laber_from">网站名称</label>
            <div class="controls"><asp:TextBox ID="WebName" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">站内标题</label>
            <div class="controls"><asp:TextBox ID="WebTitle" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">Logo</label>
            <div class="controls"><asp:Image ID="Logo" runat="server" /><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">网站地址</label>
            <div class="controls"><asp:TextBox ID="WebHttp" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
         <div class="control-group">
            <label class="laber_from">网站关键字</label>
            <div class="controls"><asp:TextBox ID="MetaKeywords" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
         <div class="control-group">
            <label class="laber_from">网站描述</label>
            <div class="controls"><asp:TextBox ID="MetaDescription" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
         <div class="control-group">
            <label class="laber_from">版权信息</label>
            <div class="controls"><asp:TextBox ID="CopyRight" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">备案号</label>
            <div class="controls"><asp:TextBox ID="Beian" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
       <div class="control-group">
            <label class="laber_from">公司地址</label>
            <div class="controls"><asp:TextBox ID="ComAddress" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
    
</div>
    </form>
</body>
</html>