using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HMatrix : HHandle, ISerializable, ICloneable
	{
		public double this[int row, int column]
		{
			get
			{
				return this.GetValueMatrix(row, column);
			}
			set
			{
				this.SetValueMatrix(row, column, value);
			}
		}

		public int NumRows
		{
			get
			{
				int result;
				int num;
				this.GetSizeMatrix(out result, out num);
				return result;
			}
		}

		public int NumColumns
		{
			get
			{
				int num;
				int result;
				this.GetSizeMatrix(out num, out result);
				return result;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMatrix() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMatrix(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMatrix(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("matrix");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMatrix obj)
		{
			obj = new HMatrix(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMatrix[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HMatrix[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HMatrix(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HMatrix(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(842);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMatrix(int rows, int columns, HTuple value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(897);
			SZXCArimAPI.StoreI(proc, 0, rows);
			SZXCArimAPI.StoreI(proc, 1, columns);
			SZXCArimAPI.Store(proc, 2, value);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(value);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMatrix(int rows, int columns, double value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(897);
			SZXCArimAPI.StoreI(proc, 0, rows);
			SZXCArimAPI.StoreI(proc, 1, columns);
			SZXCArimAPI.StoreD(proc, 2, value);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeMatrix();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMatrix(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeMatrix(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeMatrix();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HMatrix Deserialize(Stream stream)
		{
			HMatrix arg_0C_0 = new HMatrix();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeMatrix(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HMatrix Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeMatrix();
			HMatrix expr_0C = new HMatrix();
			expr_0C.DeserializeMatrix(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static HMatrix operator -(HMatrix matrix)
		{
			return matrix.ScaleMatrix(-1.0);
		}

		public static HMatrix operator +(HMatrix matrix1, HMatrix matrix2)
		{
			return matrix1.AddMatrix(matrix2);
		}

		public static HMatrix operator -(HMatrix matrix1, HMatrix matrix2)
		{
			return matrix1.SubMatrix(matrix2);
		}

		public static HMatrix operator *(HMatrix matrix1, HMatrix matrix2)
		{
			return matrix1.MultMatrix(matrix2, "AB");
		}

		public static HMatrix operator *(double factor, HMatrix matrix)
		{
			return matrix.ScaleMatrix(factor);
		}

		public static HMatrix operator *(HMatrix matrix, double factor)
		{
			return matrix.ScaleMatrix(factor);
		}

		public static HMatrix operator /(HMatrix matrix1, HMatrix matrix2)
		{
			return matrix2.SolveMatrix("general", 0.0, matrix1);
		}

		public void DeserializeMatrix(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(840);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeMatrix()
		{
			IntPtr proc = SZXCArimAPI.PreCall(841);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadMatrix(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(842);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteMatrix(string fileFormat, string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(843);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileFormat);
			SZXCArimAPI.StoreS(proc, 2, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HMatrix OrthogonalDecomposeMatrix(string decompositionType, string outputMatricesType, string computeOrthogonal, out HMatrix matrixTriangularID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(844);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, decompositionType);
			SZXCArimAPI.StoreS(proc, 2, outputMatricesType);
			SZXCArimAPI.StoreS(proc, 3, computeOrthogonal);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			num = HMatrix.LoadNew(proc, 1, num, out matrixTriangularID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix DecomposeMatrix(string matrixType, out HMatrix matrix2ID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(845);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, matrixType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			num = HMatrix.LoadNew(proc, 1, num, out matrix2ID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix SvdMatrix(string SVDType, string computeSingularVectors, out HMatrix matrixSID, out HMatrix matrixVID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(846);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, SVDType);
			SZXCArimAPI.StoreS(proc, 2, computeSingularVectors);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			num = HMatrix.LoadNew(proc, 1, num, out matrixSID);
			num = HMatrix.LoadNew(proc, 2, num, out matrixVID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GeneralizedEigenvaluesGeneralMatrix(HMatrix matrixBID, string computeEigenvectors, out HMatrix eigenvaluesRealID, out HMatrix eigenvaluesImagID, out HMatrix eigenvectorsRealID, out HMatrix eigenvectorsImagID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(847);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			SZXCArimAPI.StoreS(proc, 2, computeEigenvectors);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HMatrix.LoadNew(proc, 0, num, out eigenvaluesRealID);
			num = HMatrix.LoadNew(proc, 1, num, out eigenvaluesImagID);
			num = HMatrix.LoadNew(proc, 2, num, out eigenvectorsRealID);
			num = HMatrix.LoadNew(proc, 3, num, out eigenvectorsImagID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
		}

		public HMatrix GeneralizedEigenvaluesSymmetricMatrix(HMatrix matrixBID, string computeEigenvectors, out HMatrix eigenvectorsID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(848);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			SZXCArimAPI.StoreS(proc, 2, computeEigenvectors);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			num = HMatrix.LoadNew(proc, 1, num, out eigenvectorsID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
			return result;
		}

		public void EigenvaluesGeneralMatrix(string computeEigenvectors, out HMatrix eigenvaluesRealID, out HMatrix eigenvaluesImagID, out HMatrix eigenvectorsRealID, out HMatrix eigenvectorsImagID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(849);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, computeEigenvectors);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HMatrix.LoadNew(proc, 0, num, out eigenvaluesRealID);
			num = HMatrix.LoadNew(proc, 1, num, out eigenvaluesImagID);
			num = HMatrix.LoadNew(proc, 2, num, out eigenvectorsRealID);
			num = HMatrix.LoadNew(proc, 3, num, out eigenvectorsImagID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMatrix EigenvaluesSymmetricMatrix(string computeEigenvectors, out HMatrix eigenvectorsID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(850);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, computeEigenvectors);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			num = HMatrix.LoadNew(proc, 1, num, out eigenvectorsID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix SolveMatrix(string matrixLHSType, double epsilon, HMatrix matrixRHSID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(851);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, matrixLHSType);
			SZXCArimAPI.StoreD(proc, 2, epsilon);
			SZXCArimAPI.Store(proc, 3, matrixRHSID);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixRHSID);
			return result;
		}

		public double DeterminantMatrix(string matrixType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(852);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, matrixType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void InvertMatrixMod(string matrixType, double epsilon)
		{
			IntPtr proc = SZXCArimAPI.PreCall(853);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, matrixType);
			SZXCArimAPI.StoreD(proc, 2, epsilon);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HMatrix InvertMatrix(string matrixType, double epsilon)
		{
			IntPtr proc = SZXCArimAPI.PreCall(854);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, matrixType);
			SZXCArimAPI.StoreD(proc, 2, epsilon);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void TransposeMatrixMod()
		{
			IntPtr proc = SZXCArimAPI.PreCall(855);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HMatrix TransposeMatrix()
		{
			IntPtr proc = SZXCArimAPI.PreCall(856);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix MaxMatrix(string maxType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(857);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, maxType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix MinMatrix(string minType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(858);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, minType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void PowMatrixMod(string matrixType, HTuple power)
		{
			IntPtr proc = SZXCArimAPI.PreCall(859);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, matrixType);
			SZXCArimAPI.Store(proc, 2, power);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(power);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void PowMatrixMod(string matrixType, double power)
		{
			IntPtr proc = SZXCArimAPI.PreCall(859);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, matrixType);
			SZXCArimAPI.StoreD(proc, 2, power);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HMatrix PowMatrix(string matrixType, HTuple power)
		{
			IntPtr proc = SZXCArimAPI.PreCall(860);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, matrixType);
			SZXCArimAPI.Store(proc, 2, power);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(power);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix PowMatrix(string matrixType, double power)
		{
			IntPtr proc = SZXCArimAPI.PreCall(860);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, matrixType);
			SZXCArimAPI.StoreD(proc, 2, power);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void PowElementMatrixMod(HMatrix matrixExpID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(861);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixExpID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixExpID);
		}

		public HMatrix PowElementMatrix(HMatrix matrixExpID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(862);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixExpID);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixExpID);
			return result;
		}

		public void PowScalarElementMatrixMod(HTuple power)
		{
			IntPtr proc = SZXCArimAPI.PreCall(863);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, power);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(power);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void PowScalarElementMatrixMod(double power)
		{
			IntPtr proc = SZXCArimAPI.PreCall(863);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, power);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HMatrix PowScalarElementMatrix(HTuple power)
		{
			IntPtr proc = SZXCArimAPI.PreCall(864);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, power);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(power);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix PowScalarElementMatrix(double power)
		{
			IntPtr proc = SZXCArimAPI.PreCall(864);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, power);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SqrtMatrixMod()
		{
			IntPtr proc = SZXCArimAPI.PreCall(865);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HMatrix SqrtMatrix()
		{
			IntPtr proc = SZXCArimAPI.PreCall(866);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AbsMatrixMod()
		{
			IntPtr proc = SZXCArimAPI.PreCall(867);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HMatrix AbsMatrix()
		{
			IntPtr proc = SZXCArimAPI.PreCall(868);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double NormMatrix(string normType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(869);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, normType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix MeanMatrix(string meanType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(870);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, meanType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix SumMatrix(string sumType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(871);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, sumType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DivElementMatrixMod(HMatrix matrixBID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(872);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
		}

		public HMatrix DivElementMatrix(HMatrix matrixBID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(873);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
			return result;
		}

		public void MultElementMatrixMod(HMatrix matrixBID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(874);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
		}

		public HMatrix MultElementMatrix(HMatrix matrixBID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(875);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
			return result;
		}

		public void ScaleMatrixMod(HTuple factor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(876);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, factor);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(factor);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ScaleMatrixMod(double factor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(876);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, factor);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HMatrix ScaleMatrix(HTuple factor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(877);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, factor);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(factor);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix ScaleMatrix(double factor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(877);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, factor);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SubMatrixMod(HMatrix matrixBID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(878);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
		}

		public HMatrix SubMatrix(HMatrix matrixBID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(879);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
			return result;
		}

		public void AddMatrixMod(HMatrix matrixBID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(880);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
		}

		public HMatrix AddMatrix(HMatrix matrixBID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(881);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
			return result;
		}

		public void MultMatrixMod(HMatrix matrixBID, string multType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(882);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			SZXCArimAPI.StoreS(proc, 2, multType);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
		}

		public HMatrix MultMatrix(HMatrix matrixBID, string multType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(883);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixBID);
			SZXCArimAPI.StoreS(proc, 2, multType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixBID);
			return result;
		}

		public void GetSizeMatrix(out int rows, out int columns)
		{
			IntPtr proc = SZXCArimAPI.PreCall(884);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out rows);
			num = SZXCArimAPI.LoadI(proc, 1, num, out columns);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMatrix RepeatMatrix(int rows, int columns)
		{
			IntPtr proc = SZXCArimAPI.PreCall(885);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, rows);
			SZXCArimAPI.StoreI(proc, 2, columns);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HMatrix CopyMatrix()
		{
			IntPtr proc = SZXCArimAPI.PreCall(886);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetDiagonalMatrix(HMatrix vectorID, int diagonal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(887);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, vectorID);
			SZXCArimAPI.StoreI(proc, 2, diagonal);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(vectorID);
		}

		public HMatrix GetDiagonalMatrix(int diagonal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(888);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, diagonal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetSubMatrix(HMatrix matrixSubID, int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(889);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, matrixSubID);
			SZXCArimAPI.StoreI(proc, 2, row);
			SZXCArimAPI.StoreI(proc, 3, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(matrixSubID);
		}

		public HMatrix GetSubMatrix(int row, int column, int rowsSub, int columnsSub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(890);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, rowsSub);
			SZXCArimAPI.StoreI(proc, 4, columnsSub);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HMatrix result;
			num = HMatrix.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetFullMatrix(HTuple values)
		{
			IntPtr proc = SZXCArimAPI.PreCall(891);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, values);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(values);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetFullMatrix(double values)
		{
			IntPtr proc = SZXCArimAPI.PreCall(891);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, values);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetFullMatrix()
		{
			IntPtr proc = SZXCArimAPI.PreCall(892);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetValueMatrix(HTuple row, HTuple column, HTuple value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(893);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.Store(proc, 3, value);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(value);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetValueMatrix(int row, int column, double value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(893);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.StoreD(proc, 3, value);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetValueMatrix(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(894);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double GetValueMatrix(int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(894);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void ClearMatrix(HMatrix[] matrixID)
		{
			HTuple hTuple = HHandleBase.ConcatArray(matrixID);
			IntPtr expr_13 = SZXCArimAPI.PreCall(896);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(matrixID);
		}

		public void ClearMatrix()
		{
			IntPtr proc = SZXCArimAPI.PreCall(896);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateMatrix(int rows, int columns, HTuple value)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(897);
			SZXCArimAPI.StoreI(proc, 0, rows);
			SZXCArimAPI.StoreI(proc, 1, columns);
			SZXCArimAPI.Store(proc, 2, value);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(value);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateMatrix(int rows, int columns, double value)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(897);
			SZXCArimAPI.StoreI(proc, 0, rows);
			SZXCArimAPI.StoreI(proc, 1, columns);
			SZXCArimAPI.StoreD(proc, 2, value);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
