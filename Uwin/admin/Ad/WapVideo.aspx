<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WapVideo.aspx.cs" Inherits="Uwin.admin.Ad.WapVideo" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="../css/table.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" href="../css/add.css" type="text/css" media="screen"  />
<link rel="stylesheet" href="../css/bootstrap.css" type="text/css" media="screen" />
    <script language="javascript" type="text/javascript">
        function showdiv() {
            document.getElementById("bg").style.display = "block";
            document.getElementById("show").style.display = "block";
        }
        function hidediv() {
            document.getElementById("bg").style.display = 'none';
            document.getElementById("show").style.display = 'none';
        }
</script>
<style type="text/css">
        #bg{ display: none;  position: absolute;  top: 0%;  left: 0%;  width: 100%;  height: 100%;   z-index:1001;  -moz-opacity: 0.7;  opacity:.70;   filter: alpha(opacity=70);}
        #show{display: none;  position: absolute;  top: 25%;  left:40%;  width: 350px;  height: 350px;  padding: 8px;   background-color: white;  z-index:1002; text-align:center;  overflow: auto; color:red; font-size:14px; }
</style>
</head>
<body>
   <form id="form1" runat="server"  enctype="multipart/form-data">
      
<div id="bg"></div>
<div id="show">
    <img src="../../images/upload.gif" /><br />
    视频更换中，请不要关闭页面
</div>
        <div class="div_from_aoto">
           
           
        <div class="control-group">
            <label class="laber_from">选择视频文件</label>
            <div class="controls"><asp:FileUpload ID="Ada" runat="server"  CssClass="input w250"/><p class="help-block">&nbsp;&nbsp;请将要上传的视频放置于D盘根目录下</p></div>
        </div>
       <div class="control-group">
            <label class="laber_from">Ftp地址</label>
            <div class="controls"><asp:TextBox ID="FtpAddress" runat="server" CssClass="input w250"></asp:TextBox><p class="help-block"></p></div>
        </div>
       <div class="control-group">
            <label class="laber_from">Ftp端口</label>
            <div class="controls"><asp:TextBox ID="FtpPort" Text="21" runat="server" CssClass="input w250"></asp:TextBox><p class="help-block"></p></div>
        </div>
       <div class="control-group">
            <label class="laber_from">Ftp用户名</label>
            <div class="controls"><asp:TextBox ID="FtpUserName" runat="server" CssClass="input w250"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">Ftp密码</label>
            <div class="controls"><asp:TextBox TextMode="Password" ID="FtpPassWord" runat="server" CssClass="input w250"></asp:TextBox><p class="help-block"></p></div>
        </div>
        <div class="control-group">
            <label class="laber_from">上传到目录</label>
            <div class="controls"><asp:TextBox ID="FtpDir" Text="web\" runat="server" CssClass="input w250"></asp:TextBox><p class="help-block"></p></div>
        </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
       <div class="control-group">
            <label class="laber_from">要替换的分站</label>
            <div class="controls"><asp:DropDownList ID="Station" runat="server" AutoPostBack="true" class="input_from" ></asp:DropDownList><p class="help-block"></p></div>
        </div>

                    <div class="control-group">
            <label class="laber_from">频道位置</label>
            <div class="controls"><asp:DropDownList ID="VedioChannelID" runat="server" AutoPostBack="true" class="input_from" >
                <asp:ListItem Value="1" Text="左侧"></asp:ListItem>
                <asp:ListItem Value="2" Text="右侧"></asp:ListItem>
                                  </asp:DropDownList><p class="help-block"></p></div>
        </div>
         </ContentTemplate></asp:UpdatePanel>
            <div class="control-group">
            <label class="laber_from">设置该频道名称</label>
            <div class="controls"><asp:TextBox ID="VedioChannelName" runat="server" CssClass="input w250"></asp:TextBox><p class="help-block">&nbsp;&nbsp;（中文汉字不超过6个）</p></div>
        </div>
            <div class="control-group">
            <label class="laber_from">该频道下面的商品列表</label>
            <div class="controls"><asp:TextBox ID="videoIemsArray" runat="server" CssClass="input w250"></asp:TextBox><p class="help-block">&nbsp;&nbsp;（在商品管理中寻找对应的商品id，以英文半角逗号隔开，如：1,8,9）</p></div>
        </div>
       <div class="control-group">
            <label class="laber_from"></label>
            <div class="controls">
                <asp:Button ID="EditBtn" runat="server" class="btn btn-success" Text="更换" style="width:120px;" OnClick="EditBtn_Click" OnClientClick="showdiv();" /></div>
        </div>
            </div>
          
    </form>
    
</body>
</html>
