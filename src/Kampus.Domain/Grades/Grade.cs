using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kampus.Grades;

public class Grade : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
}