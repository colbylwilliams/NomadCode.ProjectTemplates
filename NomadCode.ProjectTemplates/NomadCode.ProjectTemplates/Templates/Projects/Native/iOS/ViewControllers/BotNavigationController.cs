using System;
using System.Threading.Tasks;

using Foundation;
using UIKit;

using NomadCode.BotFramework;

namespace ${ProjectName}
{
	[Register ("BotNavigationController")]
	public class BotNavigationController : UINavigationController
	{
		public BotNavigationController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            try
            {
                if (!string.IsNullOrEmpty(Keys.Bot.DirectLineSecret))
                {
                    BotClient.Shared.CurrentUserId = "userId";
                    BotClient.Shared.CurrentUserName = "User";
                    BotClient.Shared.CurrentUserEmail = "hello@xamarin.com";
                    //BotClient.Shared.SetAvatarUrl (userId, avatarUrl);

                    if (!BotClient.Shared.Initialized)
                    {
                        var client = new DirectLineClient(Keys.Bot.DirectLineSecret);

                        Task.Run(async () =>
                        {
                            try
                            {
                                await BotClient.Shared.ConnectSocketAsync(conversationId => client.Tokens.GenerateTokenForNewConversationAsync());
                            }
                            catch (Exception ex)
                            {
                                Log.Error(ex.Message);
                            }
                        });
                    }
                }
                else
                {
                    Log.Debug("To use the Bot, add your bot's direct line secret to Keys.Bot.DirectLineSecret");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
	}
}