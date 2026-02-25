using Energigas.Api.Osinergmin.Application.DTOs;
using System.Xml;

namespace Energigas.Api.Osinergmin.Shared.Helpers
{
    public static class SoapResponseParser
    {
        public static SoapPurchaseOrderResponseDto SimplePurchaseOrderParser(string content) 
        {
            // Analiza el XML considerando el espacio de nombres
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(content);

            var nodes = xmlDocument.SelectNodes("//generateSimpleOrderResponse");

            // Extrae valores específicos del XML
            var result = nodes.OfType<XmlNode>().Select(node => new SoapPurchaseOrderResponseDto
            {
                claveUsuario = xmlDocument.SelectSingleNode("//claveUsuario")?.InnerText,
                codigoAutorizacion = xmlDocument.SelectSingleNode("//codigoAutorizacion")?.InnerText,
                codigoError = xmlDocument.SelectSingleNode("//codigoError")?.InnerText,
                codigoUsuario = xmlDocument.SelectSingleNode("//codigoUsuario")?.InnerText,
                fechaFin = xmlDocument.SelectSingleNode("//fechaFin")?.InnerText,
                fechaInicio = xmlDocument.SelectSingleNode("//fechaInicio")?.InnerText,
                fechaRegistro = xmlDocument.SelectSingleNode("//fechaRegistro")?.InnerText,
                fechaVenta = xmlDocument.SelectSingleNode("//fechaVenta")?.InnerText,
                horaFin = xmlDocument.SelectSingleNode("//horaFin")?.InnerText,
                horaInicio = xmlDocument.SelectSingleNode("//horaInicio")?.InnerText,
                horaRegistro = xmlDocument.SelectSingleNode("//horaRegistro")?.InnerText,
                idDetalleDivision1 = xmlDocument.SelectSingleNode("//idDetalleDivision1")?.InnerText,
                idDetalleDivision2 = xmlDocument.SelectSingleNode("//idDetalleDivision2")?.InnerText,
                loginUsuario = xmlDocument.SelectSingleNode("//loginUsuario")?.InnerText,
                placaTransporte = xmlDocument.SelectSingleNode("//placaTransporte")?.InnerText,
                resultado = xmlDocument.SelectSingleNode("//resultado")?.InnerText,
                ruc = xmlDocument.SelectSingleNode("//ruc")?.InnerText,
                tipoUsuario = xmlDocument.SelectSingleNode("//tipoUsuario")?.InnerText
            }).ToList();

            // Devuelve la respuesta como JSON
            return result.FirstOrDefault();

        }
    }
}
