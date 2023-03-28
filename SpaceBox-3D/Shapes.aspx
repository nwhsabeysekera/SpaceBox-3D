<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shapes.aspx.cs" Inherits="SpaceBox_3D.Shapes" Theme="" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <link href="./Content/styles.css" rel="stylesheet" />
    <link href="./Content/site.css" rel="stylesheet" />
    <link href="https://cdn.tailwindcss.com" rel="stylesheet">
     <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Readex+Pro:wght@200;300;400;500;600;700&display=swap" rel="stylesheet">

    <title>Shapes</title>
</head>
<body style="background-color: #2f2f2f";>

    <form id="form1" runat="server">
        <div class="flex justify-center items-center h-screen">
        <div class="container">
        <asp:Label ID="Label1" runat="server"  Style="position: absolute; top: 40px; left: 470px;"  Font-Names="readex pro deca medium" Font-Size="96px" class="Font-Bold" ForeColor="#E6A02D" Height="120px" Text="SpaceBox-3D" Width="606px" Font-Bold="True"></asp:Label>
            </div>
            </div>

        <div class="flex justify-center items-center" Style="position: absolute; top: 250px; left: 470px;">
         <div class="relative inline-block text-left">
         <asp:DropDownList ID="SelectShape" runat="server" BackColor="#3B3B3B"  ForeColor="#FFCB74" Height="60px" Width="200px" Font-Size="20px" style="border-radius: 5px;border:2px #E6A02D ;">
            <asp:ListItem>Select Shape</asp:ListItem>
            <asp:ListItem>Circle</asp:ListItem>
            <asp:ListItem>Rectangle</asp:ListItem>
            <asp:ListItem>Triangle</asp:ListItem>
         </asp:DropDownList>
             </div>


             <div Style="position: absolute; top: -2px; left: 300px;">  
                 <asp:TextBox ID="Length" runat="server" BackColor="#686868" Font-Names="readex pro deca medium" Font-Size="20px" Height="50px" TextMode="Number" Width="250px" ForeColor="White" OnTextChanged="Length_TextChanged" PlaceHolder="Length"  style="border-radius: 5px;" BorderColor="#686868" CssClass="placeholder">Length</asp:TextBox>
                </div>
               
              <div Style="position: absolute; top: 65px; left: 300px;">
                 <asp:TextBox ID="Width" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Font-Size="20px" Height="50px" TextMode="Number" Width="250px" ForeColor="White" OnTextChanged="Length_TextChanged" PlaceHolder="Width"  style="border-radius: 5px;" BorderColor="#3B3B3B" CssClass="placeholder">Width</asp:TextBox>
               </div>
        
        
                  <div Style="position: absolute; top: 135px; left: 300px;">
                 <asp:TextBox ID="Thickness" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Font-Size="20px" Height="50px" TextMode="Number" Width="250px" ForeColor="White" OnTextChanged="Length_TextChanged" PlaceHolder="Thickness"  style="border-radius: 5px;" BorderColor="#3B3B3B" CssClass="placeholder">Thickness</asp:TextBox>
                </div>

                 </div>
        
        <div Style="position: absolute; top: 450px; left: 770px;">
        <asp:CheckBox ID="CheckBox" runat="server" AutoPostBack="True" BorderColor="#FFCB74" Font-Names="readex pro deca medium" Font-Size="20px" Font-Strikeout="False" Text="Fill" TextAlign="Left" ForeColor="White"  />
        </div>

        <div Style="position: absolute; top: 500px; left: 768px;">
        <asp:Button ID="btnApply" runat="server" BackColor="#FFCB74" BorderColor="#FFCB74" Height="55px" Text="Apply" Width="120px" style="border-radius: 40px;" Font-Names="readex pro deca medium" Font-Size="20px" />
        </div>
        <div Style="position: absolute; top: 500px; left: 910px;">
        <asp:Button ID="btnClear" runat="server" BackColor="#3B3B3B" BorderColor="#FFCB74" Height="55px" Text="Clear" Width="120px" style="border-radius: 40px;" ForeColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="readex pro deca medium" Font-Size="20px" />
        </div>
        
            
     
        <div Style="position: absolute; top: 600px; left: 460px;">
            <asp:Panel ID="PreviewPanel" runat="server" BackColor="#3B3B3B" Height="200px" Width="568px">
        </asp:Panel>
        </div>  


   
        <div Style="position: absolute; top: 830px; left: 600px;">
        <asp:Button ID="btnPrint" runat="server" BackColor="#FFCB74" BorderColor="#FFCB74" Height="55px" Text="Print" Width="120px" style="border-radius: 40px;" Font-Names="readex pro deca medium" Font-Size="20px" />
        </div>
                         
         <div Style="position: absolute; top: 830px; left: 770px;">
        <asp:Button ID="btnCancel" runat="server" BackColor="#3B3B3B" BorderColor="#FFCB74" Height="55px" Text="Cancel" Width="120px" style="border-radius: 40px;" ForeColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="readex pro deca medium" Font-Size="20px" />
        </div>




     
   
        




     
   
    </form>



    </body>
</html>
