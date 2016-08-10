<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSend.aspx.cs" Inherits="Uwin.admin.Orders.OrderSend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen">
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen">

    <script src="../../js/jquery-2.1.4.min.js"></script>
    <script src="../../js/jqueryui/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="../../js/jqueryui/jquery-ui.css"/>
    <script type="text/javascript">

        $(function () {

            $("#<%= expDeliveryTime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });

        });

    </script>
    
    <script type="text/javascript">

        $(function () {

            $("#<%= expReceTime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });

        });

    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto">

        <div class="control-group">
            <label class="laber_from">订单序号</label>
            <div class="controls"><asp:TextBox ID="AffliOrderID" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">快递公司</label>
            <div class="controls"><asp:TextBox ID="expCompany" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">货运单号</label>
            <div class="controls"><asp:TextBox ID="expressNum" placeholder="请输入从快递公司返回的有效单号" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">发货时间</label>
            <div class="controls"><asp:TextBox ID="expDeliveryTime" class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">收货时间</label>
            <div class="controls"><asp:TextBox ID="expReceTime" placeholder=" " class="input_from" runat="server"></asp:TextBox><p class="help-block">只用于查看用户确认收货时间，无需更改</p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">送货地址</label>
            <div class="controls"><asp:TextBox ID="expAdress"  class="input_from" runat="server"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="SendBtn" runat="server" class="btn btn-success" Text="立即发货" style="width:120px;" OnClick="SendBtn_Click" /></div>
        </div>
    
</div>
    </form>
</body>
</html>
