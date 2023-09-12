<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApiClient.aspx.cs" Inherits="ExploreCalifornia.API.ApiClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Explore California Tours Client</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tours">
    
    </div>
    </form>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script>
        $(function () {
             //        path to api. when done (entire respons that we get back)
            $.getJSON('/api/tour').done(function (data) {
             
                $('#tours').append('<h2>It\'s just a quick demo</h2>');
                //itterate through the collection of data 
                // each(collection, function(index , element))
                $.each(data, function (index, tour) {
                   // to itterate all properties of a tour
                    for (prop in tour) {
                        $('#tours').append(prop + ':' + tour[prop] + '<br/>');
                    }
                    $('#tours').append('<br/>');
                });
            });
        });
    </script>
</body>
</html>
