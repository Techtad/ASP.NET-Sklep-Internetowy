<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="BasketPage.aspx.cs" Inherits="f3b_store.BasketPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>F3B.com - Koszyk</title>
    <link href="css/all.css" rel="stylesheet" />
        <link href="/css/MainPage/headerStyle.css" rel="stylesheet" />
    <style type="text/css">
        * {
            color: white;
        }

        #container {
            margin: auto;
            background-color: 	#253147;
            width: 800px;
            min-height: 600px;
            text-align: center;
            padding: 10%:
        }

        table {
            margin: 0 auto;
            background-color: #2b6cae;
            padding: 0;
        }

        td, th {
            border: 2px solid #e1e8f0;
            padding: 5px;
            min-width: 150px;
        }

        input {
            color: black;
        }
    </style>
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
                            <asp:LinkButton ID="lbToLogin" runat="server" PostBackUrl="~/MainPage.aspx">Strona główna</asp:LinkButton>
                        </li>
                </div>
            </div>
        </header>
        <div id="container">
            <table>
                <tr>
                    <th>
                        Produkt
                    </th>
                    <th>Ilość</th>
                    <th>Cena</th>
                    <th>-</th>
                </tr>
                <asp:Repeater ID="rBasket" runat="server" OnItemCommand="basketHandler">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("name") %></td>
                            <td>
                                <asp:TextBox ID="tbAmount" runat="server" type="number" value='<%# Eval("amount") %>' max='<%# f3b_store.DBOperations.selectQuery("SELECT stock FROM product_info WHERE id LIKE \"" + Eval("id") + "\"").Rows[0]["stock"] %>' min="1" step="1"></asp:TextBox>
                                <asp:Button ID="bChangeProduct" CommandName="changeInBasket" CommandArgument='<%# Eval("id") %>' runat="server" Text="Zmień ilość" />
                            </td>
                            <td ><%# Eval("price") + " <span class='currency'>zł</span>" %></td>
                            <td><asp:Button ID="bRemoveProduct" CommandName="removeFromBasket" CommandArgument='<%# Eval("id") %>' runat="server" Text="Usuń z koszyka" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td style="text-align: right" colspan="2">Suma:</td>
                    <td><asp:Label ID="lTotalPrice" runat="server" Text=""></asp:Label></td>
                    <td>-</td>
                </tr>
            </table>
            <div style="text-align: center">
                <span>Email:</span>
                <asp:TextBox ID="tbEmail" runat="server" TextMode="Email" ForeColor="Black" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ControlToValidate="tbEmail" ErrorMessage="Wpisz poprawny adres email." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:Button ID="bOrder" runat="server" OnClick="bOrder_Click" Text="Złóż zamówienie" />
            </div>
        </div>
    </form>
</body>
</html>
