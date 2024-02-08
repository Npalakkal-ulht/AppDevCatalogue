<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BaseTemplateApp._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="p-3">
        Base page - you can delete me but remember to point your web config forms tag to the new default page
        <br />
        change the theme by searching theme="Office365" in the webconfig
    </div>

</asp:Content>
