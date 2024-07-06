using System;

namespace RedLine.MainPanel.DbControllers;

public class LazyLoader<T> where T : class, new()
{
	private sealed class SingletonCreator<S> where S : class, new()
	{
		private static readonly Lazy<S> lazy = new Lazy<S>(() => new S());

		public static S CreatorInstance => lazy.Value;
	}

	public static T Instance => SingletonCreator<T>.CreatorInstance;

	protected LazyLoader()
	{
	}
}
