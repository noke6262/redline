using System;

namespace RedLine.MainPanel.Views;

public static class CurrentMillis
{
	private static readonly DateTime dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	public static long Millis => (long)(DateTime.UtcNow - dateTime_0).TotalMilliseconds;
}
