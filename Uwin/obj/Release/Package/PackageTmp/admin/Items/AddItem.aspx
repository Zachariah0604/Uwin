<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="Uwin.admin.Items.AddItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加商品</title>
<link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen" />
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen" />
    <link href="../../kindeditor/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="../../kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="../../kindeditor/kindeditor-all.js" type="text/javascript"></script>
    <script src="../../kindeditor/plugins/code/prettify.js" type="text/javascript"></script>  
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor = K.create('#itemContent', {
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

            $("#<%= itemTriStime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });

        });

    </script>
    
    <script type="text/javascript">

        $(function () {

            $("#<%= itemTriEtime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });

        });

    </script>
     <script type="text/javascript">

        $(function () {

            $("#<%= itemSecTime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });

        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_from_aoto" >

        <div class="control-group">
            <label class="laber_from">商品名称</label>
            <div class="controls"><asp:TextBox ID="itemName" placeholder=" 请输入商品名称" class="input_from" runat="server"></asp:TextBox><p class="help-block">
                <asp:RequiredFieldValidator ID="itemNameValidator" runat="server" 
            ErrorMessage="商品名称不能为空！" ControlToValidate="itemName"></asp:RequiredFieldValidator>
</p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">商品描述</label>
            <div class="controls"><asp:TextBox ID="itemDescri" placeholder=" 请输入商品描述" class="input_from" runat="server"></asp:TextBox><p class="help-block">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="商品描述不能为空！" ControlToValidate="itemDescri"></asp:RequiredFieldValidator>
</p></div>
        </div>
       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        
                    <div class="control-group">
            <label class="laber_from">所属分站</label>
            <div class="controls">
                
                <asp:DropDownList ID="AffliStation" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="AffliStation_SelectedIndexChanged"  ></asp:DropDownList><p class="help-block"></p></div>
        </div>
                    <div class="control-group">
            <label class="laber_from">所属商户</label>
            <div class="controls">
                
                <asp:DropDownList ID="AffliMerchant" runat="server" AutoPostBack="true" ></asp:DropDownList><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
            ErrorMessage="所属商户不能为空！" ControlToValidate="AffliMerchant"></asp:RequiredFieldValidator></p></div>
        </div>
                    <div class="control-group">
            <label class="laber_from">所属品牌</label>
            <div class="controls">
                
                <asp:DropDownList ID="AffliBrand" runat="server" AutoPostBack="true" ></asp:DropDownList><p class="help-block"></p></div>
        </div>
                    <div class="control-group">
            <label class="laber_from">所属分类</label>
            <div class="controls">
                
                <asp:DropDownList ID="AffliParType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AffliParType_SelectedIndexChanged" ></asp:DropDownList>
                <asp:DropDownList ID="AffliSubType" runat="server" AutoPostBack="true" ></asp:DropDownList><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
            ErrorMessage="没有选择分类！" ControlToValidate="AffliSubType"></asp:RequiredFieldValidator></p></div>
        </div>
        
        </ContentTemplate></asp:UpdatePanel>
        <div class="control-group">
            <label class="laber_from">市场价格</label>
            <div class="controls"><asp:TextBox ID="itemMarketPrice" placeholder=" 请输入市场价格" class="input_from" runat="server"></asp:TextBox><p class="help-block"> <asp:RequiredFieldValidator ID="itemMarketPriceValidator1" runat="server" 
            ErrorMessage="市场价格不能为空！" ControlToValidate="itemMarketPrice"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">成本价格</label>
            <div class="controls"><asp:TextBox ID="itemCost" placeholder=" 请输入成本价格" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemCostValidator1" runat="server" 
            ErrorMessage="成本价不能为空！" ControlToValidate="itemCost"></asp:RequiredFieldValidator></p></div>
        </div>
        
        <div class="control-group">
            <label class="laber_from">销售价格</label>
            <div class="controls"><asp:TextBox ID="itemSalePrice" placeholder=" 请输入销售价格" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="销售价格不能为空！" ControlToValidate="itemSalePrice"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">库存量</label>
            <div class="controls"><asp:TextBox ID="itemStcok" placeholder=" 请输入库存量" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="库存量不能为空！" ControlToValidate="itemStcok"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">已销售数量</label>
            <div class="controls"><asp:TextBox ID="itemSaleNum" placeholder=" 手动设置已销售数量" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="已销售数量不能为空！" ControlToValidate="itemSaleNum"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">商品销售状态</label>
            <div class="controls">
                <asp:DropDownList ID="itemState" runat="server" AutoPostBack="true" >
                    <asp:ListItem Value="1" Text="已上架"></asp:ListItem>
                    <asp:ListItem Value="0" Text="已下架"></asp:ListItem>
                 </asp:DropDownList>
                <p class="help-block"></p></div>
        </div>

       <div class="control-group" style="color:red; border-bottom:red solid 1px">以上为必填项目</div>
       <div class="control-group" style="height:30px;"></div>
         <div class="control-group">
            <label class="laber_from">是否加入试用</label>
            <div class="controls">
                <asp:DropDownList ID="IsTrial" runat="server" AutoPostBack="true" OnSelectedIndexChanged="IsTrial_SelectedIndexChanged" >
                    <asp:ListItem Value="false" Selected = "True" Text="不加入"></asp:ListItem>
                    <asp:ListItem Value="true" Text="加入"></asp:ListItem>
                </asp:DropDownList>
                <p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">试用押金</label>
            <div class="controls"><asp:TextBox Enabled="false" ID="itemTriPrice" placeholder=" 请输入试用押金" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemTriPriceValidator" runat="server" 
            ErrorMessage="试用押金不能为空！" Enabled="false" ControlToValidate="itemTriPrice"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">线上库存</label>
            <div class="controls"><asp:TextBox Enabled="false" ID="itemTriOnlStock" placeholder=" 请输入线上库存" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemTriOnlStockValidator" runat="server" 
            ErrorMessage="线上库存不能为空！" Enabled="false" ControlToValidate="itemTriOnlStock"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">电视库存</label>
            <div class="controls"><asp:TextBox Enabled="false" ID="itemTriVideoStock" placeholder=" 请输入电视库存" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemTriVideoStockValidator" runat="server" 
            ErrorMessage="电视库存不能为空！" Enabled="false" ControlToValidate="itemTriVideoStock"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">申请数量</label>
            <div class="controls"><asp:TextBox Enabled="false" ID="itemTriApply" placeholder=" 手动设置已申请数量" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemTriApplyValidator" runat="server" 
            ErrorMessage="申请数量不能为空！" Enabled="false" ControlToValidate="itemTriApply"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">发放数量</label>
            <div class="controls"><asp:TextBox Enabled="false" ID="itemTriAgree" placeholder=" 手动设置已发放数量" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemTriAgreeValidator" runat="server" 
            ErrorMessage="发放数量不能为空！" Enabled="false" ControlToValidate="itemTriAgree"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">试用开始时间</label>
            <div class="controls"><asp:TextBox Enabled="false" ID="itemTriStime" placeholder=" 试用开始时间" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemTriStimeValidator" runat="server" 
            ErrorMessage="试用开始时间不能为空！" Enabled="false" ControlToValidate="itemTriStime"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">试用结束时间</label>
            <div class="controls"><asp:TextBox Enabled="false" ID="itemTriEtime" placeholder=" 试用结束时间" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemTriEtimeValidator" runat="server" 
            ErrorMessage="试用结束时间不能为空！" Enabled="false" ControlToValidate="itemTriEtime"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">试用状态</label>
            <div class="controls">
                 <asp:DropDownList Enabled="false" ID="itemTriState" runat="server" AutoPostBack="true" >
                    <asp:ListItem Value="1" Text="进行中"></asp:ListItem>
                    <asp:ListItem Value="0" Text="已结束"></asp:ListItem>
                </asp:DropDownList>
               
                <p class="help-block"></p></div>
        </div>

        <div class="control-group" style="color:red; border-bottom:red solid 1px">以上为试用必填项目，不加入试用可不填写</div>
        <div class="control-group" style="height:30px;"></div>
         <div class="control-group">
            <label class="laber_from">是否加入秒杀</label>
            <div class="controls">
                <asp:DropDownList ID="IsSeckill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="IsSeckill_SelectedIndexChanged" >
                    <asp:ListItem Value="false" Selected = "True" Text="不加入"></asp:ListItem>
                    <asp:ListItem Value="true" Text="加入"></asp:ListItem>
                </asp:DropDownList>
                <p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">秒杀价格</label>
            <div class="controls"><asp:TextBox ID="itemSecPrice" Enabled="false" placeholder=" 请输入秒杀价格" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemSecPriceValidator" runat="server" 
            ErrorMessage="秒杀价格不能为空！" Enabled="false" ControlToValidate="itemSecPrice"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">库存数量</label>
            <div class="controls"><asp:TextBox ID="itemSecStock" Enabled="false" placeholder=" 请输入库存数量" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemSecStockValidator" runat="server" 
            ErrorMessage="库存数量不能为空！" Enabled="false" ControlToValidate="itemSecStock"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">总销量</label>
            <div class="controls"><asp:TextBox ID="itemSecSaleNum" Enabled="false" placeholder=" 手动设置秒杀总销量" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemSecSaleNumValidator" runat="server" 
            ErrorMessage="总销量不能为空！" Enabled="false" ControlToValidate="itemSecSaleNum"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">添加时间</label>
            <div class="controls"><asp:TextBox ID="itemSecTime" Enabled="false" placeholder=" 添加时间" CssClass="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="itemSecTimeValidator" runat="server" 
            ErrorMessage="添加时间不能为空！" Enabled="false" ControlToValidate="itemSecTime"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">秒杀状态</label>
            <div class="controls">
                <asp:DropDownList ID="itemSecState" runat="server" Enabled="false" AutoPostBack="true" >
                    <asp:ListItem Value="1" Text="进行中"></asp:ListItem>
                    <asp:ListItem Value="0" Text="已结束"></asp:ListItem>
                </asp:DropDownList>
                <p class="help-block"></p></div>
        </div>
        
        <div class="control-group" style="color:red; border-bottom:red solid 1px">以上为秒杀必填项目，不加入秒杀可不填写</div>
        
         <div class="control-group" style="height:30px;"></div>
         <div class="control-group" style="height:100px;">
            <label class="laber_from"  style="margin-top:40px;">商品缩略图(使用白色背景图片)</label>
            <div class="controls">
                 <asp:FileUpload ID="ItemThumbnail" CssClass="files" runat="server"  style="margin-top:40px;" />
          <asp:Button ID="BtnUpLoad" runat="server" Text="上传" CssClass="submit" 
              onclick="BtnUpLoad_Click"  style="margin-top:40px;" />
                
               <p class="help-block" style="margin-left:50px;">&nbsp;&nbsp;&nbsp;<asp:Image ID="ItemThumbnailShow" runat="server" Width="100px" Height="100px" />

            </div>
        </div>

        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls"><asp:TextBox ID="itemContent" TextMode="MultiLine" class="input_from" runat="server"></asp:TextBox><p class="help-block"><asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
            ErrorMessage="详细内容不能为空！" ControlToValidate="itemContent"></asp:RequiredFieldValidator></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="AddBtn" runat="server" class="btn btn-success" Text="添加商品" style="width:120px;" OnClick="AddBtn_Click" /></div>
        </div>
    <div class="control-group" style="height:30px;"></div>
</div>
    </form>
</body>
</html>
