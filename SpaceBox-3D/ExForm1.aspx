

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script>

        function drawPreviewShape() {
            // Get the values from the form
            var shapeType = document.getElementById('shapeType').value;
            var width = document.getElementById('width').value;
            var height = document.getElementById('height').value;
            var radius = document.getElementById('radius').value;
            var base = document.getElementById('base').value;

            // Get the canvas element
            var canvas = document.getElementById('previewCanvas');

            // Check if the canvas is supported
            if (canvas.getContext) {
                var ctx = canvas.getContext('2d');

                // Clear the canvas
                ctx.clearRect(0, 0, canvas.width, canvas.height);

                // Draw the preview shape
                if (shapeType === 'rectangle') {
                    ctx.fillStyle = 'blue';
                    ctx.fillRect(10, 10, width, height);
                } else if (shapeType === 'circle') {
                    ctx.fillStyle = 'green';
                    ctx.beginPath();
                    ctx.arc(200, 200, radius, 0, 2 * Math.PI);
                    ctx.fill();
                } else if (shapeType === 'triangle') {
                        ctx.fillStyle = 'red';
                        ctx.beginPath();
                        ctx.moveTo(10, 10);
                        ctx.lineTo(base + 10, 10 + height);
                        ctx.lineTo(10, 10 + height);
                        ctx.closePath();
                        ctx.fill();
                }
            }
        }
    </script>

<body>
    <form id="form1" runat="server">
        <div>
            <canvas id="previewCanvas" width="500" height="500"></canvas>

            <select id="shapeType" onchange="drawPreviewShape()">
     <option value="rectangle">Rectangle</option>
     <option value="circle">Circle</option>
                <option value="triangle">Triangle</option>
    </select>
    <input id="width" type="number" value="100" onchange="drawPreviewShape()"/>
    <input id="height" type="number" value="100" onchange="drawPreviewShape()"/>
    <input id="radius" type="number" value="50" onchange="drawPreviewShape()"/>
    <input id="base" type="number" value="100" onchange="drawPreviewShape()"/>

        </div>


         

    </form>
</body>
</html>
