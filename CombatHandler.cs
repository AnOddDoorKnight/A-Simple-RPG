namespace ASimpleRPG;

using Logging;
using Vectoring;
using WorldData;
using System.Linq;
using Entities;
using System;
using System.Collections.Generic;
using StackOverflow;


public sealed class CombatHandler
{
	public static WorldObj<PlayableCharacter> character
	{
		get => Master.player;
		set => Master.player = value;
	}
	public List<Ref<Entity>> entities;
	public List<Entity> GetEntities
	{
		get
		{
			List<Entity> entities = new();
			foreach (Ref<Entity> entity in this.entities)
				entities.Add(entity.Value);
			return entities;
		}
	}
	public CombatHandler(params Ref<Entity>[] referencedEntities)
	{
		string debugger = "Created CombatHandler:";
		entities = referencedEntities.ToList();
		for (int i = 0; i < referencedEntities.Length; i++)
		{
			debugger += $"\n{referencedEntities[i].Value.Name}";
			entities[i].Value.Health.declareDeath = DeclareDeath;
		}
		Debug.Log(debugger, Debug.SubCategory.CreateEvent);
	}
	public void DeclareDeath(Ref<Entity> calledObject)
	{
		if (entities.Contains(calledObject))
			calledObject.Value.isDead = true;
	}
	
	~CombatHandler()
	{
		Debug.Log("Finished Combat.");
		NewRound?.Invoke();
	}
	public event Empty? NewRound;
	public delegate void Empty();
	public delegate void DelDeclareDeath(Ref<Entity> calledObject);
}