namespace ASimpleRPG.WorldData;
public abstract class StaticObject
{
    public string name;
    public Quality quality;
    public abstract byte Y { get; }
    public abstract byte X { get; }
    public abstract char Icon { get; }
    public bool Collidable => (int)Quality.Broken <= (int)quality;
    public StaticObject(string name, Quality quality)
    {
        this.name = name;
        this.quality = quality;
    }
    public override string ToString() => $"{quality} {name}";
}
public enum Quality
{
    Fragmented,
    Shattered,
    Broken,
    Damaged,
    Scratched,
    Untouched,
    Shiny,
    MirrorLike
}