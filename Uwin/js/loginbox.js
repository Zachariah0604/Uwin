
$().ready(function () {
    $('#btn_login').click(function () {
        if ($('#txtusername').val() == "" || $('#txtpassword').val() == "") {
            alert("用户名或密码不能为空！");
        }
        else {
            $.ajax({
                type: "POST",
                url: "./common/UserLogin.ashx",
                data: "username=" + escape($('#txtusername').val()) + "&password=" + escape($('#txtpassword').val()),
                beforeSend: function () {
                 //   $("#loading").css("display", "block");
                 //   $("#login").css("display", "none");
                },
                success: function (msg) {
                    $("#loading").hide(); 
                    if (msg == "success") {
                        parent.document.location.href = "../common/LoginSuccess.html"; 
                        parent.tb_remove();
                    }
                    if (msg == "fail") {
                        alert("登录失败！");
                    }
                },
                complete: function (data) {
                  //  $("#loading").css("display", "none"); 
                  //  $("#login").css("display", "block");
                },
                error: function (XMLHttpRequest, textStatus, thrownError) {
                }
            });
        }
    });
});