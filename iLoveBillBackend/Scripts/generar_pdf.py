import json
import sys
import jinja2
from weasyprint import CSS, HTML

def generar_pdf(json_string):
    data = json.loads(json_string)

    template_loader = jinja2.FileSystemLoader("./")
    template_env = jinja2.Environment(loader=template_loader)
    template = template_env.get_template("template.html")

    html_content = template.render(**data)

    HTML(string=html_content).write_pdf(
        "output.pdf",
        stylesheets=[CSS("template.css")]
    )

json_string = sys.argv[1]
print("./output.pdf")  # imprime el path del PDF generado
generar_pdf(json_string)