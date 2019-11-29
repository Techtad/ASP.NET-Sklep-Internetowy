<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptPage.aspx.cs" Inherits="as_webforms_webApi_sklep.ReceiptPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>F3B.com - Strona główna</title>
    <link href="css/all.css" rel="stylesheet" />
    <style>
        form {
            width: 800px;
            height: 600px;
            margin: auto;
            background: #2b6cae;
            color: white;
            text-align: center;
            position: relative;
        }

        a {
            display: block;
            position: absolute;
            top: 50%;
            left: 32%;
            height: 24px;
            margin: auto;
            background-color: #253147;
            text-decoration: none;
            color: #ffffff;
        }

            a:hover {
                display: block;
                background-color: #2195e0;
                text-decoration: none;
                color: white;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div style="position:absolute; top: 40%">Twoje zamówienie zostało przyjętę. Wkrótce otrzymasz wiadomość email z zamówionymi kluczami.</div>
            <div><a href="MainForm.aspx">Powrót do strony głównej</a>
        </div>
    </form>
</body>
</html>
