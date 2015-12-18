// Copyright (c) Arctium Emulation.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WorldNode.Constants.Net
{
    // Value '0x2000' means not updated/implemented
    enum ServerMessage : ushort
    {
        LogoutComplete = 0x0C7A,
        RequestCemeteryListResponse = 0x0E71,
    }
}
