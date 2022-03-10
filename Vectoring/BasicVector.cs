namespace ASimpleRPG.Vectoring;

using System;
using System.Diagnostics;


public struct Vector2
{
	public byte X, Y;
	public Vector2(byte X, byte Y)
	{
		this.X = X;
		this.Y = Y;
	}
	public static void GetVector()
	{
		Console.WriteLine("Haha you just got vectored");
		Process.Start("https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpreview.redd.it%2Fo0uoqmgoqw541.jpg%3Fauto%3Dwebp%26s%3D9c7db02153d0ddfce7b49c6f84bc9dbbbc346c35&f=1&nofb=1");
	}
	public RoomObj<T> ToRoomObj<T>(T @object)
		where T : class => new(@object, X, Y);
}
