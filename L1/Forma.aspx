<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="Forma.aspx.cs" Inherits="L1.Forma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 
        {
            text-align: center;
        }

        table
        {   
            table-layout: fixed;
            width: 100%;
            background-color: #ed8c2c;
        }

        body 
        {
            background-color: #f3b272;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server" aria-orientation="horizontal">
        <asp:Label ID="Label1" runat="server" Font-Bold="False"
            Font-Names="Mistral" Font-Size="100pt" Text="Dėmė" 
            ForeColor="#C46A11"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server"
            Text="Įveskite eilučių(N) bei stulpelių(M) skaičių:"
            Font-Bold="True" Font-Names="Malgun Gothic Semilight"></asp:Label>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1"
            runat="server" ForeColor="Black" Font-Names="Malgun Gothic Semilight" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server"
            Font-Size="20pt" Text="N(Max- 20) : "
            Font-Names="Malgun Gothic Semilight"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"
            Height="30px" OnTextChanged="TextBox1_TextChanged"
            Width="60px" Font-Names="Malgun Gothic Semilight"
            BackColor="#ED8C2C" BorderColor="#FF9933" Font-Size="15pt"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
            runat="server" ControlToValidate="TextBox1" 
            ErrorMessage="Būtina įvesti eilučių kiekį !" 
            ForeColor="Black"> *</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server"
            ControlToValidate="TextBox1" ErrorMessage="Netinkamas eilučių skaičius!"
            ForeColor="Black" MaximumValue="20" MinimumValue="1" 
            Type="Integer" BorderStyle="None" 
            Font-Names="Malgun Gothic Semilight"></asp:RangeValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Font-Size="20pt"
            Text="M(Max- 70) : " Font-Names="Malgun Gothic Semilight"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="30px"
            Width="60px" Font-Names="Malgun Gothic Semilight" 
            BackColor="#ED8C2C" BorderColor="#FF9933" 
            Font-Size="15pt"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            runat="server" ControlToValidate="TextBox2"
            ErrorMessage="Būtina įvesti stulpelių kiekį !" 
            ForeColor="Black">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator2" 
            runat="server" ControlToValidate="TextBox2" 
            ErrorMessage="Netinkamas stulpelių skaičius!"
            ForeColor="Black" MaximumValue="70" MinimumValue="1"
            Type="Integer" Font-Names="Malgun Gothic Semilight"></asp:RangeValidator>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="50px" 
            OnClick="Button1_Click" Text="Generuoti lauką"
            Width="300px" Font-Names="Malgun Gothic Semilight"
            BackColor="#ED8C2C" BorderColor="#FF9933" Font-Size="15pt" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server"
            Height="50px" Text="Uždėti dėmes" Width="150px"
            OnClick="Button3_Click" Font-Names="Malgun Gothic Semilight"
            BackColor="#ED8C2C" BorderColor="#FF9933" Font-Size="15pt" />
        <asp:Button ID="Button5" runat="server"
            OnClick="Button5_Click" Text="Valyti dėmės"
            Width="150px" Height="50px" Font-Names="Malgun Gothic Semilight"
            BackColor="#ED8C2C" BorderColor="#FF9933" Font-Size="15pt" />
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Height="50px"
            Text="Apskaičiuoti" Width="300px" OnClick="Button4_Click"
            Font-Names="Malgun Gothic Semilight" BackColor="#ED8C2C"
            BorderColor="#FF9933" Font-Size="15pt" />
        <br />
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" BorderColor="Black"
            BorderStyle="Solid" BorderWidth="1px" GridLines="Both"
            Height="16px" style="margin-left: 301px; text-align: center;"
            Width="1303px" HorizontalAlign="Center"
            Font-Names="Malgun Gothic Semilight">
        </asp:Table>
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True"
            Text="REZULTATAI" Font-Names="Malgun Gothic Semilight"></asp:Label>
        <br />
        <br />
        <asp:Table ID="Table2" runat="server" BorderColor="Black"
            BorderStyle="Solid" BorderWidth="1px"
            GridLines="Both" Height="16px" 
            style="margin-left: 702px; text-align: center;"
            Width="500px" HorizontalAlign="Center" 
            Font-Names="Malgun Gothic Semilight">
        </asp:Table>
        <br />
        <br />
        <br />
    </form>
</body>
</html>


