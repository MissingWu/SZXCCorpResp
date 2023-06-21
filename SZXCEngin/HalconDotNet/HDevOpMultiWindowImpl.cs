using System;

namespace SZXCArimEngine
{
	public class HDevOpMultiWindowImpl : HDevOpFixedWindowImpl
	{
		protected HTuple windowIDs;

		protected HTuple fixedIDs;

		protected HTuple fixedUsed;

		private static HTuple TupleFind2(HTuple t1, HTuple t2)
		{
			HTuple hTuple = t1.TupleFind(t2);
			if (hTuple.Length > 0 && hTuple[0].I == -1)
			{
				hTuple = new HTuple();
			}
			return hTuple;
		}

		private void Init(params HTuple[] windowIDs)
		{
			this.fixedIDs = new HTuple().TupleConcat(windowIDs);
			this.fixedUsed = HTuple.TupleGenConst(this.fixedIDs.Length, 0);
			this.windowIDs = new HTuple();
			HTuple hTuple;
			this.DevOpenWindow(0, 0, 512, 512, "black", out hTuple);
			hTuple.Dispose();
		}

		public HDevOpMultiWindowImpl(params HTuple[] windowIDs) : base(0)
		{
			this.Init(windowIDs);
		}

		public HDevOpMultiWindowImpl(params HWindow[] windows) : base(0)
		{
			HTuple hTuple = HHandleBase.ConcatArray(windows);
			this.Init(new HTuple[]
			{
				hTuple
			});
			hTuple.Dispose();
		}

		public HDevOpMultiWindowImpl() : this(new HTuple[0])
		{
		}

		public override void Dispose()
		{
			this.activeID.Dispose();
			this.fixedIDs.Dispose();
			this.fixedUsed.Dispose();
			this.windowIDs.Dispose();
		}

		public override void DevOpenWindow(HTuple row, HTuple column, HTuple width, HTuple height, HTuple background, out HTuple windowID)
		{
			HTuple hTuple = HDevOpMultiWindowImpl.TupleFind2(this.fixedUsed, 0);
			if (hTuple.Length > 0)
			{
				this.activeID.Dispose();
				this.activeID = this.fixedIDs[hTuple[0].I];
				this.fixedUsed[hTuple[0].I] = 1;
			}
			else
			{
				HOperatorSet.SetWindowAttr("background_color", background);
				HOperatorSet.OpenWindow(row, column, width, height, 0, "visible", "", out this.activeID);
			}
			this.windowIDs[this.windowIDs.Length] = this.activeID;
			this.DevGetWindow(out windowID);
		}

		public override void DevCloseWindow()
		{
			if (this.activeID == null || this.activeID.Length == 0)
			{
				return;
			}
			HTuple hTuple = HDevOpMultiWindowImpl.TupleFind2(this.fixedIDs, this.activeID);
			if (hTuple.Length > 0)
			{
				this.fixedUsed[hTuple[0].I] = 0;
			}
			else
			{
				HOperatorSet.CloseWindow(this.activeID);
			}
			hTuple = HDevOpMultiWindowImpl.TupleFind2(this.windowIDs, this.activeID);
			if (hTuple.Length > 0)
			{
				using (HTuple hTuple2 = this.windowIDs.TupleRemove(hTuple[0]))
				{
					this.windowIDs.Dispose();
					this.windowIDs = new HTuple(hTuple2);
				}
			}
			this.activeID.Dispose();
			if (this.windowIDs.Length > 0)
			{
				this.activeID = this.windowIDs[this.windowIDs.Length - 1];
				return;
			}
			this.activeID = new HTuple();
		}

		public override void DevSetWindow(HTuple windowHandle)
		{
			this.activeID.Dispose();
			this.activeID = new HTuple(windowHandle);
		}

		public override void DevGetWindow(out HTuple windowHandle)
		{
			if (SZXCArimAPI.IsLegacyHandleMode())
			{
				windowHandle = this.activeID.L;
				return;
			}
			windowHandle = new HTuple(this.activeID);
		}

		public override void DevSetWindowExtents(HTuple row, HTuple column, HTuple width, HTuple height)
		{
			HTuple hTuple = HDevOpMultiWindowImpl.TupleFind2(this.fixedIDs, this.activeID);
			if (hTuple.Length == 0)
			{
				HOperatorSet.SetWindowExtents(this.activeID, row, column, width, height);
			}
		}
	}
}
