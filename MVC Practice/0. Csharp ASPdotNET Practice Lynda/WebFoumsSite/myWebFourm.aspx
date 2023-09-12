<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myWebFourm.aspx.cs" Inherits="myWebFourm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
    <div>
        

         <%--  this is a web server control --%>
        <h1>Upload a file</h1>
        Submission name : 
    <asp:TextBox ID="TextBox1" runat="server" Width="128px"></asp:TextBox>
        
        <br />
        Type : 
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="b" Text="BINARY"/>
            <asp:ListItem Value="a" Text="ASCII" />
        </asp:DropDownList>

        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="SAVE"  OnClick="Button1_Click"/>
   <%-- we'll add a littren that we can dinamicly replace with any litteral or html   --%>
        <asp:Literal ID="FeedBack" runat="server">

        </asp:Literal>



    
    </div>
    </form>
</body>
</html>
