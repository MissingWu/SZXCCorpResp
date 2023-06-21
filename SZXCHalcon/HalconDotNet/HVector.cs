using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SZXCArimEngine
{
	public abstract class HVector : ICloneable, IDisposable
	{
		internal int mDimension;

		protected List<HVector> mVector;

		public int Dimension
		{
			get
			{
				return this.mDimension;
			}
		}

		public int Length
		{
			get
			{
				if (this.mDimension <= 0)
				{
					return 0;
				}
				List<HVector> obj = this.mVector;
				int count;
				lock (obj)
				{
					count = this.mVector.Count;
				}
				return count;
			}
		}

		public HVector this[int index]
		{
			get
			{
				if (this.mDimension < 1 || index < 0)
				{
					throw new HVectorAccessException("Index out of range");
				}
				this.AssertSize(index);
				List<HVector> obj = this.mVector;
				HVector result;
				lock (obj)
				{
					result = this.mVector[index];
				}
				return result;
			}
			set
			{
				if (this.mDimension < 1 || index < 0)
				{
					throw new HVectorAccessException("Index out of range");
				}
				if (value.Dimension != this.mDimension - 1)
				{
					throw new HVectorAccessException("Vector dimension mismatch");
				}
				this.AssertSize(index);
				List<HVector> obj = this.mVector;
				HVector hVector;
				lock (obj)
				{
					hVector = this.mVector[index];
					this.mVector[index] = value.Clone();
				}
				hVector.Dispose();
			}
		}

		protected HVector(int dimension)
		{
			if (dimension < 0)
			{
				throw new HVectorAccessException("Invalid vector dimension " + dimension);
			}
			this.mDimension = dimension;
			this.mVector = ((dimension > 0) ? new List<HVector>() : null);
		}

		protected HVector(HVector vector) : this(vector.Dimension)
		{
			if (this.mDimension > 0)
			{
				this.mVector.Capacity = vector.Length;
				for (int i = 0; i < vector.Length; i++)
				{
					this.mVector.Add(vector[i].Clone());
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TransferOwnership(HVector source)
		{
			if (source == this)
			{
				return;
			}
			if (source != null && source.Dimension != this.Dimension)
			{
				throw new HVectorAccessException("Vector dimension mismatch");
			}
			this.Dispose();
			if (source == null)
			{
				return;
			}
			if (this.mDimension > 0)
			{
				this.mVector = source.mVector;
				source.mVector = new List<HVector>();
				GC.ReRegisterForFinalize(this);
				return;
			}
			throw new HVectorAccessException("TransferOwnership not implemented for leaf");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AssertDimension(int dimension)
		{
			if (this.mDimension != dimension)
			{
				throw new HVectorAccessException("Expected vector dimension " + dimension);
			}
		}

		private void AssertSize(int index)
		{
			if (this.mVector == null)
			{
				return;
			}
			List<HVector> obj = this.mVector;
			lock (obj)
			{
				int count = this.mVector.Count;
				if (index >= count)
				{
					this.mVector.Capacity = index + 1;
					for (int i = count; i <= index; i++)
					{
						this.mVector.Add(this.GetDefaultElement());
					}
				}
			}
		}

		protected abstract HVector GetDefaultElement();

		public HVector At(int index)
		{
			if (this.mDimension < 1 || index < 0 || index >= this.Length)
			{
				throw new HVectorAccessException("Index out of range");
			}
			List<HVector> obj = this.mVector;
			HVector result;
			lock (obj)
			{
				result = this.mVector[index];
			}
			return result;
		}

		protected virtual bool EqualsImpl(HVector vector)
		{
			if (vector.Dimension != this.Dimension)
			{
				return false;
			}
			if (vector.Length != this.Length)
			{
				return false;
			}
			if (this.mDimension > 0)
			{
				for (int i = 0; i < this.Length; i++)
				{
					if (!this[i].VectorEqual(vector[i]))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool VectorEqual(HVector vector)
		{
			return vector.GetType() == base.GetType() && this.EqualsImpl(vector);
		}

		protected HVector ConcatImpl(HVector vector, bool append, bool clone)
		{
			if (this.mDimension < 1 || vector.Dimension != this.mDimension)
			{
				throw new HVectorAccessException("Vector dimension mismatch");
			}
			HVector hVector = append ? this : this.Clone();
			hVector.mVector.Capacity = this.Length + vector.Length;
			for (int i = 0; i < vector.Length; i++)
			{
				hVector.mVector.Add(clone ? vector[i].Clone() : vector[i]);
			}
			return hVector;
		}

		public HVector Concat(HVector vector)
		{
			return this.ConcatImpl(vector, false, true);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HVector Concat(HVector vector, bool clone)
		{
			return this.ConcatImpl(vector, false, clone);
		}

		public HVector Append(HVector vector)
		{
			return this.ConcatImpl(vector, true, true);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HVector Append(HVector vector, bool clone)
		{
			return this.ConcatImpl(vector, true, clone);
		}

		protected void InsertImpl(int index, HVector vector, bool clone)
		{
			if (this.mDimension < 1 || vector.Dimension != this.mDimension - 1)
			{
				throw new HVectorAccessException("Vector dimension mismatch");
			}
			if (index < 0)
			{
				throw new HVectorAccessException("Index out of range");
			}
			this.AssertSize(index - 1);
			List<HVector> obj = this.mVector;
			lock (obj)
			{
				this.mVector.Insert(index, clone ? vector.Clone() : vector);
			}
		}

		public HVector Insert(int index, HVector vector)
		{
			this.InsertImpl(index, vector, true);
			return this;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HVector Insert(int index, HVector vector, bool clone)
		{
			this.InsertImpl(index, vector, clone);
			return this;
		}

		protected void RemoveImpl(int index)
		{
			if (this.mDimension < 1)
			{
				throw new HVectorAccessException("Vector dimension mismatch");
			}
			if (index >= 0 && index < this.Length)
			{
				List<HVector> obj = this.mVector;
				lock (obj)
				{
					this.mVector[index].Dispose();
					this.mVector.RemoveAt(index);
				}
			}
		}

		public HVector Remove(int index)
		{
			this.RemoveImpl(index);
			return this;
		}

		protected virtual void ClearImpl()
		{
			if (this.mDimension < 1)
			{
				throw new HVectorAccessException("Vector dimension mismatch");
			}
			List<HVector> obj = this.mVector;
			lock (obj)
			{
				for (int i = 0; i < this.Length; i++)
				{
					this.mVector[i].Dispose();
				}
				this.mVector.Clear();
			}
		}

		public HVector Clear()
		{
			this.ClearImpl();
			return this;
		}

		protected abstract HVector CloneImpl();

		object ICloneable.Clone()
		{
			return this.CloneImpl();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HVector Clone()
		{
			return this.CloneImpl();
		}

		protected virtual void DisposeLeafObject()
		{
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			if (this.mDimension > 0)
			{
				this.Clear();
				return;
			}
			this.DisposeLeafObject();
		}

		public override string ToString()
		{
			if (this.mDimension <= 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			for (int i = 0; i < this.Length; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(this[i].ToString());
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}
	}
}
