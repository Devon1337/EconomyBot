using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Threading;

namespace EconomyBot
{
    class MyBot
    {
        Dictionary<String, int> userEcon = new Dictionary<String, int>();
        
        /*
            File Writer
            Exe/Jar Start
            File Creation/Appendations
        */
        
        // Adding User Information Gathering
        // Creates an Dictionary or HashMap Of Information going about either their name or what they like to do
        // Laters gather information to check up users choice and things/games in play      
        
        /*
        Have Secondary Bot or Script Run without use of ! or @ as a logger
        ** Identifing User **
        1 = ID
        2 = Identified Name
        
        
        Dictionary<String, String> AssignedNames = new Dictionary<String, String>();
        Dictionary<String, String> UsersToNames = new Dictionary<String, String>();
        .createCommand("Hello")
        .Parameter(OPTIONAL, Name)
        .Do(async (e) => {
        AssignedNames.put(e.User.Name, Name)
        .createSubCommand("What") 
        .Do(async (e) => { 
         UsersToNames.put(e.User.Name, Name)
         });
        });      
        Overview Idea:
        
        Gunther#4534: Hey devon
        Devon1337#2016: What?
        
       Devon1337=Devon;
       
       
        
        
        */

        public Boolean Taken = false;

        String Args;
        Random random = new Random();
        int Amount;
        int Amount2;

        DiscordClient discord;
        public MyBot()
        {
            userEcon.Add("server", 1000000);
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

                    if (Int32.Parse(e.GetArg("Amount")) < userEcon[e.User.Name])
                    {
                        Amount = userEcon[e.User.Name.ToLower()] -= Int32.Parse(e.GetArg("Amount"));
                        userEcon.Remove(e.User.Name.ToLower());
                        userEcon.Add(e.User.Name.ToLower(), Amount);
                        await e.Channel.SendMessage("User " + e.User.Name + " Has bet " + e.GetArg("Amount") + " x on the number " + e.GetArg("onWho"));
                        int randomNumber = random.Next(1, 7);



                        if (Int32.Parse(e.GetArg("onWho")) == randomNumber)
                        {
                            await e.Channel.SendMessage(e.User.Name + " has won " + (Int32.Parse(e.GetArg("Amount")) * 2));
                            Amount = userEcon[e.User.Name.ToLower()] += (Int32.Parse(e.GetArg("Amount")) * 2);
                            userEcon.Remove(e.User.Name.ToLower());
                            userEcon.Add(e.User.Name.ToLower(), Amount);
                        }
                        else
                        {
                            await e.Channel.SendMessage("The die has rolled a " + randomNumber + " " + e.User.Name + " Has Lost " + Int32.Parse(e.GetArg("Amount")));
                            Amount = userEcon[e.User.Name.ToLower()] -= Int32.Parse(e.GetArg("Amount"));
                            userEcon.Remove(e.User.Name.ToLower());
                            userEcon.Add(e.User.Name.ToLower(), Amount);
                        }

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

                   }
                   else
                   {
                       userEcon.Add(Args, 100);
                   }
                   if (!userEcon.ContainsKey(e.User.Name.ToLower()))
                   {
                       userEcon.Add(e.User.Name, 100);
                   }
                   if (userEcon[e.User.Name.ToLower()] > Int32.Parse(e.GetArg("Amount")))
                   {
                       Allowed = true;
                   }
                   else
                   {
                       Allowed = false;
                       await e.Channel.SendMessage("User: " + e.User.Name + " does not have enough x to pay " + e.GetArg("TargetUser") + " " + e.GetArg("Amount") + " Virginities");
                   }

                   while (Allowed == true)
                   {
                       Amount = userEcon[e.User.Name.ToLower()] -= Int32.Parse(e.GetArg("Amount"));
                       Amount2 = userEcon[Args.ToLower()] += Int32.Parse(e.GetArg("Amount"));
                       userEcon.Remove(Args.ToLower());
                       userEcon.Remove(e.User.Name.ToLower());
                       userEcon.Add(e.User.Name.ToLower(), Amount);
                       userEcon.Add(Args.ToLower(), Amount2);

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
                    

                });

            commands.CreateCommand("welfare")
               .Do(async (e) =>
               {
                   if (Taken == false)
                   {

                       if (!(userEcon.ContainsKey(e.User.Name.ToLower())))
                       {
                           userEcon.Add(e.User.Name.ToLower(), 100);
                       }

                       Amount = userEcon[e.User.Name.ToLower()] += 1500;
                       await e.Channel.SendMessage(e.User.Name + " has just got da mfin welfare check of 1500 x");

                       Taken = true;

                   }
                   else if (Taken == true)
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
                    if (!(userEcon.ContainsKey(e.User.Name.ToLower())))
                    {
                        userEcon.Add(e.User.Name.ToLower(), 100);
                    }
                    if (!(userEcon.ContainsKey(e.GetArg("User").ToLower())))
                    {
                        userEcon.Add(e.GetArg("User").ToLower(), 100);
                    }

                    if (e.GetArg("User").Equals(" ") || e.GetArg("User").Equals(""))
                    {
                        await e.Channel.SendMessage(e.User.Name + " You have " + userEcon[e.User.Name.ToLower()] + " x");
                    }
                    else
                    {
                        await e.Channel.SendMessage(e.GetArg("User") + " Has " + userEcon[e.GetArg("User").ToLower()] + " x");
                    }

                });



            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("Hidden Due to Recent Events", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
