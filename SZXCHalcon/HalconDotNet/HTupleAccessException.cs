using System;

namespace SZXCArimEngine
{
	public class HTupleAccessException : SZXCArimException
	{
		private static string BuildMessage(HTupleImplementation sender, string sInfo)
		{
			string text = sInfo;
			if (sender != null)
			{
				text = string.Concat(new string[]
				{
					"'",
					text,
					"' when accessing '",
					sender.ToString(),
					"'"
				});
			}
			return text;
		}

		internal HTupleAccessException(HTupleImplementation sender, string sInfo, Exception inner) : base(HTupleAccessException.BuildMessage(sender, sInfo), null)
		{
		}

		internal HTupleAccessException(HTupleImplementation sender, string sInfo) : this(sender, sInfo, null)
		{
		}

		internal HTupleAccessException(HTupleImplementation sender) : this(sender, "Illegal operation on Tuple")
		{
		}

		internal HTupleAccessException(string sInfo, Exception inner) : this(null, sInfo, inner)
		{
		}

		internal HTupleAccessException(string sInfo) : this(null, sInfo)
		{
		}

// 		internal HTupleAccessException() : this(null)
// 		{
// 		}
	}
}
