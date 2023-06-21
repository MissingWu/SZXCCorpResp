using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HMessageQueue : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMessageQueue(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMessageQueue(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("message_queue");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMessageQueue obj)
		{
			obj = new HMessageQueue(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMessageQueue[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HMessageQueue[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HMessageQueue(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HMessageQueue()
		{
			IntPtr proc = SZXCArimAPI.PreCall(533);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetMessageQueueParam(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(528);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetMessageQueueParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(528);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetMessageQueueParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(529);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetMessageQueueParam(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(529);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HMessage[] DequeueMessage(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(530);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HMessage[] result;
			num = HMessage.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMessage DequeueMessage(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(530);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HMessage result;
			num = HMessage.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void EnqueueMessage(HMessage[] messageHandle, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(messageHandle);
			IntPtr proc = SZXCArimAPI.PreCall(531);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, hTuple);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(messageHandle);
		}

		public void EnqueueMessage(HMessage messageHandle, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(531);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, messageHandle);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(messageHandle);
		}

		public static void ClearMessageQueue(HMessageQueue[] queueHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(queueHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(532);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(queueHandle);
		}

		public void ClearMessageQueue()
		{
			IntPtr proc = SZXCArimAPI.PreCall(532);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateMessageQueue()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(533);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
