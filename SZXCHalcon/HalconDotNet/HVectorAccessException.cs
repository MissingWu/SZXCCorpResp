using System;

namespace SZXCArimEngine
{
	public class HVectorAccessException : SZXCArimException
	{
		private static string BuildMessage(HVector sender, string sInfo)
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

		internal HVectorAccessException(HVector sender, string sInfo, Exception inner) : base(HVectorAccessException.BuildMessage(sender, sInfo), null)
		{
		}

		internal HVectorAccessException(HVector sender, string sInfo) : this(sender, sInfo, null)
		{
		}

		internal HVectorAccessException(HVector sender) : this(sender, "Illegal operation on vector")
		{
		}

		internal HVectorAccessException(string sInfo, Exception inner) : this(null, sInfo, inner)
		{
		}

		internal HVectorAccessException(string sInfo) : this(null, sInfo)
		{
		}

// 		internal HVectorAccessException() : this(null)
// 		{
// 		}
	}
}
