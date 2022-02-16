namespace ASimpleRPG.WorldData;
using System;
/// <summary>
/// Like <seealso cref="Gate"/>, but relies on <see cref="World"/> instead of rooms
/// </summary>
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
		Master.debug.Log($"Created worldGate to {world}, room {roomTo}", Logging.Debug.SubCategory.CreateArea);
    }
	public override string ToString() => Icons.Data.worldGate.ToString();
}
/// <summary>
/// Leads to another area if entered, usually by a <see cref="byte"/> 
/// </summary>
public class Gate
{
	public byte leadsTo;
	public Gate(byte leadsTo)
	{
		this.leadsTo = leadsTo;
		Master.debug.Log($"Created gate to {leadsTo}", Logging.Debug.SubCategory.CreateArea);
	}
	public override string ToString() => Icons.Data.gate.ToString();
}