﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditStation.aspx.cs" Inherits="Uwin.admin.StationManage.EditStation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改分站</title>
 <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto" >

        <div class="control-group">
            <label class="laber_from">分站名称</label>
            <div class="controls"><asp:TextBox ID="stationName" placeholder=" 请输入分站名称" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <div class="control-group">
            <label class="laber_from">管理员身份</label>
            <div class="controls">
                
                <asp:DropDownList ID="AdminRole" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AdminRole_SelectedIndexChanged"></asp:DropDownList><p class="help-block"></p></div>
        </div>
        
        </ContentTemplate></asp:UpdatePanel>
        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="EditBtn" runat="server" class="btn btn-success" Text="修改" style="width:120px;" OnClick="EditBtn_Click" /></div>
        </div>
    
</div>
    </form>
</body>
</html>

