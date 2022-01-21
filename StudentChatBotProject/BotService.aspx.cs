using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Syn.Bot.Channels.Testing;
using Syn.Bot.Channels.Widget;
using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
using Syn.Bot.Oscova.Messages;



namespace StudentChatBotProject
{
    public partial class BotService : System.Web.UI.Page
    {


        private static WidgetChannel WidgetChannel { get; }
        private static OscovaBot Bot { get; }

        


        static BotService()
        {
            Bot = new OscovaBot();
           
            WidgetChannel = new WidgetChannel(Bot);

            Bot.Dialogs.Add(new ProductDialog());

            Bot.Trainer.StartTraining();

            var websiteUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            WidgetChannel.ServiceUrl = websiteUrl + "/BotService.aspx";
            WidgetChannel.ResourceUrl = websiteUrl + "/BotResources";

            WidgetChannel.WidgetTitle = "Our Smart Bot!";
            WidgetChannel.LaunchButtonText = "Talk to Me";
            WidgetChannel.InputPlaceHolder = "Ask your query here...";
           

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            WidgetChannel.Process(Request, Response);

        }

    }

    public class ProductDialog : Dialog
        {
       

           
            [Expression("who are you"), Expression("hi")]
            public void SmallTalk_Name(Context context, Result result)
            {
                //Do Something and then respond...
                result.SendResponse("I am a bot");
            }

            [Expression("Hello bot")]
            public void TestIntent(Context context, Result result)
            {
                result.SendResponse("Hello Developer!");
            }

            [Expression("are you done")]
            public void TestIntent1(Context context, Result result)
            {
                result.SendResponse("yeah! we did it");
            }

            [Expression("When is the 1st Sem Exam?")]
            public void TestIntent2(Context context, Result result)
            {
               result.SendResponse("20-jan-2022");
            }

            [Expression("How much is the Exam Fees?")]
            public void TestIntent3(Context context, Result result)
            {
              result.SendResponse("Rs.1500");
            }

            [Expression("when is the last date to pay the Exam Fees?")]
            public void TestIntent4(Context context, Result result)
            {
             result.SendResponse("05-jan-2022");
            }

            [Expression("What is the Time Table for 3rd sem?")]
            public void TestIntent5(Context context, Result result)
            {
             result.SendResponse("21-jan-2022, 24-jan-2022,26 - jan - 2022,28 - jan - 2022,31 - jan - 2022.");
                               
            }

            [Expression("What are the college holidays for the Jan Month 2022?")]
            public void TestIntent6(Context context, Result result)
            {
            result.SendResponse("01-jan-2022,14 - jan - 2022,26 - jan - 2022");

            }


            [Expression("When is the College Re-Opening?")]
            public void TestIntent7(Context context, Result result)
             {
             result.SendResponse("02-feb-2022");
            }


           [Expression("Where is the College Library?")]
           public void TestIntent8(Context context, Result result)
           {
            result.SendResponse("In The Ground Floor.");
           }


           [Expression("When is the U.G admission starts?")]
           public void TestIntent9(Context context, Result result)
           {
             result.SendResponse("04-July-2022");
           }


           [Expression("How many subjects are present in the 5th Sem?")]
          public void TestIntent10(Context context, Result result)
          {
             result.SendResponse("5 Subjects");
          }


          [Expression("In which month College Placements Starts?")]
          public void TestIntent11(Context context, Result result)
          {
            result.SendResponse("During October Month.");
          }

         [Expression("Hi ChatBot")]
         public void TestIntent12(Context context, Result result)
         {
            result.SendResponse("Hi Student");
         }

       

    }
}



  