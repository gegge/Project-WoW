using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Network.Packets;
using Framework.Misc;
using WorldNode.Constants.Net;

namespace WorldNode.Packets.Server
{
    class RequestCemeteryListResponse : ServerPacket
    {
        public bool IsGossipTriggered { get; set; }
        public UInt32 Count { get; set; }
        public UInt32[] CemeteryID { get; set; }

        public RequestCemeteryListResponse() : base(ServerMessage.RequestCemeteryListResponse) { }

        public override void Write()
        {
            Packet.PutBit(IsGossipTriggered);
            Packet.FlushBits();

            Packet.Write<UInt32>(Count);
            for(int i = 0; i < CemeteryID.Length; i++)
                Packet.Write<UInt32>(CemeteryID[i]);
        }
    }
}
