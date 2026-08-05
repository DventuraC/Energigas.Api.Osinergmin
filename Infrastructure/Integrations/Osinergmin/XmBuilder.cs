using Infrastructure.Integrations.Osinergmin.DTOs.Requests;
using System.Xml.Linq;

namespace Infrastructure.Integrations.Osinergmin
{
    public static class XmBuilder
    {
        public static XElement GenerateSimpleOrderXml(SoapPurchaseOrderRequestDto order)
        {
            var xml = new XElement("ordenPedido",
                new XElement("loginUsuario", order.loginUsuario),
                new XElement("claveUsuario", order.claveUsuario),
                new XElement("tipoTransaccion", order.tipoTransaccion),
                new XElement("codigoMayoristaEquivalente", order.codigoMayoristaEquivalente),
                new XElement("codigoPlantaEquivalente", order.codigoPlantaEquivalente),
                new XElement("placaTransporte", order.placaTransporte ?? string.Empty), //OPCIONAL
                new XElement("fechaEntrega", order.fechaEntrega.ToString("dd/MM/yyyy")),
                new XElement("cola", order.cola ?? string.Empty) //OPCIONAL
                );

            foreach (var detail in order.detalles)
            {
                var detailElement = new XElement("detalles",
                    new XElement("codigoProducto", detail.codigoProducto),
                    new XElement("cantidadSolicitada", detail.cantidadSolicitada)
                );
                xml.Add(detailElement);
            }

            return xml;
        }

        public static XElement GetSimpleOrderByScopXml(SoapGetOrderByScopRequestDto request)
        {
            var xml = new XElement("parametro",
                new XElement("loginUsuario", request.loginUsuario ),
                new XElement("claveUsuario", request.claveUsuario),
                new XElement("codigoAutorizacion", request.codigoAutorizacion)
            );
            return xml;
        }

        public static XElement AttentionOrderXml(SoapAttentionOrderRequestDto request)
        {
            var details = request.detalles.Select(x =>
                new XElement("detalles",
                    new XElement("detallePedido", x.detallePedido),
                    new XElement("codigoProducto", x.codigoProducto),
                    new XElement("cantidadVendida", x.cantidadVendida),
                    new XElement("placaTransporte", x.placaTransporte),
                    new XElement("codigoEstado", x.codigoEstado)
            ));

            var xml = new XElement("ordenPedido",
                new XElement("loginUsuario", request.loginUsuario),
                new XElement("claveUsuario", request.claveUsuario),
                new XElement("codigoAutorizacion", request.codigoAutorizacion),
                new XElement("codigoMayoristaEquivalente", request.codigoMayoristaEquivalente),
                new XElement("codigoPlantaEquivalente", request.codigoPlantaEquivalente),
                new XElement("numeroFactura", request.numeroFactura),
                new XElement("fechaFactura", request.fechaFactura),
                new XElement("tipoVentaFactor", request.tipoVentaFactor),
                new XElement("codigoEquivalenteProductor", request.codigoEquivalenteProductor),
                details
                );

            return xml;
        }

    }
}
