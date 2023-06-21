using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HOperatorException : SZXCArimException
	{
		public HOperatorException(int err, string sInfo, Exception inner) : base(err, (sInfo == "") ? SZXCArimAPI.GetErrorMessage(err) : sInfo, inner)
		{
		}

		public HOperatorException(int err, string sInfo) : this(err, sInfo, null)
		{
		}

		public HOperatorException(int err) : this(err, "")
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never), Obsolete("GetErrorText is deprecated, please use GetErrorMessage instead.")]
		public new string GetErrorText()
		{
			return SZXCArimAPI.GetErrorMessage(base.GetErrorCode());
		}

		public new string GetErrorMessage()
		{
			return SZXCArimAPI.GetErrorMessage(base.GetErrorCode());
		}

		public long GetExtendedErrorCode()
		{
			HTuple hTuple;
			HTuple hTuple2;
			HTuple hTuple3;
			HOperatorSet.GetExtendedErrorInfo(out hTuple, out hTuple2, out hTuple3);
			if (hTuple2.Length > 0)
			{
				return hTuple2[0].L;
			}
			return 0L;
		}

		public string GetExtendedErrorMessage()
		{
			HTuple hTuple;
			HTuple hTuple2;
			HTuple hTuple3;
			HOperatorSet.GetExtendedErrorInfo(out hTuple, out hTuple2, out hTuple3);
			if (hTuple3.Length > 0)
			{
				return hTuple3[0];
			}
			return "";
		}

		public static void throwOperator(int err, string logicalName)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				throw new HOperatorException(err, SZXCArimAPI.GetErrorMessage(err) + " in operator " + logicalName);
			}
		}

		internal static void throwOperator(int err, int procIndex)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				string logicalName = SZXCArimAPI.GetLogicalName(procIndex);
				//throw new HOperatorException(err, SZXCArimAPI.GetErrorMessage(err) + " in operator " + logicalName);
			}
		}

		public static void throwInfo(int err, string sInfo)
		{
			throw new HOperatorException(err, sInfo + ":\n" + SZXCArimAPI.GetErrorMessage(err) + "\n");
		}
	}
}
