<%@ Page Title="" Language="C#" MasterPageFile="~/Backlog.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Backlog.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-container">
        <div class="card teal z-depth-3 darken-2">
            <div class="card-content white-text">
                <div class="input-field">
                    <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                    <label for="tbUsername">Username</label>
                </div>
                <div class="input-field">
                    <asp:TextBox ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox>
                    <label for="tbPassword">Password</label>
                </div>
            <div class="card-action">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" />
            </div>
        </div>
    </div>
    <div class="error-div">
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </div>
</asp:Content>
