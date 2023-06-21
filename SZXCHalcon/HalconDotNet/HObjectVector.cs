using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HObjectVector : HVector
	{
		private HObject mObject;

		public HObject O
		{
			get
			{
				base.AssertDimension(0);
				return this.mObject;
			}
			set
			{
				base.AssertDimension(0);
				if (value == null || !value.IsInitialized())
				{
					throw new HVectorAccessException("Uninitialized object not allowed in vector");
				}
				this.mObject.Dispose();
				this.mObject = new HObject(value);
			}
		}

		public new HObjectVector this[int index]
		{
			get
			{
				return (HObjectVector)base[index];
			}
			set
			{
				base[index] = value;
			}
		}

		public HObjectVector(int dimension) : base(dimension)
		{
			this.mObject = ((dimension <= 0) ? HObjectVector.GenEmptyObj() : null);
		}

		public HObjectVector(HObject obj) : base(0)
		{
			if (obj == null || !obj.IsInitialized())
			{
				throw new HVectorAccessException("Uninitialized object not allowed in vector");
			}
			this.mObject = new HObject(obj);
		}

		public HObjectVector(HObjectVector vector) : base(vector)
		{
			if (this.mDimension <= 0)
			{
				this.mObject = new HObject(vector.mObject);
			}
		}

		private static HObject GenEmptyObj()
		{
			HObject expr_05 = new HObject();
			expr_05.GenEmptyObj();
			return expr_05;
		}

		protected override HVector GetDefaultElement()
		{
			return new HObjectVector(this.mDimension - 1);
		}

		public new HObjectVector At(int index)
		{
			return (HObjectVector)base.At(index);
		}

		protected override bool EqualsImpl(HVector vector)
		{
			if (this.mDimension >= 1)
			{
				return base.EqualsImpl(vector);
			}
			return ((HObjectVector)vector).O.TestEqualObj(this.O) != 0;
		}

		public bool VectorEqual(HObjectVector vector)
		{
			return this.EqualsImpl(vector);
		}

		public HObjectVector Concat(HObjectVector vector)
		{
			return (HObjectVector)base.ConcatImpl(vector, false, true);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HObjectVector Concat(HObjectVector vector, bool clone)
		{
			return (HObjectVector)base.ConcatImpl(vector, false, clone);
		}

		public HObjectVector Append(HObjectVector vector)
		{
			return (HObjectVector)base.ConcatImpl(vector, true, true);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HObjectVector Append(HObjectVector vector, bool clone)
		{
			return (HObjectVector)base.ConcatImpl(vector, true, clone);
		}

		public HObjectVector Insert(int index, HObjectVector vector)
		{
			base.InsertImpl(index, vector, true);
			return this;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HObjectVector Insert(int index, HObjectVector vector, bool clone)
		{
			base.InsertImpl(index, vector, clone);
			return this;
		}

		public new HObjectVector Remove(int index)
		{
			base.RemoveImpl(index);
			return this;
		}

		public new HObjectVector Clear()
		{
			this.ClearImpl();
			return this;
		}

		public new HObjectVector Clone()
		{
			return (HObjectVector)this.CloneImpl();
		}

		protected override HVector CloneImpl()
		{
			return new HObjectVector(this);
		}

		protected override void DisposeLeafObject()
		{
			if (this.mDimension <= 0)
			{
				this.mObject.Dispose();
			}
		}

		public override string ToString()
		{
			if (this.mDimension <= 0)
			{
				return this.mObject.Key.ToString();
			}
			return base.ToString();
		}
	}
}
