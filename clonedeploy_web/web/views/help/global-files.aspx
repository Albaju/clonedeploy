﻿<%@ Page Title="" Language="C#" MasterPageFile="~/views/help/content.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subcontent" Runat="Server">
     <script type="text/javascript">
         $(document).ready(function () {
             $('#global').addClass("nav-current");
             $('#global-files').addClass("nav-current-sub");
         });
        </script>
    <h1>Global->Files / Folders</h1>
   
</asp:Content>

