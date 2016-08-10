<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAddressAdd.aspx.cs" Inherits="Uwin.User.UserAddressAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加收货地址</title>
    <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../css/bootstrap2.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto" style="height:300px;">

        <div class="control-group">
            <label class="laber_from">收货人</label>
            <div class="controls"><asp:TextBox ID="ReceUser" placeholder=" 请输入收货人姓名" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="收货人姓名不能为空" ControlToValidate="ReceUser"></asp:RequiredFieldValidator></p></div>
        </div>
       
        <div class="control-group">
            <label class="laber_from">联系电话</label>
            <div class="controls"><asp:TextBox ID="ReceTele" placeholder=" 请输入手机号码" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入手机号码" ControlToValidate="ReceTele"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入正确的手机号" Display="Dynamic" ControlToValidate="ReceTele" ValidationExpression="^[1][358][0-9]{9}$"></asp:RegularExpressionValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">所在地区</label>
            <div class="controls"><asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddlProvince" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="ddlVilliage" runat="server"></asp:DropDownList>
                
                <ajax:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlProvince" ServicePath="SNWebService.asmx" ServiceMethod="GetProvinceContents" Category="Province" PromptText="请选择省份" LoadingText="省份加载中...">
                </ajax:CascadingDropDown>
                
                <ajax:CascadingDropDown ID="CascadingDropDown1" runat="server" ParentControlID="ddlProvince" ServicePath="SNWebService.asmx" ServiceMethod="GetCityContents" Category="City" TargetControlID="ddlCity" PromptText="请选择城市" LoadingText="城市加载中..."></ajax:CascadingDropDown>
                
                <ajax:CascadingDropDown ID="CascadingDropDown3" runat="server" Category="Villiage" LoadingText="区县加载中..." ParentControlID="ddlCity" PromptText="请选择区县" ServiceMethod="GetViliageContents" ServicePath="SNWebService.asmx" TargetControlID="ddlVilliage"></ajax:CascadingDropDown>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        </div><p class="help-block"> </p></div>
        </div>
       <div class="control-group">
            <label class="laber_from">详细地址</label>
            <div class="controls"><asp:TextBox ID="ReceAddress" TextMode="MultiLine" class="input_from" runat="server" ></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="详细地址不能为空" ControlToValidate="ReceAddress"></asp:RequiredFieldValidator></p></div>
        </div>
     
        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="AddBtn" runat="server" class="btn btn-success" Text="添加" style="width:120px;" OnClick="AddBtn_Click" /></div>
        </div>
    
</div>
    </form>
</body>
</html>
