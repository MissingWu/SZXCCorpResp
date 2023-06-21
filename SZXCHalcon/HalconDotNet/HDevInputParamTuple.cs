using System;

namespace SZXCArimEngine
{
	internal class HDevInputParamTuple : HDevInputParam
	{
		protected HTuple mTuple;

		public HDevInputParamTuple(HTuple tuple)
		{
			this.mTuple = new HTuple(tuple);
		}

		public override HTuple GetCtrlParamTuple()
		{
			return this.mTuple;
		}

		public override void Dispose()
		{
			if (this.mTuple != null)
			{
				this.mTuple.Dispose();
				this.mTuple = null;
			}
		}
	}
}
