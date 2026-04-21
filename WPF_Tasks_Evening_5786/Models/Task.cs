using System;
using System.Collections.Generic;

namespace WPF_Tasks_Evening_5786.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string Header { get; set; } = null!;

    public string? Description { get; set; }

    public int? EstimatedHours { get; set; }

    public int? ParentTaskId { get; set; }

    public int? PersonId { get; set; }

    public virtual ICollection<Task> InverseParentTask { get; set; } = new List<Task>();

    public virtual Task? ParentTask { get; set; }

    public virtual Person? Person { get; set; }
}
