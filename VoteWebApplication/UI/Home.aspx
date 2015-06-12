<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="VoteWebApplication.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Voting System </title>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="nav nav-tabs center-block">
                            <ul class="nav nav-pills">
                                <li role="presentation" class="active"><a href="Home.aspx">Voter Entry</a></li>
                                <li role="presentation" class="active"><a href="CandidateEntry.aspx">Candidate Entry</a></li>
                                <li role="presentation" class="active"><a href="CastVote.aspx">Cast Vote</a></li>
                                <li role="presentation" class="active"><a href="ViewResult.aspx">View Result</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-primary center-block" style="width: 500px; margin-top: 30px;">
                            <div class="panel-heading">Voter Entry </div>
                            <div class="panel-body">
                                <table class="table">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Voter Name"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="voterNameTextBox" runat="server" Width="236px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Voter Id"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="voterIdTextBox" runat="server" Width="236px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="saveButton" runat="server" Text="Save" Height="43px" Width="81px" OnClick="saveButton_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <span id="alertMessage" runat="server"></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
