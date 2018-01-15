<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    .btn-someone {
        background-color: #ff006c;
        background-image: url(someone-white.svg);
        background-repeat: no-repeat;
        background-position: 10px 5px;
        background-size: 19px;
        border: none;
        color: white;
        padding: 10px 12px 10px 40px;
        line-height: 20px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">

		<p>
			Someone.id API demo
		</p>

		<p>
            <%=Description  %>
		</p>

        <p>
            <%if (!Logged)
                { %>
                <asp:Button ID="CmdLogin" runat="server" CssClass="btn-someone" OnClick="CmdLogin_Click" Text="Login with Someone.id" />
            <%}
            else{%>
                <a href="/">Logout</a>
            <%}%>
            
        </p>

    </form>
</body>
</html>
