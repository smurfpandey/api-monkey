<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonkeyGet.aspx.cs" Inherits="APIMonkey.MonkeyUI.MonkeyGet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/jsoneditor.css" rel="stylesheet" />
    <link href="css/MonkeyCSS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-12">
            <div class="page-header">
                GET YOUR BANANA
            </div>
            <div>
                <input id="urlSeg" class="monkey-url-ip" type="text" placeholder="Your Url" />
            </div>
            <div style="margin-top: 20px">
                <input id="getBanana" type="button" class="btn btn-primary" value="GET" />
            </div>
            <div id="divJsonEditor" style="margin-top: 20px">
                <div id="jsoneditor" style="height: 700px">
                </div>
            </div>
        </div>
    </form>
    <script src="Script/jquery-1.11.3.min.js"></script>
    <script src="Script/jsoneditor.js"></script>
    <script src="Script/monkey-api.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var objMonkey = new MonkeyGetApi();
            objMonkey.init();
        });
    </script>
</body>
</html>
