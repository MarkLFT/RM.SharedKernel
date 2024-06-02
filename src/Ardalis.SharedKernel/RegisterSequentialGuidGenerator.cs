using Microsoft.Extensions.DependencyInjection;
using RT.Comb;
using RT.Comb.AspNetCore;

namespace Ardalis.SharedKernel;
public static partial class ServiceCollectionExtensions
{
  public static IServiceCollection RegisterSequentialGuidGenerator(this IServiceCollection services)
  {
    var utcNoRepeatTimestampProvider = new UtcNoRepeatTimestampProvider();
    //ICombProvider SqlNoRepeatCombs = new SqlCombProvider(new UnixDateTimeStrategy(), customTimestampProvider: utcNoRepeatTimestampProvider.GetTimestamp);

    //services.AddSqlCombGuidWithUnixDateTime(customGuidProvider: SqlNoRepeatCombs);

    services.AddSqlCombGuidWithUnixDateTime(customTimestampProvider: () => utcNoRepeatTimestampProvider.GetTimestamp());
    services.AddSingleton<ISequentialGuidGenerator, SequentialGuidGenerator>();

    return services;
  }
}
