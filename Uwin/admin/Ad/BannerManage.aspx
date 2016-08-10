<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BannerManage.aspx.cs" Inherits="Uwin.admin.Ad.BannerManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto" >
        <asp:Label ID="Label1" runat="server" Text="图片尺寸：1920x480，为网站速度考虑，上传的图片请尽量压缩至100KB以下"></asp:Label>
        <div class="control-group">
            <label class="laber_from">第一轮换图</label>
            <div class="controls"><asp:FileUpload ID="FileUpload1" CssClass="files" runat="server" />
          <asp:Button ID="BtnUpLoad1" runat="server" Text="上传" CssClass="submit" 
              onclick="BtnUpLoad1_Click" /><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">第二轮换图</label>
            <div class="controls">
                <asp:FileUpload ID="FileUpload2" CssClass="files" runat="server" />
          <asp:Button ID="BtnUpLoad2" runat="server" Text="上传" CssClass="submit" 
              onclick="BtnUpLoad2_Click" />
                <p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">第三轮换图</label>
            <div class="controls">
                <asp:FileUpload ID="FileUpload3" CssClass="files" runat="server" />
          <asp:Button ID="BtnUpLoad3" runat="server" Text="上传" CssClass="submit" 
              onclick="BtnUpLoad3_Click" />
                <p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">第四轮换图</label>
            <div class="controls">
                <asp:FileUpload ID="FileUpload4" CssClass="files" runat="server" />
          <asp:Button ID="BtnUpLoad4" runat="server" Text="上传" CssClass="submit" 
              onclick="BtnUpLoad4_Click" />
                <p class="help-block"></p></div>
        </div>
        
        
    
</div>
    </form>
</body>
</html>
