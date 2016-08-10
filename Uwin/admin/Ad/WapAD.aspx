<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WapAD.aspx.cs" Inherits="Uwin.admin.Ad.WapAD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>手机首页广告位</title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen"  />
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
   <div class="div_from_aoto">
          <div class="control-group">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
       
            <label class="laber_from">选择分站</label>
            <div class="controls">
                
                <asp:DropDownList ID="Station" runat="server" AutoPostBack="true" class="input_from" OnSelectedIndexChanged="Station_SelectedIndexChanged" ></asp:DropDownList><p class="help-block"></p></div>
        
        
        </ContentTemplate></asp:UpdatePanel></div>

       <div class="control-group">
            <label class="laber_from">广告图</label>
            <div class="controls"><asp:FileUpload ID="WapBannera" runat="server"  CssClass="input w250"/><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">连接地址</label>
            <div class="controls"><asp:TextBox ID="WapBanneraLink" placeholder=" 请输入链接Url" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
       <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="EditBtn" runat="server" class="btn btn-success" Text="更换" style="width:120px;" OnClick="EditBtn_Click" /></div>
        </div>
    </div>
    </form>
</body>
</html>
