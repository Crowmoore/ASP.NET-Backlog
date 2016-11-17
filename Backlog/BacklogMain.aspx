<%@ Page Title="" Language="C#" MasterPageFile="~/Backlog.Master" AutoEventWireup="true" CodeBehind="BacklogMain.aspx.cs" Inherits="Backlog.BacklogMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="signed-in-div">
        <asp:Label ID="lblUser" runat="server"></asp:Label>
        <a href="Logout.aspx">Sign out</a>
    </div>
    <div class="main-container">
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
                                <asp:Label runat="server" Text='<%# Eval("name") %>'/>
                                <i class="material-icons right">more_vert</i>
                            </span>
                        </div>
                        <div class="card-reveal teal">
                                    <div class="game-card-contents">
                                        <span class="card-title white-text">
                                        <asp:TextBox runat="server" Text='<%# Eval("name") %>' Font-Size="Large"/>
                                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" OnClick="btnEdit_Click" />
                                        <asp:LinkButton runat="server" ID="btnDelete" GameID='<%# Eval("idgame") %>' GameTitle='<%# Eval("name") %>' Text="Delete" OnClick="btnDelete_Click" />
                                        <i class="material-icons right">close</i>
                                        </span>
                                    </div>
                            
                        </div>
                    </div>
                    </li>
            </ItemTemplate>
        </asp:ListView>   
        </ul> 
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
