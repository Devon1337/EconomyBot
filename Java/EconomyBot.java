//Inputs from Discord -> Java 
//This is just crude code uncompiled

package com.devon.EcoBot;

// Add imports here

public class EcoBot extends JavaPlugin 

  Server server = Server.Plugin();
  Path path = configuration.get("FilePath");

  @Override
  public void onEnable() {
   File LOG = new File(path);
   String SERVIP = Server.ipAddress();
   String SERVPORT = Server.port();
   String SERVCOUNT = Server.user();
  }
  
  @Override
  public void onDisable() {
    
  }



}
