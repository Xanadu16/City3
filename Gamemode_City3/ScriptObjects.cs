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
	switch(%task)
	{
		case "give":
		{
			switch(%obj)
			{
				case "money":
					%this.money -= %arg;
					messageClient(%client, '', "\c2You have paid $" @ %arg @ " to " @ %target @ ".");
				case "bankm":
					%this.bankm -= %arg;
					messageClient(%client, '', "\c2You have transfered $" @ %arg @ " to " @ %target @ ".");
			}
		}
		case "recieve":
		{
			switch(%obj)
			{
				case "money":
					%this.money += %arg;
					messageClient(%client, '', "\c2You have recieved $" @ %arg @ " from " @ %target @ ".");
				case "bankm":
					%this.bankm += %arg;
					messageClient(%client, '', "\c2$" @ %arg @ " has been transferred to your account by " @ %target @ ".");
			}
		}
	}
	%this.cashUpdated = 1;
}