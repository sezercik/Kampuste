using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kampus.Universities;

public class University : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
}