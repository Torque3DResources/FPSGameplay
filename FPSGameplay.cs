
// The general flow of a gane - server's creation, loading and hosting clients, and then destruction is as follows:

// First, a client will always create a server in the event that they want to host a single player
// game. Torque3D treats even single player connections as a soft multiplayer game, with some stuff
// in the networking short-circuited to sidestep around lag and packet transmission times.

// initServer() is called, loading the default server scripts.
// After that, if this is a dedicated server session, initDedicated() is called, otherwise initClient is called
// to prep a playable client session.

// When a local game is started - a listen server - via calling StartGame() a server is created and then the client is
// connected to it via createAndConnectToLocalServer().

function FPSGameplay::onCreate( %this )
{
}

function FPSGameplay::onDestroy( %this )
{
}

function FPSGameplay::initServer(%this)
{
   //server scripts
   %this.queueExec("./scripts/server/aiPlayer.cs");
   %this.queueExec("./scripts/server/camera.cs");
   %this.queueExec("./scripts/server/chat.cs");
   %this.queueExec("./scripts/server/cheetah.cs");
   %this.queueExec("./scripts/server/commands.cs");
   %this.queueExec("./scripts/server/centerPrint.cs");
   %this.queueExec("./scripts/server/deathMatchGame.cs");
   %this.queueExec("./scripts/server/health.cs");
   %this.queueExec("./scripts/server/inventory.cs");
   %this.queueExec("./scripts/server/item.cs");
   %this.queueExec("./scripts/server/player.cs");
   %this.queueExec("./scripts/server/projectile.cs");
   %this.queueExec("./scripts/server/proximityMine.cs");
   %this.queueExec("./scripts/server/radiusDamage.cs");
   %this.queueExec("./scripts/server/shapeBase.cs");
   %this.queueExec("./scripts/server/spawn.cs");
   %this.queueExec("./scripts/server/teleporter.cs");
   %this.queueExec("./scripts/server/triggers.cs");
   %this.queueExec("./scripts/server/turret.cs");
   %this.queueExec("./scripts/server/vehicle.cs");
   %this.queueExec("./scripts/server/vehicleWheeled.cs");
   %this.queueExec("./scripts/server/VolumetricFog.cs");
   %this.queueExec("./scripts/server/weapon.cs");
   %this.queueExec("./scripts/server/physicsShape.cs");
}

function FPSGameplay::onCreateGameServer(%this)
{
   %this.registerDatablock("./datablocks/audioProfiles.cs");
   %this.registerDatablock("./datablocks/audioData.cs");
   %this.registerDatablock("./datablocks/sounds.cs");
   %this.registerDatablock("./datablocks/aiPlayer.cs");
   %this.registerDatablock("./datablocks/brushes.cs");
   %this.registerDatablock("./datablocks/environment.cs");
   %this.registerDatablock("./datablocks/health.cs");   
   %this.registerDatablock("./datablocks/lights.cs");
   
   %this.registerDatablock("./datablocks/managedDatablocks.cs");
   %this.registerDatablock("./datablocks/managedDecalData.cs");
   %this.registerDatablock("./datablocks/managedForestItemData.cs");
   %this.registerDatablock("./datablocks/managedItemData.cs");
   %this.registerDatablock("./datablocks/managedParticleData.cs");
   %this.registerDatablock("./datablocks/managedParticleEmitterData.cs");
   
   %this.registerDatablock("./datablocks/markers.cs");
   %this.registerDatablock("./datablocks/particles.cs");
   %this.registerDatablock("./datablocks/physics.cs");
   %this.registerDatablock("./datablocks/player.cs");
   %this.registerDatablock("./datablocks/ribbons.cs");
   %this.registerDatablock("./datablocks/rigidShape.cs");
   %this.registerDatablock("./datablocks/teleporter.cs");
   %this.registerDatablock("./datablocks/triggers.cs");
   %this.registerDatablock("./datablocks/weapon.cs");
   
   %this.registerDatablock("./datablocks/vehicles/cheetahCar.cs");
   
   %this.registerDatablock("./datablocks/weapons/grenadefx.cs");
   %this.registerDatablock("./datablocks/weapons/Lurker.cs");
   %this.registerDatablock("./datablocks/weapons/ProxMine.cs");
   %this.registerDatablock("./datablocks/weapons/Ryder.cs");
   %this.registerDatablock("./datablocks/weapons/Turret.cs");
}

function FPSGameplay::onDestroyGameServer(%this)
{
}

function FPSGameplay::initClient(%this)
{
   %this.queueExec("./scripts/client/gameProfiles.cs");
      
   %this.queueExec("./scripts/client/inputCommands.cs");
   
   //guis
   %this.queueExec("./guis/chatHud.gui");
   %this.queueExec("./guis/playerList.gui");
   %this.queueExec("./guis/playGui.gui");
   %this.queueExec("./guis/hudlessGui.gui");
   
   %this.queueExec("./scripts/client/playGui.cs");
   %this.queueExec("./scripts/client/hudlessGui.cs");
   
   %this.queueExec("./scripts/client/message.cs");
   %this.queueExec("./scripts/client/chatHud.cs");
   %this.queueExec("./scripts/client/clientCommands.cs");
   %this.queueExec("./scripts/client/messageHud.cs");
   %this.queueExec("./scripts/client/playerList.cs");
   %this.queueExec("./scripts/client/centerPrint.cs");
   %this.queueExec("./scripts/client/recordings.cs");
   
   %this.queueExec("./scripts/client/screenshot.cs");
}

function FPSGameplay::onCreateClientConnection(%this)
{
   //client scripts
   $KeybindPath = "./scripts/client/default.keybinds.cs";
   exec($KeybindPath);
   
   %prefPath = getPrefpath();
   if(isFile(%prefPath @ "/keybinds.cs"))
      exec(%prefPath @ "/keybinds.cs");
}

function FPSGameplay::onDestroyClientConnection(%this)
{
}