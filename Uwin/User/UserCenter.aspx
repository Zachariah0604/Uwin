<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCenter.aspx.cs" Inherits="Uwin.User.UserCenter" %>

<%Response.WriteFile("../HeaderSecond.html"); Response.ContentEncoding=System.Text.Encoding.Default;%>
<script type="text/javascript">

    window.onload = function () {

        document.title = "会员中心";

    }

</script> 
<style>
    body { background:#F8F8F8;
    }
</style>
    <div id="UserCenter">
     
        
   <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td ></td>
  </tr>
  <tr>
    <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="20%" style=" vertical-align:top;"><iframe name="left" marginwidth=0 marginheight=0 src="CenterMenu.aspx" frameborder=0 scrolling="no" width="100%" height="500px;" ></iframe></td>
        <td width="80%"><iframe id="body" name="body" height="100%" marginwidth=0 marginheight=0 src="CenterIndex.aspx" frameborder=0 scrolling="no" width="100%" onLoad="iFrameHeight()" ></iframe></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td></td>
  </tr>
</table>
        <script type="text/javascript" language="javascript">

            function iFrameHeight() {

                var ifm = document.getElementById("body");

                var subWeb = document.frames ? document.frames["body"].document :

        ifm.contentDocument;

                if (ifm != null && subWeb != null) {

                    ifm.height = subWeb.body.scrollHeight;

                }

            }

</script> 
    </div>

<%Response.WriteFile("../Footer.html");%>
