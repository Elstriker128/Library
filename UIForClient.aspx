<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UIForClient.aspx.cs" Inherits="Library.UIForClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/StyleForUI.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <asp:CustomValidator ID="CustomValidator6" runat="server" CssClass="lab"></asp:CustomValidator>
            <br />
            <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="lab"></asp:CustomValidator>
            <br />
            <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="lab"></asp:CustomValidator>
            <br />
            <asp:CustomValidator ID="CustomValidator3" runat="server" CssClass="lab"></asp:CustomValidator>
            <br />
            <asp:CustomValidator ID="CustomValidator4" runat="server" CssClass="lab"></asp:CustomValidator>
            <br />
            <asp:CustomValidator ID="CustomValidator5" runat="server" CssClass="lab"></asp:CustomValidator>
            <br />
            Input data path to the data files&#39; directory:
            <asp:TextBox ID="TextBox1" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Data path is essential for calculations" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:Button ID="Button2" runat="server" CausesValidation="False" Text="Remove" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" EnableTheming="True"></asp:PlaceHolder>
            <br />
            <asp:PlaceHolder ID="PlaceHolder2" runat="server" EnableTheming="True"></asp:PlaceHolder>
            <br />
            <asp:PlaceHolder ID="PlaceHolder3" runat="server" EnableTheming="True"></asp:PlaceHolder>
            <br />
            <asp:PlaceHolder ID="PlaceHolder4" runat="server" EnableTheming="True"></asp:PlaceHolder>
            <br />
            <asp:PlaceHolder ID="PlaceHolder5" runat="server" EnableTheming="True"></asp:PlaceHolder>
            <br />
            <asp:PlaceHolder ID="PlaceHolder6" runat="server" EnableTheming="True"></asp:PlaceHolder>
            <br />
            <asp:PlaceHolder ID="PlaceHolder7" runat="server" EnableTheming="True"></asp:PlaceHolder>
            <br />
            <asp:PlaceHolder ID="PlaceHolder8" runat="server" EnableTheming="True"></asp:PlaceHolder>
            <br />
            <asp:PlaceHolder ID="PlaceHolder9" runat="server" EnableTheming="True"></asp:PlaceHolder>
            <br />
            <asp:PlaceHolder ID="PlaceHolder10" runat="server" EnableTheming="True"></asp:PlaceHolder>
            <br />
        </div>
    </form>
</body>
</html>
