using System;

namespace SZXCArimEngine
{
	internal class HDevOutputParamTuple : HDevOutputParam
	{
		protected HTuple mTuple;

		public HDevOutputParamTuple(HTuple tuple, bool global) : base(global)
		{
			this.mTuple = tuple;
		}

		public override void StoreCtrlParamTuple(HTuple tuple)
		{
			this.mTuple.TransferOwnership(tuple);
		}
	}
}
