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

	%File.writeLine("name lvd cash bank alias");

	%file.writeLine(%client.name);
	%file.writeLine(%client.lvd);

	%file.writeLine(%client.C3Wallet.money);
	%file.writeLine(%client.C3Wallet.bankm);

	%file.writeLine(%client.C3Alias_First SPC %client.C3Alias_Last);

	%file.close();
	%file.delete();
}

function CityDB_loadUser(%client)
{
	//to be finished
}