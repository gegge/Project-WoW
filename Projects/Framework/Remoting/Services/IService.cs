﻿// Copyright (c) Arctium Emulation.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Concurrent;
using System.ServiceModel;
using Framework.Remoting.Objects;

namespace Framework.Remoting.Services
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        ConcurrentDictionary<uint, ServerInfoBase> Servers
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        ConcurrentDictionary<ulong, Tuple<uint, ulong>> Redirects
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        uint LastSessionId
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        [OperationContract]
        void Register(ServerInfoBase info);

        [OperationContract]
        void Update(ServerInfoBase info);

        [OperationContract(Name = "UpdateRedirects")]
        void Update(ulong key, Tuple<uint, ulong> data);

        [OperationContract]
        void Unregister(uint sessionId);

    }
}
