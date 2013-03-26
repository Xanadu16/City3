package City3DBPKG
{
	function GameConnection::autoAdminCheck(%this)
	{
		parent::autoAdminCheck(%this);

		CityDB_loadUser(%this);

		%this.lvd = getDateTime();
	}

	function GameConnection::onClientLeaveGame(%this)
	{
		CityDB_saveUser(%this);

		parent::onClientLeaveGame(%this);
	}
};
activatepackage("City3DBPKG");


function CityDB_saveUser(%client)
{
	%path = $City3::UserSaves @ %client.BL_ID @ ".dat";

	%file = new FileObject();
	%file.openForWrite(%path);

	%file.writeLine("name lvd cash bank alias");

	%file.writeLine(%client.name);
	%file.writeLine(%client.lvd);

	%file.writeLine(%client.C3Wallet.money);
	%file.writeLine(%client.C3Wallet.bankm);

	%file.writeLine(%client.C3Alias_First NL %client.C3Alias_Last);

	%file.close();
	%file.delete();
}

function CityDB_loadUser(%client)
{
	%path = $City3::UserSaves @ %client.BL_ID @ ".dat";

	if(!fileExists(%path))
	{
		if($City3::DebugMode)
			warn("Client with BLID" SPC %client.BL_ID SPC "has no profile, skipping loading sequence.");

		return false;
	}

	//I'll make the loading system a lot more dynamic at a later time.

	%file = new FileObject();
	%file.openForRead(%path);

	%file.readline(); %file.readLine(); %file.readLine();

	%client.C3Wallet.money = %file.readline();
	%client.C3Wallet.bankm = %file.readline();
	%client.C3Alias_First = %file.readline();
	%client.C3Alias_Last = %file.readline();

	%file.close();
	%file.delete();
}