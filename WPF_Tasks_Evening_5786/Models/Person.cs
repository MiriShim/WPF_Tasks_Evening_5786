using System;
using System.Collections.Generic;

namespace WPF_Tasks_Evening_5786.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
