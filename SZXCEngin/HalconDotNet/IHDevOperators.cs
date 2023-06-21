using System;

namespace SZXCArimEngine
{
	public interface IHDevOperators
	{
		void DevOpenWindow(HTuple row, HTuple column, HTuple width, HTuple height, HTuple background, out HTuple windowHandle);

		void DevCloseWindow();

		void DevSetWindow(HTuple windowHandle);

		void DevGetWindow(out HTuple windowHandle);

		void DevSetWindowExtents(HTuple row, HTuple column, HTuple width, HTuple height);

		void DevSetPart(HTuple row1, HTuple column1, HTuple row2, HTuple column2);

		void DevClearWindow();

		void DevDisplay(HObject objectVal);

		void DevDispText(HTuple text, HTuple coordSystem, HTuple row, HTuple column, HTuple color, HTuple genParamNames, HTuple genParamValues);

		void DevSetDraw(HTuple drawMode);

		void DevSetContourStyle(HTuple style);

		void DevSetShape(HTuple shape);

		void DevSetColored(HTuple numColors);

		void DevSetColor(HTuple colorName);

		void DevSetLut(HTuple lutName);

		void DevSetPaint(HTuple mode);

		void DevSetLineWidth(HTuple lineWidth);
	}
}
