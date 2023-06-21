using System;

namespace SZXCArimEngine
{
	public class HDevEngineException : SZXCArimException
	{
		public enum ExceptionCategory
		{
			Generic,
			Input,
			Operator,
			File
		}

		private int halconError;

		private HDevEngineException.ExceptionCategory category;

		private string procedureName;

		private string lineText;

		private int lineNumber;

		private HTuple userData;

		public int HalconError
		{
			get
			{
				return this.halconError;
			}
		}

		public HDevEngineException.ExceptionCategory Category
		{
			get
			{
				return this.category;
			}
		}

		public string ProcedureName
		{
			get
			{
				return this.procedureName;
			}
		}

		public string LineText
		{
			get
			{
				return this.lineText;
			}
		}

		public int LineNumber
		{
			get
			{
				return this.lineNumber;
			}
		}

		public HTuple UserData
		{
			get
			{
				return this.userData;
			}
		}

		internal static void ThrowGeneric(string message)
		{
			HDevEngineException.ThrowGeneric(message, "");
		}

		internal static void ThrowGeneric(string message, string procedureName)
		{
			throw new HDevEngineException(2, HDevEngineException.ExceptionCategory.Generic, message, procedureName, "", 0, new HTuple());
		}

		internal static void ThrowLastException(int err)
		{
			int num;
			string message;
			string text;
			string text2;
			int num2;
			HTuple hTuple;
			int lastException = EngineAPI.GetLastException(out num, out message, out text, out text2, out num2, out hTuple);
			if (err != -1 && lastException == 2)
			{
				throw new HOperatorException(err);
			}
			throw new HDevEngineException(lastException, (HDevEngineException.ExceptionCategory)num, message, text, text2, num2, hTuple);
		}

		internal HDevEngineException(int halconError, HDevEngineException.ExceptionCategory category, string message, string procedureName, string lineText, int lineNumber, HTuple userData) : base(message)
		{
			this.halconError = halconError;
			this.category = category;
			this.procedureName = procedureName;
			this.lineText = lineText;
			this.lineNumber = lineNumber;
			this.userData = userData;
		}

		public override string ToString()
		{
			string text = "HDevEngine: " + this.Message;
			if (this.procedureName != "")
			{
				text = text + " in " + this.procedureName;
			}
			if (this.lineNumber > 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" at line ",
					this.lineNumber,
					" (",
					this.lineText,
					")"
				});
			}
			return text;
		}
	}
}
