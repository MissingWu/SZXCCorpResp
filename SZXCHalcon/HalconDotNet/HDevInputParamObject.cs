using System;

namespace SZXCArimEngine
{
	internal class HDevInputParamObject : HDevInputParam
	{
		protected HObject mObject;

		public HDevInputParamObject(HObject obj)
		{
			this.mObject = obj.CopyObj(1, -1);
		}

		public override HObject GetIconicParamObject()
		{
			return this.mObject;
		}

		public override void Dispose()
		{
			if (this.mObject != null)
			{
				this.mObject.Dispose();
				this.mObject = null;
			}
		}
	}
}
