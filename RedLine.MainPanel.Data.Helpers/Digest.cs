namespace RedLine.MainPanel.Data.Helpers;

public sealed class Digest
{
	internal enum MD5InitializerConstant : uint
	{
		A = 1732584193u,
		B = 4023233417u,
		C = 2562383102u,
		D = 271733878u
	}

	public uint A;

	public uint B;

	public uint C;

	public uint D;

	public Digest()
	{
		A = 1732584193u;
		B = 4023233417u;
		C = 2562383102u;
		D = 271733878u;
	}

	public override string ToString()
	{
		return MD5Helper.ReverseByte(A).ToString("X8") + MD5Helper.ReverseByte(B).ToString("X8") + MD5Helper.ReverseByte(C).ToString("X8") + MD5Helper.ReverseByte(D).ToString("X8");
	}
}
