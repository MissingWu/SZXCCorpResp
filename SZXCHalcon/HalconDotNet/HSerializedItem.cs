using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace SZXCArimEngine
{
	public class HSerializedItem : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSerializedItem() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSerializedItem(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSerializedItem(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("serialized_item");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSerializedItem obj)
		{
			obj = new HSerializedItem(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSerializedItem[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HSerializedItem[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HSerializedItem(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HSerializedItem(IntPtr pointer, int size, string copy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(410);
			SZXCArimAPI.StoreIP(proc, 0, pointer);
			SZXCArimAPI.StoreI(proc, 1, size);
			SZXCArimAPI.StoreS(proc, 2, copy);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSerializedItem(byte[] data)
		{
			GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
			IntPtr pointer = gCHandle.AddrOfPinnedObject();
			this.CreateSerializedItemPtr(pointer, data.Length, "true");
			gCHandle.Free();
		}

		public static implicit operator byte[](HSerializedItem item)
		{
			int num;
			IntPtr arg_12_0 = item.GetSerializedItemPtr(out num);
			byte[] array = new byte[num];
			Marshal.Copy(arg_12_0, array, 0, num);
			GC.KeepAlive(item);
			return array;
		}

		internal new void Serialize(Stream stream)
		{
			byte[] array = this;
			stream.Write(array, 0, array.Length);
		}

		internal new static HSerializedItem Deserialize(Stream stream)
		{
			BinaryReader expr_06 = new BinaryReader(stream);
			byte[] array = expr_06.ReadBytes(16);
			ulong num;
			if (array.Length < 16 || SZXCArimAPI.IsFailure(SZXCArimAPI.GetSerializedSize(array, out num)))
			{
				throw new SZXCArimException("Input stream is no serialized SZXCArim object");
			}
			ulong vas = 1879049217;
			if (num > vas)
			{
				throw new SZXCArimException("Input stream too large");
			}
			byte[] expr_4B = expr_06.ReadBytes((int)num);
			if (expr_4B.Length < (int)num || SZXCArimAPI.IsFailure(SZXCArimAPI.GetSerializedSize(array, out num)))
			{
				throw new SZXCArimException("Unexpected end of serialization data");
			}
			byte[] array2 = new byte[(int)num + 16];
			array.CopyTo(array2, 0);
			expr_4B.CopyTo(array2, 16);
			return new HSerializedItem(array2);
		}

		public void ReceiveSerializedItem(HSocket socket)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(403);
			SZXCArimAPI.Store(proc, 0, socket);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(socket);
		}

		public void SendSerializedItem(HSocket socket)
		{
			IntPtr proc = SZXCArimAPI.PreCall(404);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, socket);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(socket);
		}

		public void FwriteSerializedItem(HFile fileHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(405);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, fileHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(fileHandle);
		}

		public void FreadSerializedItem(HFile fileHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(406);
			SZXCArimAPI.Store(proc, 0, fileHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(fileHandle);
		}

		public static void ClearSerializedItem(HSerializedItem[] serializedItemHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(serializedItemHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(408);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(serializedItemHandle);
		}

		public void ClearSerializedItem()
		{
			IntPtr proc = SZXCArimAPI.PreCall(408);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public IntPtr GetSerializedItemPtr(out int size)
		{
			IntPtr proc = SZXCArimAPI.PreCall(409);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			IntPtr result;
			num = SZXCArimAPI.LoadIP(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out size);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CreateSerializedItemPtr(IntPtr pointer, int size, string copy)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(410);
			SZXCArimAPI.StoreIP(proc, 0, pointer);
			SZXCArimAPI.StoreI(proc, 1, size);
			SZXCArimAPI.StoreS(proc, 2, copy);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
