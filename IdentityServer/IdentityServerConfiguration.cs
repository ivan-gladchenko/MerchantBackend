using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class IdentityServerConfiguration
    {
        public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
            {
                ClientId = "wallet_server_client",
                ClientSecrets = new List<Secret>{new Secret("secret_key".ToSha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "WalletServer",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                RedirectUris = {"http://localhost:5000/signin-oidc"},
                AlwaysIncludeUserClaimsInIdToken = true,
            },
            new Client
            {
                ClientId = "web_client",
                ClientSecrets = new List<Secret>{new Secret("client_secret_key".ToSha256())},
                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes =
                {
                    "WalletServer",
                    "ClientPanel",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                RedirectUris = {"http://localhost:5050/signin-oidc"},
                AlwaysIncludeUserClaimsInIdToken = true,
            },
            new Client
            {
                ClientId = "web_admin",
                ClientSecrets = new List<Secret>{new Secret("admin_secret_key".ToSha256())},
                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes =
                {
                    "WalletServer",
                    "AdminPanel",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                RedirectUris = {"http://localhost:5078/signin-oidc"},
                AlwaysIncludeUserClaimsInIdToken = true,
            }
        };

        public static IEnumerable<ApiScope> GetApiScopes() =>
        new List<ApiScope>
        {
            new ApiScope("WalletServer"),
            new ApiScope("AdminPanel"),
            new ApiScope("ClientPanel")
        };

        public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
            new ApiResource
            {
                Name = "WalletServerResource",
                Scopes = new List<string>
                {
                    "WalletServer",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },
            new ApiResource
            {
                Name = "AdminResource",
                Scopes = new List<string>
                {
                    "AdminPanel",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },
            new ApiResource
            {
                Name = "ClientResource",
                UserClaims = {JwtClaimTypes.Name},
                Scopes = new List<string>
                {
                    "ClientPanel",
                    "WalletServer",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }
}
