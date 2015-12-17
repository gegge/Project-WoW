// Copyright (c) Arctium Emulation.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using Framework.Attributes;
using Framework.Constants.Account;
using Framework.Cryptography.BNet;
using Framework.Database;
using Framework.Database.Auth.Entities;
using Framework.Logging;
using Framework.Misc;

namespace AuthServer.Commands
{
    class AccountCommands
    {
        [ConsoleCommand("CreateAccount", "")]
        public static void CreateAccount(string[] args)
        {
            var email = Command.Read<string>(args, 0);
            var password = Command.Read<string>(args, 1);

            if (email != null && password != null)
            {
                var salt = new byte[0].GenerateRandomKey(0x20).ToHexString();
                var result = DB.Auth.Any<Account>(a => a.Email == email);

                if (!result)
                {
                    var srp = new SRP6a(salt);

                    srp.CalculateX(email, password.ToUpper(), false);

                    var account = new Account
                    {
                        Email            = email,
                        PasswordVerifier = srp.V.ToHexString(),
                        Salt             = salt,
                        Region           = Region.XX,
                    };

                    if (DB.Auth.Add(account))
                        Log.Normal($"Account {email} successfully created.");
                }
                else
                    Log.Error($"Account {email} already in database.");
            }
        }

        [ConsoleCommand("CreateGameAccount", "")]
        public static void CreateGameAccount(string[] args)
        {
            var email = Command.Read<string>(args, 0);
            var game = Command.Read<string>(args, 1);
            var index = Command.Read<byte>(args, 2);

            if (email != "" && game != "" && index != 0)
            {
                var account = DB.Auth.Single<Account>(a => a.Email == email);

                if (account != null)
                {
                    var exists = account.GameAccounts?.Any(ga => ga.Game == game && ga.Index == index) ?? false;

                    if (!exists)
                    {
                        var gameAccount = new GameAccount
                        {
                            AccountId = account.Id,
                            Game      = game,
                            Index     = index,
                            Region    = Region.XX,
                            Flags     = GameAccountFlags.None,
                            BoxLevel  = 5
                        };

                        if (DB.Auth.Add(gameAccount))
                            Log.Normal($"GameAccount '{game}{index}' for Account '{email}' successfully created.");
                        else
                            Log.Error($"GameAccount creation '{game}{index}' for Account '{email}' failed.");
                    }
                    else
                        Log.Error($"GameAccount '{game}{index}' for Account '{email}' already in database.");
                }
                else
                    Log.Error($"Account {email}' doesn't exist.");
            }
        }
        
        [ConsoleCommand("DeleteAccount", "")]
        public static void DeleteAccount(string[] args)
        {
            var email = Command.Read<string>(args, 0);

            if (email != "")
            {
                var account = DB.Auth.Single<Account>(a => a.Email == email);

                if (account != null)
                {
                    if (DB.Auth.Delete(account))
                        Log.Normal($"Account '{account.Email}' successfully deleted.");
                    else
                        Log.Error($"Failed to delete account '{account.Email}'.");
                }
                else
                    Log.Error($"Account '{email}' doesn't exist.");
            }
        }

        [ConsoleCommand("IsOnline", "")]
        public static void IsOnline(string[] args)
        {
            var account = Command.Read<string>(args, 0);

            if (account != "")
            {
                DB.Auth.Where<GameAccount>(ga => ga.Game == account).ForEach(gameaccount => {
                    switch (gameaccount.IsOnline)
                    {
                        case false:
                            Log.Message("Offline");
                            break;
                        case true:
                            Log.Message("Online");
                            break;
                    }
                });
            }
        }
    }
}
