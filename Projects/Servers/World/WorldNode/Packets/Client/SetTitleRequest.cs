using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Network.Packets;

namespace WorldNode.Packets.Client
{
    public class SetTitleRequest : ClientPacket
    {
        public UInt32 TitleID { get; set; }
        public override void Read()
        {
            
        }
    }
}
