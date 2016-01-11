<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allReminders.aspx.cs" Inherits="allReminders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
         #table{
            margin-left: 60px;
        }
        body {
             background: url(alarms2.jpeg) no-repeat center center fixed;
             -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
            margin : 0 auto;
        }
    </style>
    <form id="form1" runat="server">
        <div >
    <p style="text-align:right"> 
        <asp:Label ID="mainPageUsername" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
&nbsp;</p>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table>          
             <asp:Button ID="openMain" runat="server" Text="Main" style="width:90px;" OnClick="openMain_Click" />
        <asp:Button ID="openNotes" runat="server" Text="Notes" style="width:90px;" OnClick="openNotes_Click1" />
        <asp:Button ID="openReminders" runat="server" Text="Reminder" style="width:90px" OnClick="openReminders_Click"/>
        <asp:Button ID="openAlarms" runat="server" Text="Alarms" style="width:90px" OnClick="openAlarms_Click"/>
        <asp:Button ID="openContacts" runat="server" Text="Contacts" style="width:90px" OnClick="openContacts_Click" />      
        <asp:Button ID="openSettings" runat="server" Text="Settings" style="width:90px" OnClick="openSettings_Click" />    
                <asp:Button ID="Logout" runat="server" Text="LOGOUT" style="width:90px" OnClick="Logout_Click" />         
        </table>
      <hr />
    </div>
    <div>
        <table id="table">
            <tr>
                <th>All Reminders</th>
            </tr>
            <asp:Label ID="lbl_table" runat="server" Text="Label"></asp:Label>
        </table>
    </div>
    </form>
</body>
</html>
