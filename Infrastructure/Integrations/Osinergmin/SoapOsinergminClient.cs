using Application.Interfaces;
using Energigas.Api.Osinergmin.Application.DTOs;
using Energigas.Api.Osinergmin.Shared.Helpers;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Integrations.Osinergmin
{
    public class SoapOsinergminClient : ISoapOsinergminClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SoapOsinergminClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #region (G-1) Generar Orden de Pedido Simple
        public async Task<SimplePurchaseOrderResponseDto> GenerateSimplePurchaseOrder(SimplePurchaseOrderRequestDto simplePurchaseOrder)
        {
                var soapRequest = new SoapPurchaseOrderRequestDto
                {
                    loginUsuario = simplePurchaseOrder.UserLogin,
                    claveUsuario = simplePurchaseOrder.UserPassword,
                    tipoTransaccion = simplePurchaseOrder.TypeTransaction,
                    codigoMayoristaEquivalente = simplePurchaseOrder.EquivalentWhosaleCode,
                    codigoPlantaEquivalente = simplePurchaseOrder.EquivalentPlantCode,
                    placaTransporte = simplePurchaseOrder.TransportPlate,
                    fechaEntrega = simplePurchaseOrder.DeliveryDate,
                    cola = simplePurchaseOrder.Tail,
                    detalles = simplePurchaseOrder.Details.Select(e => new SoapPurchaseOrdenDetailRequestDto
                    {
                        codigoProducto = e.ProductCode,
                        cantidadSolicitada = e.RequestedQuantity,
                    }).ToList()
                };

                var xmlBody = XmBuilder.GenerateSimpleOrderXml(soapRequest);

                var soapEnvelope = $@"
                <soapenv:Envelope xmlns:soapenv=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ser=""http://services.webservices.scop.osinergmin.com"">
                    <soapenv:Header/>
                    <soapenv:Body>
                        <ser:generateSimpleOrder>
                            {xmlBody}
                        </ser:generateSimpleOrder>
                    </soapenv:Body>
                </soapenv:Envelope>";

                var client = _httpClientFactory.CreateClient();

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://scopwsdesa.osinergmin.gob.pe/scopws/services/OrdenPedidoService"),
                    Content = new StringContent(soapEnvelope, Encoding.UTF8, "application/soap+xml")
                };

                var response = await client.SendAsync(request);

                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                var contentParse = SoapResponseParser.SimplePurchaseOrderParser(content);

                if (contentParse.resultado == "0" || contentParse.codigoError != "")
                    throw new BusinessException($"Error codigo: {contentParse.codigoError}");

                var result = new SimplePurchaseOrderResponseDto
                {
                    codigoAutorizacion = contentParse.codigoAutorizacion,
                    fechaRegistro = DateHelper.ParseDate(contentParse.fechaRegistro),
                    horaRegistro = DateHelper.ParseDate(contentParse.horaRegistro)
                };

                return result;
        }
        #endregion

    }
}
