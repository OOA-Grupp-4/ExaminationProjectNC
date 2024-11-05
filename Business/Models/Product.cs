﻿namespace Business.Models;

public class Product
{
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
