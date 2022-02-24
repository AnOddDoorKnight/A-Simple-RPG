namespace ASimpleRPG;
using Logging;
using System.Linq;
using Entities;
using System;
public sealed class CombatHandler
{
	ConditionManager<Entity>?[] entities;
	Entity?[] EntitiesSkinless { get
		{
			Entity[] entities = new Entity[this.entities.Length];
			for (int i = 0; i < this.entities.Length; i++)
			{
				Entity? entity = this.entities[i].Value;
				entities[i] = entity;
			}
			return entities;
		} }
	public CombatHandler(params Entity[] input)
	{
		ConditionManager<Entity>?[] entities = new ConditionManager<Entity>[input.Length];
		for (int i = 0; i < input.Length; i++)
		{
			Entity entity = input[i];
			entities[i] = new ConditionManager<Entity>(entity);
			entities[i]!.Value.Health.declareDeath = DeclareDeath;
		}
		this.entities = entities!;
	}
	public void DeclareDeath(HealthData sender)
	{
		Entity foo = sender.GetParentOfHealthData!();
		for (int i = 0; i < entities.Length; i++)
			if (EntitiesSkinless.Contains(foo)) 
				entities[(Array.IndexOf(EntitiesSkinless, foo))] = null;
	}
	
	~CombatHandler()
	{
		Debug.Log("Finished Combat.");
		for(int i = 0; i < entities.Length; i++)
		{
			// Return values here, 
		}
		NewRound?.Invoke();
	}
	public event Empty? NewRound;
	public delegate void Empty();
	public delegate void DelDeclareDeath(object? sender);
}
public class ConditionManager<T>
{
	public T Value;
	public ConditionManager(T values)
	{
		Value = values;
	}
}