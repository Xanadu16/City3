if(!isObject(C3Wallet))
{
	new scriptObject(C3WalletSO) {};
}

function C3Wallet::add(%this,%obj,%arg)
{	
	switch(%obj)
	{
		case "money":
			%this.money += %arg;
		case "bankm":
			%this.bankm += %arg;
	}
	%this.cashUpdated = 1;
}

function C3Wallet::subtract(%this,%client,%obj,%arg)
{
	switch(%obj)
	{
		case "money":
			%this.money -= %arg;
		case "bankm":
			%this.bankm -= %arg;
	}
	%this.cashUpdated = 1;
}

function C3Wallet::trade(%this,%client,%target,%obj,%task,%arg)
{
	switch(%obj)
	{
		case "money":
			%type = 1;
		case "bankm":
			%type = 2;
	}

	switch(%task)
	{
		case "give":
			if(%type == 1)
			{
				%this.money -= %arg;
				messageClient(%client, '', "\c2You have paid $" @ %arg @ " to " @ %target @ ".");
			}
			if(%type == 2)
			{
				%this.bankm -= %arg;
				messageClient(%client, '', "\c2You have transfered $" @ %arg @ " to " @ %target @ ".");
			}
		case "recieve":
			if(%type == 1)
			{
				%this.money += %arg;
				messageClient(%client, '', "\c2You have recieved $" @ %arg @ " from " @ %target @ ".");
			}
			if(%type == 2)
			{
				%this.bankm += %arg;
				messageClient(%client, '', "\c2$" @ %arg @ " has been transferred to your account by " @ %target @ ".");
			}
	}
	%this.cashUpdated = 1;
}