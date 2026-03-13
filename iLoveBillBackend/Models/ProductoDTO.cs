using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace iLoveBillBackend.Models;
using System.Text.Json.Serialization;

public class ProductoDTO
{
    public string Nombre { get; set; }
    public Double Precio { get; set; }
    public int Cantidad { get; set; }
    public double TOTAL { get; set; } = 0.0;
}