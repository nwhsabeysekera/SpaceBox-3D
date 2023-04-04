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
    <link rel="icon" href="/icon.png" type="image/x-icon"/>
</head>

<body style="background-color: #2f2f2f";>

    <form id="form1" runat="server">
        <div class="flex justify-center items-center h-screen">
        <div class="container">
            <asp:Label ID="Label1" runat="server"  Style="position: absolute; top: 40px; left: 515px;"  Font-Names="readex pro deca medium" Font-Size="60pt" class="Font-Bold" ForeColor="#E6A02D" Height="120px" Text="SpaceBox-3D" Width="606px" Font-Bold="True"></asp:Label>
        </div>
        </div>

        <div class="flex justify-center items-center" Style="position: absolute; top: 240px; left: 470px;">
          <div class="relative inline-block text-left">
            <asp:DropDownList ID="SelectShape" runat="server"  BackColor="#3B3B3B"  ForeColor="#FFCB74" Height="75px" Width="250px" Font-Size="20px" style="border-radius: 5px;border:2px #E6A02D ;" OnSelectedIndexChanged="SelectShape_SelectedIndexChanged" AutoPostBack="True">
                 <asp:ListItem>Select Shape</asp:ListItem>
                 <asp:ListItem>Circle</asp:ListItem>
                 <asp:ListItem>Rectangle</asp:ListItem>
                 <asp:ListItem>Triangle</asp:ListItem>
            </asp:DropDownList>
         </div>

            <!-- Rectangle -->

             <div Style="position: absolute; top: -2px; left: 310px;">  
               <asp:TextBox ID="Length" runat="server" BackColor="#686868" Font-Names="readex pro deca medium" Font-Size="20px" Height="45px" TextMode="Number" Width="240px" ForeColor="White"  PlaceHolder="Length || 0mm"  style="border-radius: 5px;" BorderColor="#686868" CssClass="placeholder" >Length</asp:TextBox>
             </div>
               
              <div Style="position: absolute; top: 65px; left: 310px;">
                <asp:TextBox ID="Width" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Font-Size="20px" Height="45px" TextMode="Number" Width="240px" ForeColor="White" PlaceHolder="Width || 0mm" Style="border-radius: 5px;" BorderColor="#3B3B3B" CssClass="placeholder" AutoPostBack="True" >Width</asp:TextBox>
              </div>

            <!-- Circle -->

             <div Style="position: absolute; top: -1px; left: 310px;">
               <asp:TextBox ID="Radius" runat="server" BackColor="#686868" Font-Names="readex pro deca medium" Font-Size="20px" Height="45px" TextMode="Number" Width="240px" ForeColor="White" PlaceHolder="Radius || 0mm" Style="border-radius: 5px;" BorderColor="#686868" CssClass="placeholder" AutoPostBack="True">Radius</asp:TextBox>
             </div>

             <div Style="position: absolute; top: 122px; left: 310px;">
               <asp:TextBox ID="CenterX" runat="server" BackColor="#686868" Font-Names="readex pro deca medium" Font-Size="20px" Height="45px" TextMode="Number" Width="240px" ForeColor="White" PlaceHolder="Center X"  style="border-radius: 5px;" BorderColor="#686868" CssClass="placeholder"  >CenterX</asp:TextBox>
             </div>

             <div Style="position: absolute; top: 64px; left: 310px;">
               <asp:TextBox ID="CenterY" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Font-Size="20px" Height="45px" TextMode="Number" Width="240px" ForeColor="White" PlaceHolder="Center Y" style="border-radius: 5px;" BorderColor="#3B3B3B" CssClass="placeholder" >CenterY</asp:TextBox>
             </div>

            
            <!-- Triangle -->

             <div Style="position: absolute; top: -3px; left: 310px;">
               <asp:TextBox ID="SideALength" runat="server" BackColor="#686868" Font-Names="readex pro deca medium" Font-Size="20px" Height="45px" TextMode="Number" Width="240px" ForeColor="White" PlaceHolder="Side A" style="border-radius: 5px;" BorderColor="#686868" CssClass="placeholder" >SideALength</asp:TextBox>
             </div>          

             <div Style="position: absolute; top: 61px; left: 310px;">
               <asp:TextBox ID="SideBLength" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Font-Size="20px" Height="45px" TextMode="Number" Width="240px" ForeColor="White" PlaceHolder="Side B" style="border-radius: 5px;" BorderColor="#3B3B3B" CssClass="placeholder" >SideBLength</asp:TextBox>
             </div>

             <div Style="position: absolute; top: 123px; left: 310px;">
               <asp:TextBox ID="SideCLength" runat="server" BackColor="#686868" Font-Names="readex pro deca medium" Font-Size="20px" Height="45px" TextMode="Number" Width="240px" ForeColor="White" PlaceHolder="Side C" style="border-radius: 5px;" BorderColor="#686868" CssClass="placeholder" >SideCLength</asp:TextBox>
             </div>
            
            </div>

        <div Style="position: absolute; top: 453px; left: 780px;">
          <asp:Button ID="btnApply" runat="server" BackColor="#FFCB74" BorderColor="#FFCB74" Height="45px" Text="Apply" Width="100px" style="border-radius: 30px;" Font-Names="readex pro deca medium" Font-Size="15px" OnClick="btnApply_Click" />
        </div>

        <div Style="position: absolute; top: 453px; left: 920px;">
          <asp:Button ID="btnClear" runat="server" BackColor="#3B3B3B" BorderColor="#FFCB74" Height="45px" Text="Clear" Width="100px" style="border-radius: 30px;" ForeColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="readex pro deca medium" Font-Size="15px" OnClick="btnClear_Click" />
        </div>

         <div Style="position: absolute; top: 525px; left: 470px;">
            <asp:Label ID="lblShowPreview" runat="server" BorderStyle="Solid" style="border-radius: 20px;" Font-Names="readex pro deca medium" Font-Size="15px" ForeColor="White" Height="25px" Text="Dot Amount:" Width="95px"></asp:Label>
        </div>


         <div Style="position: absolute; top: 559px; left: 470px;">
           <asp:Panel ID="PreveiwPanel" runat="server" BackColor="#3B3B3B" Height="180px" Width="558px"> </asp:Panel>
             <div Style="position: absolute; top: 60px; left: 220px;">
               <asp:Label ID="LabelPreview" runat="server" Font-Names="readex pro deca medium" Font-Size="18px" ForeColor="White" ></asp:Label>
             </div>
        </div>

         
        <div Style="position: absolute; top: 810px; left: 600px;">
           <asp:Button ID="btnPrint" runat="server" Text="Print" BackColor="#FFCB74" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca" Font-Size="Medium" ForeColor="#2F2F2F" Height="40px" Width="120px" style="border-radius: 30px;" />
        </div>
                         
        <div Style="position: absolute; top: 810px; left: 790px;">
          <asp:Button ID="btnCancel" runat="server" Text="Cancel" BackColor="#3B3B3B" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca" Font-Size="Medium" ForeColor="#FFCB74" Height="40px" Width="120px" style="border-radius: 30px;" OnClick="btnCancel_Click" />
        </div>  
    
    </form>
   </body>
</html>

