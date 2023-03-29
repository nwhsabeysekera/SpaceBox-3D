<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrailleConverterUI.aspx.cs" Inherits="SpaceBox_3D.BrailleConvertor.BrailleConverterUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p aria-orientation="horizontal">
            <asp:TextBox ID="inputTextBox" runat="server" Columns="10" Height="82px" Rows="10" TextMode="MultiLine" Width="518px"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="outputTextBox" runat="server" Height="93px" ReadOnly="True" Width="509px"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Convert to Braille" />
        </p>
    </form>
</body>
</html>
