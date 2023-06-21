using System;

namespace SZXCArimEngine
{
	internal class HDevInputParam
	{
		private static SZXCArimException NI()
		{
			return new SZXCArimException("Unexpected parameter type in exported parallelization code");
		}

		public virtual HObject GetIconicParamObject()
		{
			throw HDevInputParam.NI();
		}

		public virtual HObjectVector GetIconicParamVector()
		{
			throw HDevInputParam.NI();
		}

		public virtual HTuple GetCtrlParamTuple()
		{
			throw HDevInputParam.NI();
		}

		public virtual HTupleVector GetCtrlParamVector()
		{
			throw HDevInputParam.NI();
		}

		public virtual void Dispose()
		{
		}
	}
}
