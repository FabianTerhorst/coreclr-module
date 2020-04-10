# General Alt:V Voice

### Note : 
______________________________
- You can´t use the Alt:V Voice without editing your Server.cfg!

# Before we start...
___________________________________________

##### Before we start, we have to edit our Server.CFG File!
##### So we add : voice: {} to initialize our Voice.
##### this would look like that : 
```javascript
name: 'alt:V Server'
host: 0.0.0.0
port: 7788
players: 128
#password: ultra-password
announce: false
#token: YOUR_TOKEN
gamemode: Freeroam
website: example.com
language: en

// The Voice Initialization
voice: {} //  <---- We add this to our server.cfg File

description: 'alt:V Sample Server'
modules: [ node-module ]
resources: []
```

# Create a Voice Channel & Add Players to it [3D]
_____________________________________________________
```csharp
using AltV.Net;
using AltV.Net.Elements.Entities;

namespace AltV.Wiki
{
    /* We create our IScript class */
    public class AltV_Wiki : IScript
    {
        // We Create a Voicechat-Channel & set it to 3D by setting ,, spatial " to true.
        public static IVoiceChannel channel = Alt.CreateVoiceChannel(true, 20f);

        /* We declare & Create our Event Handler. */
        /* When a Player connects... it should put the Player into the VoiceChannel. */
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void PlayerConnect(IPlayer player, string reason)
        {
            /* If a Player Connects... he will be added to our Voice Channel. */
            channel?.AddPlayer(player);
        }

        /* We declare & Create our Event Handler. */
        /* When a Player disconnects... it should remove the Player from the VoiceChannel. */
        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnect(IPlayer client, string reason)
        {
            /* If a Player Disconnects... he will be removed from our Voice Channel. */
            channel?.RemovePlayer(client);
        }
    }
}
```
# How use the Voice now?
#### Open your Alt:V and go to the Header-Point called ,,Settings".
#### Here you can change your Voice-PushToTalk Buttons & more.
![GitHub Logo](https://github.com/FabianTerhorst/coreclr-module/tree/master/docs/images/Voice_1.PNG)
_________________________________________
#### Now you can Join a Server which Supports Voice & Play.
#### If you press your Setted Hotkey, your local player will move his mouth if Voice Activition was Successful.
![GitHub Logo](https://github.com/FabianTerhorst/coreclr-module/tree/master/docs/images/Voice_2.PNG)
