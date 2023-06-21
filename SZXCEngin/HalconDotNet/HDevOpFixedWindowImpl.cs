using System;

namespace SZXCArimEngine
{
	public class HDevOpFixedWindowImpl : IHDevOperators, IDisposable
	{
		protected HTuple activeID;

		public HDevOpFixedWindowImpl(HTuple windowID)
		{
			if (windowID == null)
			{
				HDevEngineException.ThrowGeneric("Window handle not initialized");
			}
			if (windowID.Type != HTupleType.HANDLE && windowID.Type != HTupleType.LONG && windowID.Type != HTupleType.INTEGER)
			{
				HDevEngineException.ThrowGeneric("Invalid tuple tpye");
			}
			if (windowID.Length != 1)
			{
				HDevEngineException.ThrowGeneric("Please specify exactly one window ID");
			}
			this.activeID = new HTuple(windowID);
		}

		public HDevOpFixedWindowImpl(HWindow window)
		{
			if (window == HHandleBase.UNDEF)
			{
				HDevEngineException.ThrowGeneric("Window handle not initialized");
			}
			this.activeID = new HTuple(window);
		}

		public virtual void Dispose()
		{
			this.activeID.Dispose();
		}

		public virtual void DevOpenWindow(HTuple row, HTuple column, HTuple width, HTuple height, HTuple background, out HTuple windowID)
		{
			this.DevGetWindow(out windowID);
		}

		public virtual void DevSetWindow(HTuple windowHandle)
		{
		}

		public virtual void DevGetWindow(out HTuple windowHandle)
		{
			if (SZXCArimAPI.IsLegacyHandleMode())
			{
				windowHandle = this.activeID.L;
				return;
			}
			windowHandle = new HTuple(this.activeID);
		}

		public virtual void DevCloseWindow()
		{
		}

		public virtual void DevSetWindowExtents(HTuple row, HTuple column, HTuple width, HTuple height)
		{
		}

		public virtual void DevSetPart(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			HOperatorSet.SetPart(this.activeID, row1, column1, row2, column2);
		}

		public virtual void DevClearWindow()
		{
			HOperatorSet.ClearWindow(this.activeID);
		}

		public virtual void DevDisplay(HObject obj)
		{
			HOperatorSet.DispObj(obj, this.activeID);
		}

		public virtual void DevDispText(HTuple text, HTuple coordSystem, HTuple row, HTuple column, HTuple color, HTuple genParamName, HTuple genParamValue)
		{
			HOperatorSet.DispText(this.activeID, text, coordSystem, row, column, color, genParamName, genParamValue);
		}

		public virtual void DevSetDraw(HTuple drawMode)
		{
			HOperatorSet.SetDraw(this.activeID, drawMode);
		}

		public virtual void DevSetContourStyle(HTuple style)
		{
			HOperatorSet.SetContourStyle(this.activeID, style);
		}

		public virtual void DevSetShape(HTuple shape)
		{
			HOperatorSet.SetShape(this.activeID, shape);
		}

		public virtual void DevSetColored(HTuple numColors)
		{
			HOperatorSet.SetColored(this.activeID, numColors);
		}

		public virtual void DevSetColor(HTuple colorName)
		{
			HOperatorSet.SetColor(this.activeID, colorName);
		}

		public virtual void DevSetLut(HTuple lutName)
		{
			HOperatorSet.SetLut(this.activeID, lutName);
		}

		public virtual void DevSetPaint(HTuple mode)
		{
			HOperatorSet.SetPaint(this.activeID, mode);
		}

		public virtual void DevSetLineWidth(HTuple lineWidth)
		{
			HOperatorSet.SetLineWidth(this.activeID, lineWidth);
		}
	}
}
