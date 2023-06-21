using System;

namespace SZXCArimEngine
{
	internal class HDevInputParamVector : HDevInputParam
	{
		protected HVector mVector;

		public HDevInputParamVector(HVector vector)
		{
			this.mVector = vector.Clone();
		}

		public override HTupleVector GetCtrlParamVector()
		{
			return (HTupleVector)this.mVector;
		}

		public override HObjectVector GetIconicParamVector()
		{
			return (HObjectVector)this.mVector;
		}

		public override void Dispose()
		{
			if (this.mVector != null)
			{
				this.mVector.Dispose();
				this.mVector = null;
			}
		}
	}
}
