using System;

namespace SZXCArimEngine
{
	internal class HDevOutputParamObject : HDevOutputParam
	{
		protected HObject mObject;

		public HDevOutputParamObject(HObject obj, bool global) : base(global)
		{
			this.mObject = obj;
		}

		public override void StoreIconicParamObject(HObject obj)
		{
			this.mObject.TransferOwnership(obj);
		}
	}
}
