<%@ Page Title="" Language="C#" MasterPageFile="~/Backlog.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Backlog.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
        <div class="signed-in-div">
            <asp:Label ID="lblUser" runat="server"></asp:Label>
            <a href="Logout.aspx">Sign out</a>
        </div>
        
        <div class="editDiv">
            <asp:Label ID="lblEdit" runat="server" Font-Size="XX-Large"></asp:Label>
            <br />
            <br />
            <div class="error-div">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>
            <asp:Label runat="server" Font-Size="Medium">Title</asp:Label>
            <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
            <asp:Label runat="server" Font-Size="Medium">Genre</asp:Label>
            <asp:DropDownList ID="ddlGenres" runat="server"></asp:DropDownList>
            <asp:Label runat="server" Font-Size="Medium">Status</asp:Label>
            <asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList>
            
            <asp:Label runat="server" Font-Size="Medium">Achievements</asp:Label>
            <br />
            <asp:Label runat="server" Font-Size="Small">Gained</asp:Label>
            <asp:TextBox ID="tbAchievementsGained" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbAchievementsGained" runat="server" ErrorMessage="Only numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <br />
            <asp:Label runat="server" Font-Size="Small">Total</asp:Label>
            <asp:TextBox ID="tbAchievementsTotal" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbAchievementsTotal" runat="server" ErrorMessage="Only numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <br />

            <asp:Label runat="server" Font-Size="Medium">Comment</asp:Label>
            <asp:TextBox ID="tbComment" runat="server" MaxLength="200"></asp:TextBox>
            
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
        </div>
        
    </div>
</asp:Content>
