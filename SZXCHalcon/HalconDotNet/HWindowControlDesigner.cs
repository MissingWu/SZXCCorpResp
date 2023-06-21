using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SZXCArimEngine
{
	public class HWindowControlDesigner : ControlDesigner
	{
		private HWindowControl windowControl;

		public Bitmap LayoutBitmap
		{
			get
			{
				return null;
			}
			set
			{
				if (value != null)
				{

					MessageBox.Show("已取消该功能");

// 					SZXCArimWindowLayoutDialog SZXCArimWindowLayoutDialog = new SZXCArimWindowLayoutDialog(value.Size);
// 					SZXCArimWindowLayoutDialog.ShowDialog();
// 					if (!SZXCArimWindowLayoutDialog.resultCancel)
// 					{
// 						this.windowControl.WindowSize = new Size(value.Size.Width * SZXCArimWindowLayoutDialog.resultPercent / 100, value.Size.Height * SZXCArimWindowLayoutDialog.resultPercent / 100);
// 						this.windowControl.ImagePart = new Rectangle(Point.Empty, value.Size);
// 					}
				}
			}
		}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			this.windowControl = (HWindowControl)component;
		}

		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);
			Attribute[] attributes = new Attribute[]
			{
				CategoryAttribute.Layout,
				DesignOnlyAttribute.Yes,
				new DescriptionAttribute("This design-time property allows you to configure Size and ImagePart by providing a reference image of the desired size.")
			};
			properties["LayoutBitmap"] = TypeDescriptor.CreateProperty(typeof(HWindowControlDesigner), "LayoutBitmap", typeof(Bitmap), attributes);
			properties.Remove("BorderStyle");
		}
	}
}
