using UnityEngine;

public static class Locator<T> where T : class
{
	private static T I;

	public static bool IsVaild() => I != null;

	public static void Bind(T instance)
	{
		I = instance;
	}

	public static void Unbind(T instance)
	{
		if (I == instance)
		{
			I = null;
		}
	}

	public static T Resolve()
	{
		if (!IsVaild())
		{
			new UnityException("Bindしろや");
		}
		return I;
	}

	public static void Clear()
	{
		I = null;
	}
}
