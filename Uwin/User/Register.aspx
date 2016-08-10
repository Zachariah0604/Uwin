<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Uwin.Register" %>
<%Response.WriteFile("../HeaderSecond.html"); Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");%>
<META HTTP-EQUIV="Pragma" CONTENT="no-cache">  
    <META HTTP-EQUIV="Cache-Control" CONTENT="no-cache">  
    <META HTTP-EQUIV="Expires" CONTENT="0"> 
<script type="text/javascript">

    window.onload = function () {

        document.title = "用户注册";
       
    }

</script> 
<form id="from1" runat="server">
     <div class="Registerlogin">
 <em class="fr">注册前，请认真阅读&nbsp;&nbsp;<a class="db logbtn fr" href="#">协议</a> </em>
 </div>

    <div class="register">

            <div class="title"><a class="title1 db fl">个人会员</a><a class="title2 db fl">企业会员</a></div>
            <div class="fr tit2"><span class="arr"></span></div>
			<div id="processor" >
				<ol class="processorBox oh">
					<li class="current" runat="server" id="processorBox1">
						<div class="step_inner fl">
							<span class="icon_step">1</span>
							<h4>填写基本信息</h4>
						</div>
					</li>
					<li runat="server" id="processorBox2">
						<div class="step_inner">
							<span class="icon_step">2</span>
							<h4>邮箱激活</h4>
						</div>
					</li>
					<li runat="server" id="processorBox3">
						<div class="step_inner fr">
							<span class="icon_step">3</span>
							<h4>注册完成</h4>
						</div>
					</li>
				</ol>
				<div class="step_line"></div>
			</div>
			<div class="content">
				<div id="step1" runat="server">
					
                        <div class="frm_control_group">
							<label class="frm_label">用户名</label>
							<div class="frm_controls">
                                <asp:TextBox id="userName" runat="server" ontextchanged="userName_TextChanged" AutoPostBack="true" class="frm_input userName"></asp:TextBox>
								<p class="frm_tips"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空" ForeColor="Red" ControlToValidate="userName"></asp:RequiredFieldValidator><asp:Label ID="LabelUserName" runat="server" Text=""></asp:Label></p>
							</div>
						</div>
                        
                        <div class="frm_control_group">
							<label class="frm_label">性别</label>
							<div class="frm_controls">
                                <asp:DropDownList ID="userSex" runat="server" class="frm_input">
                                    <asp:ListItem Text="女" Value="2" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="男" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                
							</div>
						</div>
						<div class="frm_control_group">
							<label class="frm_label">手机号</label>
							<div class="frm_controls">
                                <asp:TextBox id="userTele" runat="server" class="frm_input phone" maxlength="32"></asp:TextBox>
							
								<p class="frm_tips"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="手机号码不能为空" ForeColor="Red" ControlToValidate="userTele"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入正确的手机号" Display="Dynamic"  ControlToValidate="userTele" ValidationExpression="^[1][358][0-9]{9}$" ForeColor="Red"></asp:RegularExpressionValidator></p>
							</div>
						</div>
						<div class="frm_control_group">
							<label class="frm_label">邮箱</label>
							<div class="frm_controls">
                                <asp:TextBox id="userEmail" runat="server" class="frm_input email" maxlength="32" OnTextChanged="userEmail_TextChanged"  AutoPostBack="true"></asp:TextBox>
								<p class="frm_tips"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入邮件地址" ForeColor="Red" ControlToValidate="userEmail"></asp:RequiredFieldValidator><asp:Label ID="LabelUserEmail" runat="server" Text=""></asp:Label></p>
							</div>
						</div>
						<div class="frm_control_group">
							<label class="frm_label">密码</label>
							<div class="frm_controls">
                                <asp:textbox id="userPassword" textmode="Password" class="frm_input passwd" runat="server"></asp:textbox>

								<p class="frm_tips"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请填写密码" ForeColor="Red" ControlToValidate="userPassword"></asp:RequiredFieldValidator></p>
							</div>
						</div>
						<div class="frm_control_group">
							<label class="frm_label">再次输入密码</label>
							<div class="frm_controls">
                                 <asp:textbox id="txtConfirmPassword" textmode="Password" class="frm_input passwd2" runat="server"></asp:textbox>
                                <p class="frm_tips">
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致！" ControlToCompare="userPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator></p>
							</div>
						</div>
						<div class="frm_control_group">
							<label class="frm_label">验证码</label>
							<div class="frm_controls verifycode">
								<asp:textbox type="text" ID="ValidCode" placeholder=" 验证码" name="ValidCode" runat="server"  class="frm_input verifyCode" maxlength="4"></asp:textbox>
								<asp:Image ID="ValidCodeImg" ImageUrl="~/common/ValidateCode.aspx" runat="server" alt=""></asp:Image>
							</div>
						</div>
						<div class="toolBar">
                            <asp:Button  ID="FirsetStep" runat="server" Text="下一步" 
                            onclick="FirsetStep_Click" class="btn btn_primary" />
							
						</div>
					
				</div>
				<div id="step2" runat="server">
					<div class="w330">
						<strong class="f16">感谢注册，确认邮件已发送至你的注册邮箱 :<%=quserEmail%></strong>
						<p class="c7b"><br />请进入邮箱查看邮件，并激活您的帐号。</p>
						<p><a class="btn btn_primary mt20" href="javascript:;">登录邮箱</a></p>
						<p class="c7b mt20">没有收到邮件？</p>
						<p>1. 请检查邮箱地址是否正确，你可以返回<asp:Button ID="ReWriter" class="c46" runat="server" Text="重新填写" OnClick="ReWriter_Click" /></p>
						<p>2. 检查你的邮件垃圾箱</p>
						<p>3. 若仍未收到确认，请尝试 <asp:Button ID="ReSend" class="c46" runat="server" Text="重新发送" OnClick="ReSend_Click" /></p>
					</div>
				</div>
				<div id="step3" runat="server">
						<div class="w330">
						<strong class="f16">恭喜，注册成功！</strong>
                            <strong class="f16"><br /><br />作为本站会员，您可以享有以下特权：</strong>
                            <p class="c7b"><br />1，特权特权特权特权特权特权特权特权特权特权特权</p>
                            <p class="c7b"><br />2，特权特权特权特权特权特权特权特权特权特权特权</p>
                            <p class="c7b"><br />3，特权特权特权特权特权特权特权特权特权特权特权</p>
                            <p class="c7b"><br />4，特权特权特权特权特权特权特权特权特权特权特权</p>
                            <p class="c7b"><br />5，特权特权特权特权特权特权特权特权特权特权特权</p>
                            <p class="c7b"><br />6，特权特权特权特权特权特权特权特权特权特权特权</p>
                            </div>
						<div class="toolBar">
                            <a href="../index.shtml" class="btn btn_primary" target="_top" />回到首页</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<a href="" class="btn btn_primary" target="_top" />购物中心</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="UserCenter.aspx" class="btn btn_primary" target="_top" />个人中心</a>
						</div>
					
				</div>
			</div>
		</div>
		
	</form>
	


<%Response.WriteFile("../Footer.html");%>