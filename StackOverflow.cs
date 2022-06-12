namespace StackOverflow;

using System;

/// <summary>
/// <para>
/// A pointer for primitive data types and classes, does not work with structs
/// </para>
/// <para>
/// In order to use it, you will need to create the class, then input these
/// parameters
/// <code>
/// (() => yourT, randomVar => { yourT = randomVar });
/// </code>
/// </para>
/// </summary>
/// <typeparam name="T">The Object Referenced</typeparam>
// https://stackoverflow.com/questions/2980463/how-do-i-assign-by-reference-to-a-class-field-in-c
public sealed class Ref<T> 
{
	private readonly Func<T> getter;
	private readonly Action<T> setter;
	public Ref(Func<T> getter, Action<T> setter)
	{
		this.getter = getter;
		this.setter = setter;
	}
	public T Value { get { return getter(); } set { setter(value); } }
}