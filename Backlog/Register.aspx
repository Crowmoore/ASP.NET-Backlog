<%@ Page Title="" Language="C#" MasterPageFile="~/Backlog.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Backlog.Register" %>
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
                    <asp:Label Text="E-mail" runat="server"></asp:Label>
                    <asp:TextBox ID="tbEmail" TextMode="Email" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label Text="Password" runat="server"></asp:Label> 
                    <asp:TextBox ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox>
                </div>
            <div class="card-action">
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
