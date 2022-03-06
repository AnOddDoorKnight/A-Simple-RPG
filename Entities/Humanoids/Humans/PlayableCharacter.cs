namespace ASimpleRPG.Entities;
using ASimpleRPG.WorldData;
using System;
public class PlayableCharacter : Human
{
	public override string? Name => playerName;
	private string playerName;
	public override HealthData Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public override StatusEffects StatusEffects { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public override Resistances Resistances { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public PlayableCharacter()
	{
		team = 1;
	}

	public string SaveFileLocation => "";
}