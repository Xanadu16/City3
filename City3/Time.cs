function C3GetTime(%value)
{
	%realTime = getWord(getDateTime(),1);
	%strippedTime = strreplace(%realTime,":"," ");

	switch(%value)
	{
		default:
			return %realTime
		case "strip":
			return %strippedTime;
		case "hour":
			return getWord(%strippedTime,0);
		case "minute":
			return getWord(%strippedTime,1);
		case "second":
			return getWord(%strippedTime,2);
	}
}

function getEnvironmentTime()
{
	%pas = $Sim::Time/Daycycle.dayLength;
	%tim = %pas - mFloor(%pas);
	while(%tim >= 1)
		tim--;
	while(%tim < 0)
		%tim++;
	return %tim;
}

function setEnvironmentTime(%time)
{
   dayCycle.setDayOffset(%time-getEnvironmentTime());
}
//Thanks for those above 2 functions, marble.

function C3Tick()
{
	$City3::Time = C3GetTime("strip");
	$City3::Tick = schedule(1000, 0, C3Tick());

	//Insert everything that happens each tick here.
}