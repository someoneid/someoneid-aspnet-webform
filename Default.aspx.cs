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
            ConfigurationManager.AppSettings["LogMeBotCallbackuri"]);


        try
        {
            if (Request.Params["code"] != null)
            {
                if (string.IsNullOrEmpty(logMeBotClient.AccessToken))
                {
                    string token = logMeBotClient.GetAccessToken(
                        Request.Params["code"], Request.Params["state"]);
                }
            }

            if (!string.IsNullOrEmpty(logMeBotClient.AccessToken))
            {
                var me = logMeBotClient.GetMe(logMeBotClient.AccessToken);

                Description += "LogMeBot authorized. <br>"
                    + "Token (always keep safe and secret): " + logMeBotClient.AccessToken + "<br>"
                    + "UserId: " + me.UserId + "<br>"
                    + "Email: " + me.Email + "<br>"
                    + "Nickname: " + me.Nickname + "<br>"
                    + "ExpiresIn: " + me.ExpiresIn.ToString() + "<br>";

                //************TODO********
                //your login logic here
            }
            else
            {
                Description = "LogMeBot Not authorized";
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
        logMeBotClient.LogOn();

        //or client side redir to logMeBotClient.GetLogOnUri()
    }
}