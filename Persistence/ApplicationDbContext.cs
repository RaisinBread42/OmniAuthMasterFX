using Microsoft.EntityFrameworkCore;
using OmniAuthMasterFX.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using IdentityServer4.EntityFramework.Options;
using Microsoft.Extensions.Options;
using System.Threading;

namespace OmniAuthMasterFX.Persistence
{    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions
            ) : base(options, operationalStoreOptions)
        {
            // This context is here in the event that extension is needed to the current identity out-of-the-box solution by microsoft
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.Run( () => 1);
        }
    }
}
