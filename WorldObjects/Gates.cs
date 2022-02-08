namespace ASimpleRPG.WorldData;
using system;
public struct WorldGate
{
	public Type world;
    public byte roomTo;
    public WorldGate(Type world, byte roomTo)
    {
        if (world is not World) throw new ArgumentException("class input is not a world/region!");
        this.world = world;
        roomTo = roomTo;
    }
}
public struct Gate
{
	public byte leadsTo, ID;
	public Gate(byte leadsTo, byte ID)
	{
        this.ID = ID;
		this.leadsTo = leadsTo;
	}
}