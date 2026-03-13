using System.Text.Json;
using iLoveBillBackend.Models;

namespace iLoveBillBackend.Services;

public class InvoiceService
{
    private readonly PythonService _pythonService;

    public InvoiceService(PythonService pythonService)
    {
        _pythonService = pythonService;
    }

    public InvoiceDTO JsonCheck(InvoiceDTO i)
    {
        string json = JsonSerializer.Serialize(i);
        Console.WriteLine(json);
        
        i.SUBTOTAL = 0.0;
        i.IVA = 0.0;
        i.TOTAL = 0.0;
        
        foreach (var p in i.Productos)
        {
            p.TOTAL = 0.0;
        }
        
        
        i.Id = new Random().Next(1, 10000).ToString();
        i.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
        
        return i;
    }
    
    public InvoiceDTO GenerarInvoice(InvoiceDTO i)
    {
        
        foreach(var p in i.Productos)
        {
            p.TOTAL += p.Cantidad * p.Precio;
            i.SUBTOTAL += p.TOTAL;
        }
        
        i.IVA = i.SUBTOTAL * (i.IVA_PORCENTAJE/100);
        i.TOTAL =  i.SUBTOTAL + i.IVA;
        
        return i;
    }
    
    public byte[] CrearPDF(InvoiceDTO i)
    {
        string json = JsonSerializer.Serialize(i);
        Console.WriteLine(json);
        return _pythonService.ScriptPdf(json);
    }
}