using System.Linq.Expressions;
using iLoveBillBackend.Models;
using iLoveBillBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iLoveBillBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        
        [HttpPost("PostInvoice")]
        public IActionResult Post(InvoiceDTO i)
        {
            var jsonFixed = _invoiceService.JsonCheck(i);
            var factura = _invoiceService.GenerarInvoice(jsonFixed);
            var PDF = _invoiceService.CrearPDF(factura);

            return File(PDF, "application/pdf", "factura.pdf");
        }
    }
}
