if(!isObject(C3Wallet))
{
	new scriptObject(C3WalletSO) {};
}

function C3Wallet::add(%this,%obj,%arg)
{	
switch(%obj)
	{
		case "money"
			%this.money += %arg;
		case "bankm"
			%this.bankm += %arg;
	}
%this.cashUpdated = 1;
}