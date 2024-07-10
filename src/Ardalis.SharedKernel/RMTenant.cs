using System.Diagnostics.CodeAnalysis;
using Finbuckle.MultiTenant;

namespace RM.SharedKernel;
public class RMTenant : ITenantInfo
{
  public RMTenant() { }

  public RMTenant([NotNull] string id, [NotNull] string identifier, [NotNull] string name, string? connectionString, string adminEmail, DateTime validUpTo)
  {
    Id = id;
    Identifier = identifier;
    Name = name;
    ConnectionString = connectionString;
    AdminEmail = adminEmail;
    ValidUpTo = validUpTo;
  }

  public string? Id { get; set; }
  public string? Identifier { get; set; }
  public string? Name { get; set; }
  public string? ConnectionString { get; set; }
  public string? AdminEmail { get; set; }
  public DateTime ValidUpTo { get; set; }
  public bool IsActive { get; set; }

}
