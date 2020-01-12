using AdvertApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdvertApi.HealthChecks
{
    public class StorageHealthCheck : Microsoft.Extensions.HealthChecks.IHealthCheck
    {
        private readonly IAdvertStorageService advertStorageService;

        public async ValueTask<Microsoft.Extensions.HealthChecks.IHealthCheckResult> CheckAsync(CancellationToken cancellationToken = default)
        {
            var isStorageOk = await advertStorageService.CheckHealthAsync();
            return Microsoft.Extensions.HealthChecks.HealthCheckResult.FromStatus(isStorageOk ? Microsoft.Extensions.HealthChecks.CheckStatus.Healthy : Microsoft.Extensions.HealthChecks.CheckStatus.Unhealthy, "");
        }
    }
}
