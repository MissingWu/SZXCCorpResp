using System;

namespace SZXCArimEngine
{
	public class HDevProcedureCall : IDisposable
	{
		private IntPtr call = IntPtr.Zero;

		private HDevProcedure procedure;

		public HDevProcedureCall(HDevProcedure procedure)
		{
			HDevProcedureCall.HCkE(EngineAPI.CreateProcedureCall(procedure.Handle, out this.call));
			GC.KeepAlive(this);
			this.procedure = procedure;
		}

		public bool IsInitialized()
		{
			return this.call != IntPtr.Zero;
		}

		public HDevProcedure GetProcedure()
		{
			return this.procedure;
		}

		public void Execute()
		{
			HDevProcedureCall.HCkE(EngineAPI.ExecuteProcedureCall(this.call));
			GC.KeepAlive(this);
		}

		public void SetWaitForDebugConnection(bool wait_once)
		{
			HDevProcedureCall.HCkE(EngineAPI.SetWaitForDebugConnectionProcedureCall(this.call, wait_once));
			GC.KeepAlive(this);
		}

		public void Reset()
		{
			HDevProcedureCall.HCkE(EngineAPI.ResetProcedureCall(this.call));
			GC.KeepAlive(this);
		}

		public void SetInputCtrlParamTuple(int index, HTuple tuple)
		{
			IntPtr intPtr;
			HDevProcedureCall.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			SZXCArimAPI.StoreTuple(intPtr, tuple);
			HDevProcedureCall.HCkE(EngineAPI.SetInputCtrlParamTuple(this.call, index, intPtr));
			GC.KeepAlive(this);
			HDevProcedureCall.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
		}

		public void SetInputCtrlParamTuple(string name, HTuple tuple)
		{
			IntPtr intPtr;
			HDevProcedureCall.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			SZXCArimAPI.StoreTuple(intPtr, tuple);
			HDevProcedureCall.HCkE(EngineAPI.SetInputCtrlParamTuple(this.call, name, intPtr));
			GC.KeepAlive(this);
			HDevProcedureCall.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
		}

		public void SetInputCtrlParamVector(int index, HTupleVector vector)
		{
			IntPtr intPtr;
			HDevProcedureCall.HCkE(EngineAPI.CreateTupleVector(vector, out intPtr));
			HDevProcedureCall.HCkE(EngineAPI.SetInputCtrlParamVector(this.call, index, intPtr));
			GC.KeepAlive(this);
			HDevProcedureCall.HCkE(EngineAPI.DestroyTupleVector(intPtr));
		}

		public void SetInputCtrlParamVector(string name, HTupleVector vector)
		{
			IntPtr intPtr;
			HDevProcedureCall.HCkE(EngineAPI.CreateTupleVector(vector, out intPtr));
			HDevProcedureCall.HCkE(EngineAPI.SetInputCtrlParamVector(this.call, name, intPtr));
			GC.KeepAlive(this);
			HDevProcedureCall.HCkE(EngineAPI.DestroyTupleVector(intPtr));
		}

		public void SetInputIconicParamObject(int index, HObject iconic)
		{
			HDevProcedureCall.HCkE(EngineAPI.SetInputIconicParamObject(this.call, index, iconic.Key));
			GC.KeepAlive(iconic);
			GC.KeepAlive(this);
		}

		public void SetInputIconicParamObject(string name, HObject iconic)
		{
			HDevProcedureCall.HCkE(EngineAPI.SetInputIconicParamObject(this.call, name, iconic.Key));
			GC.KeepAlive(iconic);
			GC.KeepAlive(this);
		}

		public void SetInputIconicParamVector(int index, HObjectVector vector)
		{
			IntPtr intPtr;
			HDevProcedureCall.HCkE(EngineAPI.CreateObjectVector(vector, out intPtr));
			HDevProcedureCall.HCkE(EngineAPI.SetInputIconicParamVector(this.call, index, intPtr));
			GC.KeepAlive(this);
			HDevProcedureCall.HCkE(EngineAPI.DestroyObjectVector(intPtr));
		}

		public void SetInputIconicParamVector(string name, HObjectVector vector)
		{
			IntPtr intPtr;
			HDevProcedureCall.HCkE(EngineAPI.CreateObjectVector(vector, out intPtr));
			HDevProcedureCall.HCkE(EngineAPI.SetInputIconicParamVector(this.call, name, intPtr));
			GC.KeepAlive(this);
			HDevProcedureCall.HCkE(EngineAPI.DestroyObjectVector(intPtr));
		}

		public HTuple GetOutputCtrlParamTuple(int index)
		{
			IntPtr tupleHandle;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputCtrlParamTuple(this.call, index, out tupleHandle));
			GC.KeepAlive(this);
			return SZXCArimAPI.LoadTuple(tupleHandle);
		}

		public HTuple GetOutputCtrlParamTuple(string name)
		{
			IntPtr tupleHandle;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputCtrlParamTuple(this.call, name, out tupleHandle));
			GC.KeepAlive(this);
			return SZXCArimAPI.LoadTuple(tupleHandle);
		}

		public HTupleVector GetOutputCtrlParamVector(int index)
		{
			IntPtr vectorHandle;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputCtrlParamVector(this.call, index, out vectorHandle));
			GC.KeepAlive(this);
			return EngineAPI.GetAndDestroyTupleVector(vectorHandle);
		}

		public HTupleVector GetOutputCtrlParamVector(string name)
		{
			IntPtr vectorHandle;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputCtrlParamVector(this.call, name, out vectorHandle));
			GC.KeepAlive(this);
			return EngineAPI.GetAndDestroyTupleVector(vectorHandle);
		}

		public HObject GetOutputIconicParamObject(int index)
		{
			IntPtr key;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, index, out key));
			GC.KeepAlive(this);
			return new HObject(key);
		}

		public HObject GetOutputIconicParamObject(string name)
		{
			IntPtr key;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, name, out key));
			GC.KeepAlive(this);
			return new HObject(key);
		}

		public HObjectVector GetOutputIconicParamVector(int index)
		{
			IntPtr vectorHandle;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamVector(this.call, index, out vectorHandle));
			GC.KeepAlive(this);
			return EngineAPI.GetAndDestroyObjectVector(vectorHandle);
		}

		public HObjectVector GetOutputIconicParamVector(string name)
		{
			IntPtr vectorHandle;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamVector(this.call, name, out vectorHandle));
			GC.KeepAlive(this);
			return EngineAPI.GetAndDestroyObjectVector(vectorHandle);
		}

		public HImage GetOutputIconicParamImage(int index)
		{
			IntPtr key;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, index, out key));
			GC.KeepAlive(this);
			EngineAPI.AssertObjectClass(key, "image", "main");
			return new HImage(key);
		}

		public HImage GetOutputIconicParamImage(string name)
		{
			IntPtr key;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, name, out key));
			GC.KeepAlive(this);
			EngineAPI.AssertObjectClass(key, "image", "main");
			return new HImage(key);
		}

		public HRegion GetOutputIconicParamRegion(int index)
		{
			IntPtr key;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, index, out key));
			GC.KeepAlive(this);
			EngineAPI.AssertObjectClass(key, "region", "main");
			return new HRegion(key);
		}

		public HRegion GetOutputIconicParamRegion(string name)
		{
			IntPtr key;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, name, out key));
			GC.KeepAlive(this);
			EngineAPI.AssertObjectClass(key, "region", "main");
			return new HRegion(key);
		}

		public HXLD GetOutputIconicParamXld(int index)
		{
			IntPtr key;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, index, out key));
			GC.KeepAlive(this);
			EngineAPI.AssertObjectClass(key, "xld", "main");
			return new HXLD(key);
		}

		public HXLD GetOutputIconicParamXld(string name)
		{
			IntPtr key;
			HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, name, out key));
			GC.KeepAlive(this);
			EngineAPI.AssertObjectClass(key, "xld", "main");
			return new HXLD(key);
		}

		internal static void HCkE(int err)
		{
			EngineAPI.HCkE(err);
		}

		~HDevProcedureCall()
		{
			try
			{
				this.Dispose();
			}
			catch (Exception)
			{
			}
		}

		void IDisposable.Dispose()
		{
			this.Dispose();
		}

		public virtual void Dispose()
		{
			if (this.call != IntPtr.Zero)
			{
				EngineAPI.DestroyProcedureCall(this.call);
				this.call = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
			GC.KeepAlive(this);
		}
	}
}
