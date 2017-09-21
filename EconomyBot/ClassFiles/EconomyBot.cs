using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Threading;

namespace EconomyBot
{
    class MyBot
    {
         // Program Defaults
        string DefaultRoot = "C:\Users\Public\Documents\EconBot";
        
        // Setting up User Configuration
        Dictionary<String, int> userEcon = new Dictionary<String, int>();
        Dictionary<String, int> UserPerms = new Dictionary<String, int>();
        ArrayList UserList = new ArrayList();
        ArrayList BannedList = new ArrayList();
        ArrayList MuteList = new ArrayList();
        string UserConfigurationPath = @DefaultRoot + "\UserConfiguration.txt";
        string[] UserEconList = new string[250];
        int IndexLoc = 0;
    
        // Bot Configurations
        string BotConfigurationPath = @DefaultRoot + "\BotConfiguration.txt";
        String PrivateKey;
        int Status;
        int Error;
        
        // Server Configuration
        string ServerConfigurationPath = @DefaultRoot + "\ServerConfiguration.txt";
        String[] PermissionNode = new String[500];
        String[] PermissionRoots = new String[500];
        int PermRootIndexLoc = 0;
        int PermNodeIndexLoc = 0;
        /*
        * (BanUser)<---(EconBot)--->(SetPerms)
        */
        Dictionary<String, String> PermissionConnect = new Dictionary<String, String>(); // (Root, Node)
        /*
        * Permission System Examples
        * Root takes in SetPerm, SetRank, BanUser
        * UserPerms(Root, SetPerms)
        * UserPerms(Root, SetRank)
        * UserPerms(Root, BanUser)
        */
        Dictionary<String, String> UserPerms = new Dictionary<String, String>(); // (User, Node)
        Dictionary<String, String> RankPerms = new Dictionary<String, String>(); // (Rank, Node)

        // Initialization
        DiscordClient discord;
        var commands = discord.GetService<CommandService>();
        
        public MyBot()
        {
            
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = false;

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
            commands.CreateCommand("SaveConfig")
                .Do(async (e) => 
                    {
                        
                        
                    });
            commands.CreateCommand("bank")
                .Parameter("User", ParameterType.Optional)
                .Do(async (e) =>
                {
                    if (!(userEcon.ContainsKey(e.User.Name.ToLower())))
                    {
                        UserEconList[IndexLoc] = e.User.Name.ToLower() + "[" + 100 + "]";
                        userEcon.Add(e.User.Name.ToLower(), 100);
                    }
                    if (!(userEcon.ContainsKey(e.GetArg("User").ToLower())))
                    {
                        UserEconList[IndexLoc] = e.GetArg("User") + "[" + 100 + "]";
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
                await discord.Connect(PrivateKey, TokenType.Bot);
            });
        }

        private void ConfigurationSetup() {   
            using (FileStream fs = File.Create(UserConfigurationPath)) {
                  System.IO.File.WriteAllLines(UserConfigurationPath, UserEconList);
            }
        }
        public void ConfigurationWrite() {
        }
        private void ConfigurationLoad() {
        }
        public void PermissionAdd(String name; String root, String node) {
            if(PermissionConnect.TryGetValue(name, UserSetPermLevel)) {
                UserPermission
            }
        }
         public void HashSet() {
        
            PermissionsRoots[PermRootIndexLoc] = EconBot;
            PermRootIndexLoc++;
            PermissionsNode[PermNodeIndexLoc] = ConfigSave;
            PermNodeIndexLoc++;
            PermissionsNode[PermNodeIndexLoc] = ConfigLoad;
            PermNodeIndexLoc++;
            PermissionsNode[PermNodeIndexLoc] = UserSetPermLevel;
            PermNodeIndexLoc++;
            
            PermissionConnect.add(EconBot, ConfigSave);
            PermissionConnect.add(EconBot, ConfigLoad);
            PermissionConnect.add(EconBot, UserSetPermLevel);
            
        }
        
        public void Async<int> OutBoxLogging() {
            Logging log = new Logging();
        }
        
        
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
}
