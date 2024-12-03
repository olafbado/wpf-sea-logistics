using System;
using System.Collections.Generic;

namespace pdab.Models.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TypeId { get; set; }
}
