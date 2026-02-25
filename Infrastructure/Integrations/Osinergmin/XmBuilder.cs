using Energigas.Api.Osinergmin.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
