<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditArticle.aspx.cs" Inherits="Uwin.admin.ArticleManage.EditArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>更新文章</title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">文章标题</label>
            <div class="controls"><asp:TextBox ID="Title" placeholder=" 请输入标题" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="标题不能为空" ControlToValidate="Title"></asp:RequiredFieldValidator></p></div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <div class="control-group">
            <label class="laber_from">选择分类</label>
            <div class="controls">
                
                <asp:DropDownList ID="Type" runat="server" AutoPostBack="true" ></asp:DropDownList><p class="help-block"></p></div>
        </div>
        
        </ContentTemplate></asp:UpdatePanel>
        <div class="control-group">
            <label class="laber_from">作者</label>
            <div class="controls"><asp:TextBox ID="Author" placeholder=" 请输入文章作者" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="作者不能为空" ControlToValidate="Author"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">来源</label>
            <div class="controls"><asp:TextBox ID="Url" placeholder=" 请输入文章来源" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="来源不能为空" ControlToValidate="Url"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">文章关键字</label>
            <div class="controls"><asp:TextBox ID="Keyword" placeholder=" 请输入关键字" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="文章关键字不能为空" ControlToValidate="Keyword"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">缩略图</label>
            <div class="controls"><asp:FileUpload ID="PicUrl" runat="server"  CssClass="input w250"/><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">点击数</label>
            <div class="controls"><asp:TextBox ID="Click" placeholder=" 手动设置文章点击数" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="点击数不能为空" ControlToValidate="Click"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">文章内容</label>
            <div class="controls"><asp:TextBox ID="Content" TextMode="MultiLine" Height="200px" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="内容不能为空" ControlToValidate="Content"></asp:RequiredFieldValidator></p></div>
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
