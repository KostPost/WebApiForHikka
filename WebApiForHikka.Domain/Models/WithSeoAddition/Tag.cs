﻿namespace WebApiForHikka.Domain.Models.WithSeoAddition;

public class Tag : ModelWithSeoAddition
{

    public required string Name { get; set; }
    public required string EngName { get; set; }
    public required List<string> Alises { get; set; }
    public required bool IsGenre { get; set; }

    public virtual Tag? ParentTag { get; set; }

    public virtual ICollection<Tag>? Tags { get; set; }
}