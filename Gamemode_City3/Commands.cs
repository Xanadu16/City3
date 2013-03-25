//Hastily did these at 12:30am while partially dehydrated. Don't bother me if something's incorrect. -Evar678

serverCmdPay(%client,%target,%amount)
{
	%target = findclientbyname(%target);

	if(!%client.player)
		return;
	if(!%target.player)
		return;
	if(%client.C3Wallet.money < %amount)
	{
		messageClient(%client, '', "\c2 You don't have enough money to pay that!");
		return;
	}
	%client.C3Wallet.trade(%client,%target,"money","give",%amount);
	%target.C3Wallet.trade(%target,%client,"money","recieve",%amount);

}

serverCmdGui(%client)
{
	if(%client.C3HasClient)
	{
		if(%client.isAdmin)
			commandToClient('C3_OpenGui',1); //Open Gui with admin perms
		else
			commandToClient('C3_OpenGui');
		return;
	}
	messageClient(%client, '', "\c2 You don't have the City3 Client! Please download it: (link here)");
}

serverCmdSetAlias(%client,%arg0,%arg1,%arg2)
{
	if(!arg2 $= "")
	{
		messageClient(%client, '', "\c2 Please keep your alias less than two names. (First and last)");
		return;
	}
	%client.C3Alias_First = %arg0;
	%client.C3Alias_Last = %arg1;
}