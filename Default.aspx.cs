using System;
using System.Configuration;


public partial class _Default : System.Web.UI.Page 
{

    protected string Description;
    private LogMeBot.LogMeBotClient logMeBotClient;

    protected void Page_Load(object sender, EventArgs e)
    {
        logMeBotClient = new LogMeBot.LogMeBotClient(
            ConfigurationManager.AppSettings["LogMeBotClientId"],
            ConfigurationManager.AppSettings["LogMeBotClientSecret"],
            "http://localhost:63645");


        if (Request.Params["code"] != null)
        {
            if (string.IsNullOrEmpty(logMeBotClient.AccessToken))
            {
                string token = logMeBotClient.GetAccessToken(Request.Params["code"]);
            }
        }

        if (!string.IsNullOrEmpty(logMeBotClient.AccessToken))
        {
            var me = logMeBotClient.GetMe(logMeBotClient.AccessToken);

            Description += "LogMeBot authorized. <br>"
                + "Token: " + logMeBotClient.AccessToken + "<br>"
                + "Username: " + me.Username + "<br>"
                + "Email: " + me.Email + "<br>"
                + "ExpiresIn: " + me.ExpiresIn.ToString() + "<br>";
        }
        else
        {
            Description = "LogMeBot Not authorized";
        }

    }

    protected void CmdLogin_Click(object sender, EventArgs e)
    {
        //server side redir
        logMeBotClient.LogOn();

        //or client side redir to logMeBotClient.GetLogOnUri()
    }
}