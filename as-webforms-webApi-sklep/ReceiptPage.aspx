<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptPage.aspx.cs" Inherits="as_webforms_webApi_sklep.ReceiptPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>F3B.com - Strona główna</title>
    <link href="css/all.css" rel="stylesheet" />
        <link href="/css/MainPage/headerStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div id="title">
                <img src="res/img/logo.png" />
            </div>
            <div id="menu">
                <div id="menu-list-box">
                    <ul id="menu-list">
                        <li>
                            <asp:LinkButton ID="lbToLogin" runat="server" PostBackUrl="~/MainForm.aspx">Strona główna</asp:LinkButton>
                        </li>
                </div>
            </div>
        </header>
        <div style="text-align: center">Twoje zamówienie zostało przyjętę. Wkrótce otrzymasz wiadomość email z zamówionymi kluczami.</div>
    </form>
</body>
</html>
