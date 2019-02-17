using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageNS.MessageHandlers
{
    public class HandlerBrowserShortcuts : MessageBody
    {
        public override void ProcessMessage(byte[] received, int offset)
        {
            short broswerShortcut = BitConverter.ToInt16(received, offset);
            switch (broswerShortcut)
            {

                default:
                    BroswerShortcuts.NewTab();
                    break;
                case 1:
                    BroswerShortcuts.CloseTab();
                    break;
                case 2:
                    BroswerShortcuts.OpenClosedTab();
                    break;
                case 3:
                    BroswerShortcuts.AddressBar();
                    break;
                case 4:
                    BroswerShortcuts.NextTab();
                    break;
                case 5:
                    BroswerShortcuts.PreviousTab();
                    break;
            }
        }
    }
}
