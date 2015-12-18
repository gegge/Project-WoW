using Framework.Constants.Account;
using WorldNode.Network;
using WorldNode.Attributes;
using WorldNode.Constants.Net;
using WorldNode.Packets.Client;
using WorldNode.Packets.Server;

namespace WorldNode.Packets.Handlers
{
    class MiscHandler
    {
        [Message(ClientMessage.RequestCemeteryList, SessionState.All)]
        public static /*async*/ void HandleRequestCemeteryList(RequestCemeteryList CemeteryList, NodeSession session)
        {
            //TODO 
            //Get Player team and ZoneID, get list of all graveyards in that ZoneID. If list empty, throw error else Write the RequestCemeteryListResponse packet.
            //await session.Send(new RequestCemeteryListResponse { IsGossipTriggered = false, Count = 0 });
        }

        [Message(ClientMessage.SetTitle, SessionState.All)]
        public static void HandleSetTitle(SetTitleRequest title, NodeSession session)
        {
            session.Player.PlayerData.PlayerTitle.Value = title.TitleID;
        }
    }
}
