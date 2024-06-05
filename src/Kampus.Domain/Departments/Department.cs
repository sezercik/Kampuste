using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kampus.Departments;

public class Department : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
}