<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="f3b_store.Verification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>F3B.com - Email Zweryfikowany</title>
    <link href="css/all.css" rel="stylesheet" />
    <link href="/css/MainPage/headerStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div id="title">
                <img runat="server" src="res/img/logo.png" />
            </div>
            <div id="menu">
                <div id="menu-list-box">
                    <ul id="menu-list">
                        <li>
                            <asp:LinkButton ID="lbToMain" runat="server" PostBackUrl="~/MainPage.aspx">Strona główna</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lbToLogin" runat="server" PostBackUrl="~/LoginPage.aspx">Logowanie</asp:LinkButton>
                        </li>
                     </ul>
                </div>
            </div>
        </header>
        <h1><asp:Literal ID="ltMessage" runat="server" /></h1>
    </form>
 </body>
</html>
