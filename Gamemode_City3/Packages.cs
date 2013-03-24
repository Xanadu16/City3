package C3Pack
{
	function GameConnection::autoAdminCheck(%client)
	{
		%v = Parent::autoAdminCheck(%client);
		
		schedule(500,0,"commandToClient",%client,'C3_Handshake',$C3::Server::Version);
		
		return %v;
	}

	function Armor::onCollision(%this,%obj,%col,%thing,%other) //Cash pickup
	{
		if(%col.getDatablock().getName() $= "droppedcashitem")
		{
			if(isObject(%obj.client))
			{
				if(isObject(%col))
				{
					%obj.client.c3wallet.add("cash",%col.value);
					messageClient(%obj.client, '', "\c6You have picked up" SPC CashStr(%col.value,"") @ "\c6.");
					%col.canPickup = false;
					%col.delete();
					
					return;
				} else {
					%col.delete();
					MissionCleanup.remove(%col);
				}
			}
		} else {
			Parent::onCollision(%this,%obj,%col,%thing,%other);
		}
	}
};
activatepackage(C3Pack);

function C3_returnHandshake(%client, %version)
{
	if(%version == $ES::Server::Version)
		%client.c3HasClient = 1;
}