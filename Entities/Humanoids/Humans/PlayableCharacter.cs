namespace ASimpleRPG.Entities;

using Items;
using System;


public class PlayableCharacter : Human
{
	public override string? Name => playerName;
	private readonly string playerName;
	public Inventory Inventory = new();
	public override HealthData Health { get; set; }
	public override StatusEffects StatusEffects { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public override Resistances Resistances { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public PlayableCharacter(string name)
	{
		playerName = name;
		Health = new HealthData(Stats[ASimpleRPG.Stats.Vigor].AsVigor());
		team = 1;
	}
}