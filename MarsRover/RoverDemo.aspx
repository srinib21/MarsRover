<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoverDemo.aspx.cs" Inherits="MarsRover.RoverDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Demo for Mars Rover Landing</h1>
    </div>
        <div>
            <label>Enter Plateau Size (Eg: 4 4): </label> <input type="text" name="txtPlateauDimension" title="Enter plateau size"/>
        </div>
        
        <div>
            <label>Enter Rover Initial Position ( X Y Direction Eg: 1 2 N): </label> <input type="text" name="txtInitRover" title="Enter rover position"/>
        </div>

        
        <div>
            <label>Enter Rover Commands ( Eg: LMMLLM): </label> <input type="text" name="txtCommands" title="Enter rover commands"/>
        </div>

        <button>Process</button>    
    </form>
</body>
</html>
