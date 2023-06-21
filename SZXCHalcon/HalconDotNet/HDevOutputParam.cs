using System;

namespace SZXCArimEngine
{
	internal class HDevOutputParam
	{
		protected bool mGlobal;

		private static SZXCArimException NI()
		{
			return new SZXCArimException("Unexpected parameter type in exported parallelization code");
		}

		public HDevOutputParam(bool global)
		{
			this.mGlobal = global;
		}

		public bool IsGlobal()
		{
			return this.mGlobal;
		}

		public virtual void StoreIconicParamObject(HObject obj)
		{
			throw HDevOutputParam.NI();
		}

		public virtual void StoreIconicParamVector(HObjectVector vector)
		{
			throw HDevOutputParam.NI();
		}

		public virtual void StoreCtrlParamTuple(HTuple tuple)
		{
			throw HDevOutputParam.NI();
		}

		public virtual void StoreCtrlParamVector(HTupleVector vector)
		{
			throw HDevOutputParam.NI();
		}
	}
}
