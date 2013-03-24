package C3Pack
{
	function GameConnection::autoAdminCheck(%client)
	{
		%v = Parent::autoAdminCheck(%client);
		
		schedule(500,0,"commandToClient",%client,'C3_Handshake',$C3::Server::Version);
		
		return %v;
	}
};
activatepackage(C3Pack);

function C3_returnHandshake(%client, %version)
{
	if(%version == $ES::Server::Version)
		%client.c3HasClient = 1;
}