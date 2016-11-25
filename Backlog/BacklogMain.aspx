<%@ Page Title="" Language="C#" MasterPageFile="~/Backlog.Master" AutoEventWireup="true" CodeBehind="BacklogMain.aspx.cs" Inherits="Backlog.BacklogMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container">
    <div class="search-div input-field">
        <asp:Label runat="server" Text="Search by"></asp:Label>
        <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged">
            <asp:ListItem Text="Title" Value="Title"></asp:ListItem>
            <asp:ListItem Text="Genre" Value="Genre"></asp:ListItem>
            <asp:ListItem Text="Status" Value="Status"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
        <asp:Button ID="btnShowAll" runat="server" Text="Show all" OnClick="btnShowAll_Click"/>
    </div>
    <div class="main-card-container">
        <div class="error-div">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
        <ul>
        <asp:ListView ID="lvGames" runat="server">
            <ItemTemplate>
                    <li>
                    <div id="game-card-div" class="card teal z-depth-3">
                        <div class="card-content">
                            <span class="card-title activator white-text">
                                <i class="material-icons right">more_vert</i>
                                <asp:Label runat="server" Text='<%# Eval("name") %>' Font-Size="XX-Large"/>
                                <br />
                                <asp:Label runat="server" Text='<%# string.Concat("Status: ", Eval("status")) %>' />
                                <asp:Label runat="server" Text='<%# string.Concat("Genre: ", Eval("genre")) %>' />
                                <br />
                                <asp:Label runat="server" Text='<%# string.Concat("Achievements: ", Eval("achievements")) %>' />
                                <asp:Label runat="server" Text='<%# string.Concat("Comments: ", Eval("comment")) %>' />
                            </span>
                        </div>
                        <div class="card-reveal teal">
                            <div class="game-card-contents">
                                <span class="card-title white-text">
                                <i class="material-icons right">close</i>
                                <asp:TextBox ID="tbEditTitle" runat="server" Text='<%# Eval("name") %>'></asp:TextBox>
                                <br />
                                <asp:DropDownList ID="ddlEditStatus" runat="server"></asp:DropDownList>
                                <asp:DropDownList ID="ddlEditGenre" runat="server"></asp:DropDownList>
                                <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" GameID='<%# Eval("idgame") %>' GameTitle='<%# Eval("name") %>' GameGenre='<%# Eval("genre") %>' OnClick="btnEdit_Click" />
                                <asp:LinkButton runat="server" ID="btnDelete" GameID='<%# Eval("idgame") %>' GameTitle='<%# Eval("name") %>' Text="Delete" OnClick="btnDelete_Click" />
                                </span>
                            </div>                            
                        </div>
                    </div>
                    </li>
            </ItemTemplate>
        </asp:ListView>   
        </ul> 
    </div>
    <div class="signed-in-div">
        <asp:Label ID="lblUser" runat="server"></asp:Label>
        <a href="Logout.aspx">Sign out</a>
    </div>
    </div>
    <div>
        <a class="fixed btn-floating teal add-button tooltipped" data-position="left" data-tooltip="Add a new game" href="#addGame"><i class="material-icons">add</i></a>
        <div id="addGame" class="modal teal">
            <div class="modal-content">
                <h4>Add new game</h4>
                <div class="input-field">
                    <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
                    <label for="tbTitle">Title</label>
                </div>
                <div class="input-field">
                    <asp:DropDownList ID="ddlGenres" runat="server">
                    </asp:DropDownList>
                    <label>Genre</label>
                </div>
                <div class="input-field achievements">
                    <asp:TextBox ID="tbAchievementsGained" runat="server"></asp:TextBox>
                    <label for="tbAchievementsGained">Achievements gained</label>
                </div>
                <div class="input-field achievements">
                    <asp:TextBox ID="tbAchievementsTotal" runat="server"></asp:TextBox>
                    <label for="tbAchievementsTotal">Achievements total</label>
                </div>
                <div class="input-field">
                    <asp:DropDownList ID="ddlStatus" runat="server">
                    </asp:DropDownList>
                    <label>Status</label>
                </div>
                <div class="input-field">
                    <asp:TextBox ID="tbComment" runat="server" MaxLength="200"></asp:TextBox>
                    <label for="tbComment">Comment</label>
                </div>
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"/>
                
            </div>
            
        </div>
    </div>
    

</asp:Content>
