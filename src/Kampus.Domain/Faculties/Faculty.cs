using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kampus.Faculties;

public class Faculty : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
}