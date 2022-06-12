namespace ASimpleRPG;

using System;
using System.Runtime.Serialization;

public class WhatTheFuckException : Exception
{
	public WhatTheFuckException()
	{

	}
	public WhatTheFuckException(string? message) : base(message)
	{

	}
	public WhatTheFuckException(string? message, Exception? innerException) : base(message, innerException)
	{

	}
	protected WhatTheFuckException(SerializationInfo info, StreamingContext context) : base(info, context)
	{

	}
}