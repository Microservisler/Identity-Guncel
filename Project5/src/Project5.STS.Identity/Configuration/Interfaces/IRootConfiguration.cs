using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;

namespace Project5.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}







