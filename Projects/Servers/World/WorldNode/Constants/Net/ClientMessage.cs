// Copyright (c) Arctium Emulation.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WorldNode.Constants.Net
{
    // Value '0x2000' means not updated/implemented
    public enum ClientMessage : ushort
    {
        LogoutRequest = 0x0C5E,
        RequestCemeteryList = 0x0957,
    }
}
