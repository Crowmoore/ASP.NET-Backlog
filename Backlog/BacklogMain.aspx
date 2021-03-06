﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Backlog.Master" AutoEventWireup="True" CodeBehind="BacklogMain.aspx.cs" Inherits="Backlog.BacklogMain" %>
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
        <asp:ListView ID="lvGames" runat="server" OnPagePropertiesChanging="lvGames_PagePropertiesChanging" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">
            
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvGames" PageSize="5">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
        </LayoutTemplate>
        <GroupTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
        </GroupTemplate>
        
            <ItemTemplate>
                    <li>
                    <div id="game-card-div" class="card teal z-depth-3">

                        <div class="card-content">
                            <span class="card-title activator white-text">
                                <i class="material-icons right">more_vert</i>
                                <asp:Label runat="server" Text='<%# Eval("name") %>' Font-Size="XX-Large"/>
                                <br />
                                <asp:Label CssClass="game-info" runat="server" Text='<%# Eval("status") %>' />
                                <asp:Label CssClass="game-info" runat="server" Text='<%# Eval("genre") %>' />
                                <asp:Label CssClass="game-info" runat="server" Text='<%# string.Concat("Achievements ", Eval("achievements")) %>' />
                                <br />
                                <asp:Label CssClass="game-info" runat="server" Text='<%# Eval("comment") %>' Font-Size="Smaller"/>
                            </span>
                        </div>

                        <div class="card-reveal teal">
                            <div class="game-card-contents">
                                <span class="card-title white-text">
                                <i class="material-icons right">close</i>
                                <asp:Label runat="server" Text='<%# Eval("name") %>' Font-Size="XX-Large"/>
                                <br />
                                <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" GameID='<%# Eval("idgame") %>' GameTitle='<%# Eval("name") %>' GameGenre='<%# Eval("genre") %>' GameStatus='<%# Eval("status") %>' GameAchievements='<%# Eval("achievements") %>' GameComment='<%# Eval("comment") %>' OnClick="btnEdit_Click" />
                                <asp:LinkButton runat="server" ID="btnDelete" GameID='<%# Eval("idgame") %>' GameTitle='<%# Eval("name") %>' Text="Delete" OnClientClick="return confirm('Are you sure you want to permanently remove this entry?');" OnClick="btnDelete_Click" />
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
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbAchievementsGained" runat="server" ErrorMessage="Only numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                </div>
                <div class="input-field achievements">
                    <asp:TextBox ID="tbAchievementsTotal" runat="server"></asp:TextBox>
                    <label for="tbAchievementsTotal">Achievements total</label>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbAchievementsTotal" runat="server" ErrorMessage="Only numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
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
