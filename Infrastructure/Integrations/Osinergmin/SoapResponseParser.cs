using Infrastructure.Integrations.Osinergmin.DTOs.Responses;
using System.Globalization;
using System.Xml;

namespace Energigas.Api.Osinergmin.Shared.Helpers
{
    public static class SoapResponseParser
    {
        private static string GetString(XmlNode node, string xpath)
            => node.SelectSingleNode(xpath)?.InnerText ?? string.Empty;

        private static decimal GetDecimal(XmlNode node, string xpath)
        {
            decimal.TryParse(node.SelectSingleNode(xpath)?.InnerText, out var value);
            return value;
        }

        private static DateTime? GetDate(XmlNode node, string xpath)
        {
            if (DateTime.TryParse(node.SelectSingleNode(xpath)?.InnerText, out var value))
                return value;

            return null;
        }

        private static DateTime? GetDate(XmlDocument doc, string xpath)
        {
            return DateTime.TryParseExact(
                doc.SelectSingleNode(xpath)?.InnerText,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var value)
                ? value
                : null;
        }

        private static decimal GetDecimal(XmlDocument doc, string xpath)
        {
            return decimal.TryParse(
                doc.SelectSingleNode(xpath)?.InnerText,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out var value)
                ? value
                : 0m;
        }

        private static int GetInt(XmlDocument doc, string xpath)
        {
            return int.TryParse(doc.SelectSingleNode(xpath)?.InnerText, out var value)
                ? value
                : 0;
        }

        private static string? GetString(XmlDocument doc, string xpath)
        {
            return doc.SelectSingleNode(xpath)?.InnerText;
        }

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

        public static SoapAttentionOrderResponseDto AttentionOrderParser(string content)
        {
            // Analiza el XML considerando el espacio de nombres
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(content);

            var nodes = xmlDocument.SelectNodes("//atencionOrdenesResponse");

            // Extrae valores específicos del XML
            var result = new SoapAttentionOrderResponseDto
            {
                CodigoAutorizacion = GetString(xmlDocument, "//codigoAutorizacion"),
                CodigoError = GetString(xmlDocument, "//codigoError"),
                Resultado = GetString(xmlDocument, "//resultado")
            };

            // Devuelve la respuesta como JSON
            return result;
        }

        public static SoapSimpleOrderResponseDto SimpleOrderParser(string content)
        {
            // Analiza el XML considerando el espacio de nombres
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(content);

            var nodes = xmlDocument.SelectNodes("//getOrdenPedidoByCodigoAutorizacionResponse");

            // Extrae valores específicos del XML
            var result = new SoapSimpleOrderResponseDto
            {
                API = GetString(xmlDocument, "//API"),
                CodigoAutorizacion = GetString(xmlDocument, "//codigoAutorizacion"),
                CodigoDGHCliente = GetString(xmlDocument, "//codigoDGHCliente"),
                CodigoEstado = GetString(xmlDocument, "//codigoEstado"),
                CodigoMayoristaEquivalente = GetString(xmlDocument, "//codigoMayoristaEquivalente"),
                CodigoPlantaEquivalente = GetString(xmlDocument, "//codigoPlantaEquivalente"),
                CodigoOsinergCliente = GetString(xmlDocument, "//codigoOsinergCliente"),
                DescripcionEstado = GetString(xmlDocument, "//descripcionEstado"),
                FechaCompra = GetDate(xmlDocument, "//fechaCompra"),
                FechaEntrega = GetDate(xmlDocument, "//fechaEntrega"),
                FechaFactura = GetDate(xmlDocument, "//fechaFactura"),
                FechaModificacion = GetDate(xmlDocument, "//fechaModificacion"),
                FechaRegistro = GetDate(xmlDocument, "//fechaRegistro"),
                FechaVenta = GetDate(xmlDocument, "//fechaVenta"),
                FormaVenta = GetString(xmlDocument, "//formaVenta"),
                HoraModificacion = GetString(xmlDocument, "//horaModificacion"),
                HoraRegistro = GetString(xmlDocument, "//horaRegistro"),
                HoraVenta = GetString(xmlDocument, "//horaVenta"),
                NumeroFactura = GetString(xmlDocument, "//numeroFactura"),
                NumeroGuia = GetString(xmlDocument, "//numeroGuia"),
                OrdenPedido = GetString(xmlDocument, "//ordenPedido"),
                PlacaTransporte = GetString(xmlDocument, "//placaTransporte"),
                RucComprador = GetString(xmlDocument, "//rucComprador"),
                VolumenSolicitado = GetDecimal(xmlDocument, "//volumenSolicitado"),
                VolumenVenta = GetDecimal(xmlDocument, "//volumenVenta"),
                Detalles = xmlDocument
                    .SelectNodes("//detalles")
                    .Cast<XmlNode>()
                    .Select(x => new SoapSimpleOrderDetailResponseDto
                    {
                        Cantidad1 = GetDecimal(x, "cantidad1"),
                        Cantidad2 = GetDecimal(x, "cantidad2"),
                        CantidadDespachada = GetDecimal(x, "cantidadDespachada"),
                        CantidadSolicitada = GetDecimal(x, "cantidadSolicitada"),
                        CantidadVendida = GetDecimal(x, "cantidadVendida"),
                        CodigoEstado = GetString(x, "codigoEstado"),
                        CodigoMotivoRechazo = GetString(x, "codigoMotivoRechazo"),
                        CodigoProducto = GetString(x, "codigoProducto"),
                        DensidadObservada = GetDecimal(x, "densidadObservada"),
                        DetallePedido = GetString(x, "detallePedido"),
                        FactorAPI = GetDecimal(x, "factorAPI"),
                        FactorApor = GetDecimal(x, "factorApor"),
                        FactorComp = GetDecimal(x, "factorComp"),
                        PlacaTransporte = GetString(x, "placaTransporte"),
                        Precio = GetDecimal(x, "precio"),
                        PrecioGalon = GetDecimal(x, "precioGalon"),
                        Temperatura = GetDecimal(x, "temperatura"),
                    }).ToList()
            };

            // Devuelve la respuesta como JSON
            return result;
        }

    }
}
