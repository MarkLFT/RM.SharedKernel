using System.Diagnostics.CodeAnalysis;
using Finbuckle.MultiTenant.Abstractions;

namespace RM.SharedKernel;
public class RMTenant : ITenantInfo
{
  public RMTenant() { }

  public RMTenant([NotNull] string id, [NotNull] string identifier, [NotNull] string name, string? connectionString)
  {
    Id = id;
    Identifier = identifier;
    Name = name;
    ConnectionString = connectionString;
  }

  public string? Id { get; set; }
  public string? Identifier { get; set; }
  public string? Name { get; set; }
  public string? ConnectionString { get; set; }

}
