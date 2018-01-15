using SomeoneId.Net;
using System;
using System.Configuration;


public partial class _Default : System.Web.UI.Page 
{

    protected string Description;
    protected bool Logged = false;
    private SomeoneIdClient client;

    protected void Page_Load(object sender, EventArgs e)
    {
        client = new SomeoneIdClient();
        //client.BasePath = "http://localhost:3979/";

        //ConfigurationManager.AppSettings["SomeoneClientId"],
        //ConfigurationManager.AppSettings["SomeoneClientSecret"],
        //ConfigurationManager.AppSettings["SomeoneCallbackuri"]);


        try
        {
            if (Request.Params["code"] != null)
            {
                if (string.IsNullOrEmpty(client.AccessToken))
                {
                    string token = client.GetAccessToken(
                        Request.Params["code"], Request.Params["state"]);
                }
            }

            if (!string.IsNullOrEmpty(client.AccessToken))
            {
                var me = client.GetMe(client.AccessToken);

                Description += "Login authorized. <br>"
                    + "Token (always keep safe and secret): " + client.AccessToken + "<br>"
                    + "UserId: " + me.UserId + "<br>"
                    + "Email: " + me.Email + "<br>"
                    + "Nickname: " + me.Nickname + "<br>"
                    + "ExpiresIn: " + me.ExpiresIn.ToString() + "<br>";

                Logged = true;
                //************ TODO *************
                //*
                //* your custom login logic here
                //*
                //*******************************
            }
            else
            {
                Logged = false;
                Description = "Login NOT authorized";
            }
        }
        catch(Exception ex)
        {
            Description = ex.Message;
        }

    }

    protected void CmdLogin_Click(object sender, EventArgs e)
    {
        //server side redir
        client.LogOn();

        //or client side redir to client.GetLogOnUri()
    }
}