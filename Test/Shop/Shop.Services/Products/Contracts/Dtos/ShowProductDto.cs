﻿namespace Shop.Services.Products.Contracts.Dtos;

public class ShowProductDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int AvailableCount { get; set; }
}