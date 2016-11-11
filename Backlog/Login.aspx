<%@ Page Title="" Language="C#" MasterPageFile="~/Backlog.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Backlog.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-container">
        <div class="card teal z-depth-3">
            <div class="card-content white-text">
                <div>
                    <asp:Label Text="Username" runat="server"></asp:Label>
                    <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label Text="Password" runat="server"></asp:Label> 
                    <asp:TextBox ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox>
                </div>
            <div class="card-action">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" />
            </div>
        </div>
    </div>
</asp:Content>
