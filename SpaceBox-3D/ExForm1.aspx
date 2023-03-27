

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <canvas id="myCanvas" width="500" height="500"></canvas>
    <script>
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');
    
    function drawShapes() {
        ctx.fillStyle = 'red';
        ctx.fillRect(10, 10, 50, 50);
    }
    </script>
    <button onclick="drawShapes()">Draw Shape</button>
    <form id="form1" runat="server">
        <div>
        </div>


         <asp:TextBox ID="Preview" runat="server" BackColor="#3B3B3B" BorderColor="#3B3B3B" BorderStyle="Dotted" Height="100px" MaxLength="150000" ReadOnly="True" Width="557px"></asp:TextBox>

    </form>
</body>
</html>
