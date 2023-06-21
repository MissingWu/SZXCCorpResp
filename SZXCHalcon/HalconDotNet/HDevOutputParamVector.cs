using System;

namespace SZXCArimEngine
{
	internal class HDevOutputParamVector : HDevOutputParam
	{
		protected HVector mVector;

		protected HTuple mIndex;

		public HDevOutputParamVector(HVector vector, HTuple index, bool global) : base(global)
		{
			this.mVector = vector;
			this.mIndex = index.Clone();
		}

		public override void StoreIconicParamObject(HObject obj)
		{
			HObjectVector hObjectVector = (HObjectVector)this.mVector;
			for (int i = 0; i < this.mIndex.Length; i++)
			{
				hObjectVector = hObjectVector[this.mIndex[i]];
			}
			hObjectVector.O.TransferOwnership(obj);
		}

		public override void StoreCtrlParamTuple(HTuple tuple)
		{
			HTupleVector hTupleVector = (HTupleVector)this.mVector;
			for (int i = 0; i < this.mIndex.Length; i++)
			{
				hTupleVector = hTupleVector[this.mIndex[i]];
			}
			hTupleVector.T.TransferOwnership(tuple);
		}

		private void StoreParamVector(HVector vector)
		{
			HVector hVector = this.mVector;
			for (int i = 0; i < this.mIndex.Length; i++)
			{
				hVector = hVector[this.mIndex[i]];
			}
			hVector.TransferOwnership(vector);
		}

		public override void StoreIconicParamVector(HObjectVector vector)
		{
			this.StoreParamVector(vector);
		}

		public override void StoreCtrlParamVector(HTupleVector vector)
		{
			this.StoreParamVector(vector);
		}
	}
}
