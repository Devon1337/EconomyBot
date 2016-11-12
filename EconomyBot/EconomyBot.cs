using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Threading;

namespace EconomyBot
{
    class MyBot
    {


        Dictionary<String, double> userEcon = new Dictionary<String, double>();

        public Boolean Taken = false;
       

       
        String Args;
        Random random = new Random();
        double Amount;
        double Amount2;

        DiscordClient discord;
        public MyBot()
        {
            
            userEcon.Add("Server", 1000000.0);
            userEcon.Add("server", 1000000.0);
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;

            });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("bet")
                .Parameter("Amount", ParameterType.Required)
                .Parameter("onWho", ParameterType.Required)
                .Do(async (e) =>
                {
                    
                        await e.Channel.SendMessage("User " + e.User.Name + " Has bet " + e.GetArg("Amount") + " Virginities on the number " + e.GetArg("onWho"));
                        int randomNumber = random.Next(0, 6);
                    
                        

                        if(Int32.Parse(e.GetArg("onWho")) == randomNumber)
                        {
                            await e.Channel.SendMessage(e.User.Name + " has won " + (Int32.Parse(e.GetArg("Amount"))*2));
                            Amount = userEcon[e.User.Name] += (Int32.Parse(e.GetArg("Amount")) * 2);
                            userEcon.Remove(e.User.Name);
                            userEcon.Add(e.User.Name, Amount);
                    } else
                    {
                        await e.Channel.SendMessage("The die has rolled a " + randomNumber + " " + e.User.Name + " Has Lost " + Int32.Parse(e.GetArg("Amount")));
                        Amount = userEcon[e.User.Name] -= Int32.Parse(e.GetArg("Amount"));
                        userEcon.Remove(e.User.Name);
                        userEcon.Add(e.User.Name, Amount);
                    }
                    

                });

          
            commands.CreateCommand("pay")
               .Parameter("TargetUser", ParameterType.Required)
               .Parameter("Amount", ParameterType.Required)
               .Do(async (e) =>
               {
                   Boolean Allowed = false;
                   Args = e.GetArg("TargetUser");

                   if (userEcon.ContainsKey(Args))
                   {

                   } else
                   {
                       userEcon.Add(Args, 100.0);
                   }
                   if(!userEcon.ContainsKey(e.User.Name))
                   {
                       userEcon.Add(e.User.Name, 100);
                   }
                   if(userEcon[e.User.Name] > Int32.Parse(e.GetArg("Amount")))
                   {
                       Allowed = true;
                   } else
                   {
                       Allowed = false;
                       await e.Channel.SendMessage("User: " + e.User.Name + " does not have enough virginities to pay " + e.GetArg("TargetUser") + " " + e.GetArg("Amount") + " Virginities");
                   }

                   while (Allowed == true) {
                       Amount = userEcon[e.User.Name] -= Int32.Parse(e.GetArg("Amount"));
                       Amount2 = userEcon[Args] += Int32.Parse(e.GetArg("Amount"));
                       userEcon.Remove(Args);
                       userEcon.Remove(e.User.Name);
                       userEcon.Add(e.User.Name, Amount);
                       userEcon.Add(Args, Amount2);

                       await e.Channel.SendMessage("[Test 7]" + e.User.Name + " has paid " + e.GetArg("TargetUser") + " " + e.GetArg("Amount") + " Virginities");
                       //Modifier(e.User.Name, e.GetArg("TargetUser"), Int32.Parse(e.GetArg("Amount")));
                       Allowed = false;
                   }
               });
            commands.CreateCommand("help")
                .Do(async (e) =>
                {

                    await e.Channel.SendMessage("======HelpMenu======");
                    await e.Channel.SendMessage("=!pay [name] {$$$$}         =");
                    await e.Channel.SendMessage("=!bank {name}                     =");
                    await e.Channel.SendMessage("=!eggplantme                        =");
                    await e.Channel.SendMessage("=!truth                                    =");

                });

            commands.CreateCommand("truth")
                .Do(async (e) => 
                 {
                    await e.Channel.SendMessage("Jack's a retard");

                 });

            commands.CreateCommand("welfare")
               .Do(async (e) =>
               {
                   if (Taken == false) {

                       if (!(userEcon.ContainsKey(e.User.Name)))
                       {
                           userEcon.Add(e.User.Name, 100.0);
                       }

                       Amount = userEcon[e.User.Name] += 1500;
                       await e.Channel.SendMessage(e.User.Name + " has just got da mfin welfare check of 1500 virginities");

                       Taken = true;
                       
                   } else if(Taken == true)
                   {
                       await e.Channel.SendMessage("The welfare check is not ready!");
                   }
               });

            commands.CreateCommand("ametlodegfjtekaem239sn3ndnk32")
                .Do(async (e) =>
                {
                    Taken = true;
                    await e.Channel.SendMessage("Welfare is now added");
                    

                });
         
            commands.CreateCommand("eggplantme")
                
                .Do(async (e) =>
                {
                   // for (int x = 0; x < Int32.Parse("Amount"); x++) {
                        await e.Channel.SendMessage(":eggplant:");
                    //}
                });
            commands.CreateCommand("bank")
                .Parameter("User", ParameterType.Optional)
                .Do(async (e) =>
                {
                    if (!(userEcon.ContainsKey(e.User.Name)))
                    { 
                        userEcon.Add(e.User.Name, 100.0);
                    }
                    if (!(userEcon.ContainsKey(e.GetArg("User")))) 
                    {
                        userEcon.Add(e.GetArg("User"), 100.0);
                    }

                    if (e.GetArg("User").Equals(" ") || e.GetArg("User").Equals("")) {
                        await e.Channel.SendMessage(e.User.Name + " You have " + userEcon[e.User.Name] + " Virginities");
                    } else
                    {
                        await e.Channel.SendMessage(e.GetArg("User") + " Has " + userEcon[e.GetArg("User")] + " Virginities");
                    }

                });

           

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjQ2MDczNjU2OTI3NTg0MjU3.CwVnow.JwhynKqFtte5sxfx2beuL4uod4k", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void Modifier(String InputName, String TargetUser, int money)
        {
            Amount = userEcon[TargetUser];
            Amount2 = userEcon[InputName];

            userEcon[TargetUser] = Amount2 + money;
            userEcon[InputName] = Amount2 - money;
        }
    }
}