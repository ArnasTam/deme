<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma.aspx.cs" Inherits="L1.Forma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" aria-orientation="horizontal">
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Mistral" Font-Size="50pt" Text="Dėmė"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="----------------------------------------------------------------------------------------------------------------------------------------------------------------------------"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Įveskite eilučių(N) bei stulpelių(M) skaičių:"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Size="20pt" Text="N - "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="16px" OnTextChanged="TextBox1_TextChanged" Width="47px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Font-Size="20pt" Text="M - "></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="16px" Width="47px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="25px" OnClick="Button1_Click" Text="Generuoti lauką" Width="150px" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Height="25px" Text="Uždėti dėmes" Width="150px" />
&nbsp;<br />
        <br />
        <asp:Button ID="Button4" runat="server" Height="25px" Text="Apskaičiuoti" Width="150px" />
        <br />
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" Height="16px" style="margin-left: 350px" Width="692px">
        </asp:Table>
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="REZULTATAI"></asp:Label>
        <br />
        <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" Height="16px" style="margin-left: 510px" Width="361px">
        </asp:Table>
        <br />
        <br />
    </form>
</body>
</html>
