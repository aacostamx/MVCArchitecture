using System;

namespace MVCArchitecture.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        Entities Init();
    }
}
