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
        string DefaultRoot = "C:/Users/Public/Documents/EconBot";
			string Author = "Devon";
			string Version = "Nothing Here";
        
        // Setting up User Configuration
        Dictionary<String, int> userEcon = new Dictionary<String, int>();
        Dictionary<String, String> UserPerms = new Dictionary<String, String>();
        ArrayList UserList = new ArrayList();
        ArrayList BannedList = new ArrayList();
        ArrayList MuteList = new ArrayList();
        string UserConfigurationPath = @DefaultRoot + "/UserConfiguration.txt";
        string[] UserEconList = new string[250];
        int IndexLoc = 0;
	string EconomyName;
    
        // Bot Configurations
        string BotConfigurationPath = @DefaultRoot + "/BotConfiguration.txt";
        String PrivateKey;
        int Status;
        int Error;
        
        // Server Configuration
        string ServerConfigurationPath = @DefaultRoot + "/ServerConfiguration.txt";
        String[] PermissionNode = new String[500];
        String[] PermissionRoots = new String[500];
        int PermRootIndexLoc = 0;
        int PermNodeIndexLoc = 0;
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
            // Setting Default Information for API
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

           
				// Base Commands
            commands.CreateCommand("pay")
               .Parameter("TargetUser", ParameterType.Required)
               .Parameter("Amount", ParameterType.Required)
               .Do(async (e) =>
               {
                   Args = e.GetArg("TargetUser");
		       
		       // Checking if such bank account is existant or if said user has permissions
                   if (userEcon.ContainsKey(Args) && !(BannedList.contains(Args)) && !(BannedList.contains(e.User.Name)) && RankPerms.contains(Args, pay) || UserPerms.contains(Args, pay) && RankPerms.contains(e.User.Name, pay,) || UserPerms.contains(e.User.Name, pay))
                   {
                       Amount = userEcon[e.User.Name.ToLower()] -= Int32.Parse(e.GetArg("Amount"));
                       Amount2 = userEcon[Args.ToLower()] += Int32.Parse(e.GetArg("Amount"));
                       userEcon.Remove(Args.ToLower());
                       userEcon.Remove(e.User.Name.ToLower());
                       userEcon.Add(e.User.Name.ToLower(), Amount);
                       userEcon.Add(Args.ToLower(), Amount2);

                       await e.Channel.SendMessage("[Test 7]" + e.User.Name + " has paid " + Args + " " + e.GetArg("Amount") + " Virginities");
                       //Modifier(e.User.Name, e.GetArg("TargetUser"), Int32.Parse(e.GetArg("Amount")));
                       Allowed = false;
                   }   else if (userEcon.ContainsKey(Args)) {
			await e.Channel.SendMessage("Fixed!");		   
		   } else if (BannedList.contains(Args)) {
			await e.Channel.SendMessage(Args + " Is currently banned!");
		   } else if (Bannlist.contains(e.User.Name)) {
			await e.Channel.SendMessage(e.User.Name + " Is currently banned!")   
		   } else {
			await e.Channel.SendMessage("Permission Error, Check with Administrator if you think this is incorrect!")   
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

			// Configuration Setup,Loading,Writing
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
			// Ini all predeclared varibles
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
        // User IP Logging
        public void Async<int> OutBoxLogging() {
            Logging log = new Logging();
        }
			
			// ChatLoading
			public void Async<int> MultiLoading() {

			}
        
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
}
