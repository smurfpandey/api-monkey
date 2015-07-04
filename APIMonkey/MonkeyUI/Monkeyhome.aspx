<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Monkeyhome.aspx.cs" Inherits="APIMonkey.MonkeyUI.Monkeyhome" %>

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
                GIVE THE MONKEY A BANANA
            </div>
            <div class="">
                <div class="banana-loc-div-container hide">
                    <div class="monkey-banana-loc-div">
                        <div class="monkey-banana-loc-title">Find your JSON resourse at:</div>
                        <div class="monkey-banana-loc"></div>

                    </div>
                    <div class="another-banana">
                        <input id="btnAnotherBanana" class="btn btn-primary" type="button" value="Put another banana" />
                    </div>
                </div>
                <div class="editor-container">
                    <div id="jsoneditor" style="height: 700px">
                    </div>
                    <div style="padding-top: 10px; text-align: center">
                        <input id="btnBananaSubmit" class="btn btn-primary" type="button" value="Submit" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="Script/jquery-1.11.3.min.js"></script>
    <script src="Script/jsoneditor.js"></script>
    <script src="Script/monkey-api.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var thisObj = new MonkeyApi();

            thisObj.init();

        });
    </script>
</body>
</html>
