namespace ASimpleRPG.Entities;
using System;
/// <summary>
/// 
/// </summary>
public struct Resistances
{
    public float this[DamageType type] { get => Values[(int)type]; set => Values[(int)type] = value; }
    public float[] Values = { 0, 0, 0, 0 };
    public Resistances()
    {
        throw new NotImplementedException();
    }
    public float GetNewValue(float input, DamageType type) =>
        type == DamageType.Bludgeoning ? input - Values[3] : input - (input - Values[(int)type]);
}