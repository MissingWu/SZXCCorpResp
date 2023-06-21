using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZXCVision
{
    public delegate void RunVoiceItem(string itemName);

    public class IEventSZXC
    {    
       static  public  RunVoiceItem RunVoiceItemEvent;
    }
}
