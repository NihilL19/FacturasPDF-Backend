using System.Diagnostics;
using System.Text.Json;
using iLoveBillBackend.Models;

namespace iLoveBillBackend.Services;

public class PythonService
{

    // pasa json string, luego devuelve la ruta del archivo generado de python
    // para luego 
    public byte[] ScriptPdf(string json)
    {
        var rutaAbsoluta = Path.GetFullPath("Scripts");
    
        using var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(rutaAbsoluta, "myenv/bin/python"), //interprete de python
                ArgumentList = { "generar_pdf.py", json }, // argumentos para python
                WorkingDirectory = rutaAbsoluta, 
                RedirectStandardOutput = true,
                RedirectStandardError = true
            }
        };

        process.Start();
        string output = process.StandardOutput.ReadToEnd().Trim();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();
    
        return File.ReadAllBytes(Path.Combine(rutaAbsoluta, output));
    }
}