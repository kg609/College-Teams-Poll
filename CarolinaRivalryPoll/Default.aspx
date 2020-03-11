<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarolinaRivalryPoll._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="PollContainer" class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <h1 id="H1" class="text-center">Which side of the blue are you on?</h1>
            
                <div id="divUNCContainer" class="col-md-6 col-sm-6 text-center">
                    <div class="divContentContainer">
                        <h2>UNC Tarheels</h2>
                        <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/North_Carolina_Tar_Heels_logo.svg/300px-North_Carolina_Tar_Heels_logo.svg.png" alt="UNC Logo" />
                        <br />
                        <label class="checkboxContainer" >
                            <input id="radioboxUNC" type="radio" name="collegeTeam" runat="server" required  />
                            <asp:RadioButton ID="checkboxUNC" class="checkmark" runat="server" ClientIDMode="Static"   /> 
                        </label>
                        <asp:Label ID="lblUNC" runat="server" Text="" ClientIDMode="Static" />
                    </div>
                </div>
                <div id="divDukeContainer" class="col-md-6 col-sm-6 text-center">
                    <div class="divContentContainer">
                        <h2>Duke Bluedevils</h2>
                        <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/0/04/Duke_Blue_Devils_logo.svg/300px-Duke_Blue_Devils_logo.svg.png" alt="Duke Logo" />
                        <br />
                        <label class="checkboxContainer" >
                            <input id="radioboxDUKE" type="radio" name="collegeTeam" runat="server" />
                            <asp:RadioButton ID="checkboxDUKE" class="checkmark"  runat="server" ClientIDMode="Static" />  
                        </label> 
                        <asp:Label ID="lblDUKE" runat="server" Text="" ClientIDMode="Static" />
                    </div>
                </div>

                <div class="btnSubmitContainer">
                    <asp:Button type="submit" ID="btnSubmit" runat="server" Text="SUBMIT" OnClick="btnSubmit_Click" ClientIDMode="Static" ></asp:Button>                  
                </div>

                <div id="divErrorMessage" class="alert-danger" role="alert" style="display: none;">
                    <p>Please choose one of the teams above</p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

