namespace ASimpleRPG.WorldData;
using System;
public class WorldGate
{
	public Type world;
    public byte roomTo;
	// This does not use generics as its required to say which beforehand, limiting it
    public WorldGate(Type world, byte roomTo) 
    {
		if (!world.IsSubclassOf(typeof(World))) throw new ArgumentException("World Gate does not lead to world!");
        this.roomTo = roomTo;
		this.world = world;
    }
	public override string ToString() => Icons.Data.worldGate.ToString();
}
public class Gate
{
	public byte leadsTo;
	public Gate(byte leadsTo)
	{
		this.leadsTo = leadsTo;
	}
	public override string ToString() => Icons.Data.gate.ToString();
}