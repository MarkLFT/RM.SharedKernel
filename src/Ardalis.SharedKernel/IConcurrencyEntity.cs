using System.ComponentModel.DataAnnotations;

namespace Ardalis.SharedKernel;

public interface IConcurrencyEntity
{
  [Timestamp]
  public byte[] Version { get; set; }
}
