<%@ Page Title="" Language="C#" MasterPageFile="~/Cacti.Master" AutoEventWireup="true" CodeBehind="ImageChooser.aspx.cs" Inherits="CactiMaster.ImageChooser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHeaderPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form method="post" enctype="multipart/form-data">
        <div>
            <label for="image_uploads">Choose images to upload (PNG, JPG, JPEG)</label>
            <input
                type="file"
                id="image_uploads"
                name="image_uploads"
                accept="image/jpg, image/jpeg, image/png"
                multiple />
        </div>
        <div class="preview">
            <p>No files currently selected for upload</p>
        </div>
        <!-- not implemented at all -->
        <!--
        <div>
            <button>Upload to Server</button> 
        </div>
        -->
    </form>
    <!--
    <input type="file">
    -->
    <script src="Scripts/ImageChooser.js"></script>
</asp:Content>
