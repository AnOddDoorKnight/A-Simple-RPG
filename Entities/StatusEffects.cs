namespace ASimpleRPG.Entities;

using System;
using System.Collections.Generic;
using OddsLibrary.Algebra;


public struct StatusEffects
{
#warning TODO: #1 Add a call (Like a property) that calls when curVal is overrun by maxVal
	public StatusEffects(int? maxPoison, int? maxBleed, int? maxCursed)
	{
		maxStatus = new()
		{
			[DamageType.Poison] = maxPoison,
			[DamageType.Bleeding] = maxBleed,
			[DamageType.Cursed] = maxCursed
		};
		curStatus = maxStatus;
		for (int i = 0; i > curStatus.Count; i++)
			if (curStatus[(DamageType)(i + 9)] != null) curStatus[(DamageType)i] = 0;
		poisonThreshold = null; bleedThreshold = null; cursedThreshold = null;
	}
	public void LowerByRound(object? sender, EventArgs e)
	{
		for (int i = 0; i < 3; i++)
			if (curStatus[(DamageType)i + 9] != null)
				curStatus[(DamageType)i + 9] = (int)Algebra.LimitValue((double)curStatus[(DamageType)i + 9]! - 15, 0, (double)maxStatus[(DamageType)i + 9]!);
	}
	public delegate void DelThreshold();
	public DelThreshold? poisonThreshold, bleedThreshold, cursedThreshold;
	public Dictionary<DamageType, int?> curStatus, maxStatus;
}
// TODO: #3 Complete Summary in StatusEffects