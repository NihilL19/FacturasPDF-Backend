using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace iLoveBillBackend.Models;

public class InvoiceDTO
{
    public string? Id { get; set; }
    public string Empresa { get; set; }
    public string DireccionEmpresa { get; set; }
    
    public string Cliente { get; set; }
    public string DireccionCliente { get; set; }
    
    public string? Fecha { get; set; }
    
    public List<ProductoDTO> Productos { get; set; }
    
    public double SUBTOTAL { get; set; } = 0.0;
    
    public double IVA { get; set; } = 0.0;

    public double TOTAL { get; set; } = 0.0;
    
    public double IVA_PORCENTAJE { get; private set; } = 21.0;
}