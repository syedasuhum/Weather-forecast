<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeFile="Default.aspx.cs" Inherits="Weather_app_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Weather App</title>
    <style>
        body{
            margin:20px;
            font-weight:500;
            color:purple;
            /* background-color: red;*/ /* For browsers that do not support gradients */
  /*color: linear-gradient(to right, red, orange, yellow, green, blue, indigo, violet);*/
        }
       
       .mybody {
/*background-position:center;
  filter:blur(2px);
   background-image:url(img.jpg);
            background-repeat:no-repeat;
             height:600px;*/
position: absolute; 
            height: 600px; 
            width: 600px; 
            background-image:url(img.jpg); 
            background-size: cover; 
            background-position: center; 
            filter: blur(2px); 
            z-index: -1;
            justify-items:center;
            margin-left:350px;
}
        .container{
          /*  border:1px solid gray;*/
            padding:25px;
           
            
          /*  background-color:#ccc;*/
            /*background-color: red;*/ /* For browsers that do not support gradients */
            /*background-image: linear-gradient(red, yellow);*/
  width:600px;
   text-align:center;
/*   position:absolute;*/
   
   
   margin-left:350px;
    /* box-shadow: 10px 10px 5px lightblue;*/
        }

        .text{
            font-size:18px;
            font-weight:600;
            
        }
        .input_text{
            border:1px solid black;
            border-radius:5px;
            height:25px;
             background-color: transparent;
           
        }
        .btn{
            color:white;
            background-color:black;
            width:auto;
            height:25px;
            border:none;
            font-size:15px;
            border-radius:5px;
            font-weight:600;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mybody"></div>
           
            <div class="container">
                 <h1>Weather App</h1>
            <label for="txtCityName" class="text">Enter City/State Name:</label>
            <asp:TextBox ID="txtCityName"  CssClass="input_text" runat="server"></asp:TextBox>
            <asp:Button ID="btnGetWeather" runat="server" CssClass="btn" Text="Get Weather" OnClick="btnGetWeather_Click" />
            
            <asp:Label ID="lblWeatherInfo" runat="server" Visible="false"></asp:Label>
        </div>
            
    </form>
</body>
</html>
