<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet"/>
  <style>   
       
  </style>
</head>
<body >
   
    <form id="form1" runat="server">
    <div id="page-wrap">
        
    <h1 style="text-align:center ; color:green"> UrDIARY</h1>

        <hr />
       
        
        
        
        <pre>&nbsp;</pre>
        <pre>&nbsp;</pre>
          <p style="text-align:center"><i>Username:<asp:TextBox ID="loginId" runat="server" CssClass="css-input" Width="190px"></asp:TextBox>
              </i>
        </p>
        <p style="text-align:center"><i>Password: <asp:TextBox ID="loginPass" runat="server" CssClass="css-input" Width="190px" TextMode="Password"></asp:TextBox>
            </i>
        </p>
        <p style="text-align:center; text-size-adjust:300%" >
            <asp:Button ID="submitID" runat="server" OnClick="Button1_Click" Text="Submit" class="btn" CssClass="btn"  />
        </p>
        <pre style="text-align:center" ><asp:Label ID="checking" runat="server"></asp:Label></pre>
        <hr />
        <pre style=" font-size:large"><b><i>                                                                                                          Create New Account </i></b></pre>
        <pre style="text-align:right; font-size:large ; color:white"><b><i>Username: <asp:TextBox ID="newId" runat="server" CssClass="css-input" Width="217px" OnTextChanged="newId_TextChanged"></asp:TextBox></i></b></pre>
        <pre style="text-align:right; font-size:large; color:white "><b><i>Password: <asp:TextBox ID="newPass" runat="server" CssClass="css-input" Width="217px" OnTextChanged="newPass_TextChanged1" TextMode="Password"></asp:TextBox></i></b></pre>
        <pre style="text-align:right; font-size:large ; color:white"><b><i>Email ID: <asp:TextBox ID="newEmailid" runat="server" CssClass="css-input" Width="217px"></asp:TextBox></i></b></pre>
        <pre  style="text-align:right;"> <asp:Button ID="signUp" runat="server" Text="SignUp!" CssClass="btn" OnClick="signUp_Click" /></pre>
       </div>
    </form>
</body>
</html>
