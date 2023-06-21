using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class SZXCArimException : ApplicationException
	{
		private int err;

		private HTuple user_data;

		private const int ErrCodeUserException = 30000;

		public SZXCArimException(int err, string sInfo, Exception inner) : this(sInfo, inner)
		{
			this.err = err;
		}

		public SZXCArimException(int err, string sInfo) : this(err, sInfo, null)
		{
		}

		public SZXCArimException(string sInfo, Exception inner)
		{
			this.err = 2;
			//base..ctor(sInfo, inner);
			this.err = -1;
		}

		public SZXCArimException(string sInfo)
		{
			this.err = 2;
			//base..ctor(sInfo);
			this.err = -1;
		}

		public SZXCArimException()
		{
			this.err = 2;
			//base..ctor();
			this.err = -1;
		}

		public SZXCArimException(HTuple tuple) : this(tuple[0], tuple[1].O.ToString())
		{
			int num = 2;
			if (this.err >= 30000)
			{
				num = 1;
			}
			if (num <= tuple.TupleLength() - 1)
			{
				this.user_data = tuple.TupleSelectRange(num, tuple.TupleLength() - 1);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never), Obsolete("GetErrorNumber is deprecated, please use GetErrorCode instead.")]
		public int GetErrorNumber()
		{
			return this.err;
		}

		public int GetErrorCode()
		{
			return this.err;
		}

		public void ToHTuple(out HTuple exception)
		{
			exception = new HTuple();
			exception[0] = this.GetErrorCode();
			if ((long)this.GetErrorCode() < 30000L)
			{
				exception[1] = this.GetErrorMessage();
			}
			if (this.user_data != null)
			{
				exception = exception.TupleConcat(this.user_data);
			}
		}

		public static void GetExceptionData(HTuple exception, HTuple name, out HTuple value)
		{
			value = new HTuple();
			bool flag = exception.TupleLength() > 0 && exception[0].Type == HTupleType.INTEGER && exception[0].I >= 30000;
			int num = name.TupleLength();
			for (int i = 0; i < num; i++)
			{
				if (name[i].Type != HTupleType.STRING)
				{
					throw new HOperatorException(0, "HOperatorException.GetExceptionData(): wrong type of input parameter 'name'.");
				}
				string s = name[i].S;
				int num2;
				if (s == "error_code")
				{
					num2 = 0;
				}
				else if (s == "add_error_code")
				{
					num2 = -1;
				}
				else if (s == "user_data")
				{
					if (num != 1)
					{
						value = new HTuple();
						throw new HOperatorException(0, "HOperatorException.GetExceptionData(): slot 'user_data' onparameter 'Name' cannot be requested together with other slots.");
					}
					if (flag)
					{
						num2 = 1;
					}
					else
					{
						num2 = 2;
					}
					if (num2 <= exception.TupleLength() - 1)
					{
						value = value.TupleConcat(exception.TupleSelectRange(num2, exception.TupleLength() - 1));
						return;
					}
					break;
				}
				else if (s == "error_msg" || s == "error_message")
				{
					num2 = 1;
				}
				else if (s == "add_error_msg" || s == "add_error_message")
				{
					num2 = -1;
				}
				else if (s == "proc_line" || s == "program_line")
				{
					num2 = -1;
				}
				else if (s == "operator")
				{
					num2 = -1;
				}
				else if (s == "call_stack_depth")
				{
					num2 = -1;
				}
				else
				{
					if (!(s == "procedure"))
					{
						value = new HTuple();
						throw new HOperatorException(0, "HOperatorException.GetExceptionData(): wrong value of input parameter 'name'.");
					}
					num2 = -1;
				}
				if (num2 == -1)
				{
					value = value.TupleConcat("");
				}
				else if (flag && num2 != 0)
				{
					value = value.TupleConcat("User defined exception");
				}
				else
				{
					value = value.TupleConcat(exception[num2]);
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never), Obsolete("GetErrorText is deprecated, please use GetErrorMessage instead.")]
		public string GetErrorText()
		{
			return this.Message;
		}

		public string GetErrorMessage()
		{
			return this.Message;
		}
	}
}
