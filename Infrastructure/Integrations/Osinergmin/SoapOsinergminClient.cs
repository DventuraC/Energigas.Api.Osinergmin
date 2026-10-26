using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using Energigas.Api.Osinergmin.Shared.Helpers;
using Infrastructure.Integrations.Osinergmin.DTOs.Requests;
using Shared.Common;
using System.Text;

namespace Infrastructure.Integrations.Osinergmin
{
    public class SoapOsinergminClient : ISoapOsinergminClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        public SoapOsinergminClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("OsinergminConfig");
        }

        #region (G-1) Generar Orden de Pedido Simple
        public async Task<SimplePurchaseOrderResponseDto> GenerateSimplePurchaseOrder(SimplePurchaseOrderRequestDto simplePurchaseOrder)
        {
                var soapRequest = new SoapPurchaseOrderRequestDto
                {
                    loginUsuario = simplePurchaseOrder.UserLogin,
                    claveUsuario = simplePurchaseOrder.UserPassword,
                    tipoTransaccion = simplePurchaseOrder.TypeTransaction,
                    codigoMayoristaEquivalente = simplePurchaseOrder.CodeWhosaleEquivalent,
                    codigoPlantaEquivalente = simplePurchaseOrder.CodePlantEquivalent,
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

                var request = new HttpRequestMessage(HttpMethod.Post, "scopws/services/OrdenPedidoService")
                {
                    Content = new StringContent(soapEnvelope, Encoding.UTF8, "application/soap+xml")
                };

                var response = await _httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                var contentParse = SoapResponseParser.SimplePurchaseOrderParser(content);

                if (contentParse.resultado == "0" || !string.IsNullOrWhiteSpace(contentParse.codigoError) )
                    throw new OsinergminException(message:null, codeError:contentParse.codigoError ?? "-1");

                var result = new SimplePurchaseOrderResponseDto
                {
                    codigoAutorizacion = contentParse.codigoAutorizacion,
                    fechaRegistro = DateHelper.ParseDate(contentParse.fechaRegistro),
                    horaRegistro = DateHelper.ParseDate(contentParse.horaRegistro)
                };

                return result;
        }
        #endregion

        #region (M-2) Consultar Orden de Pedido Simple
        public async Task<SimplePurchaseOrderResponseDto> ConsultSimplePurchaseOrder(SimplePurchaseOrderRequestDto simplePurchaseOrder)
        {
            var soapRequest = new SoapPurchaseOrderRequestDto
            {
                loginUsuario = simplePurchaseOrder.UserLogin,
                claveUsuario = simplePurchaseOrder.UserPassword,
                tipoTransaccion = simplePurchaseOrder.TypeTransaction,
                codigoMayoristaEquivalente = simplePurchaseOrder.CodeWhosaleEquivalent,
                codigoPlantaEquivalente = simplePurchaseOrder.CodePlantEquivalent,
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

            var request = new HttpRequestMessage(HttpMethod.Post, "scopws/services/OrdenPedidoService")
            {
                Content = new StringContent(soapEnvelope, Encoding.UTF8, "application/soap+xml")
            };

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var contentParse = SoapResponseParser.SimplePurchaseOrderParser(content);

            if (contentParse.resultado == "0" || contentParse.codigoError != "")
                throw new OsinergminException($"Error codigo: {contentParse.codigoError}", contentParse.codigoError);

            var result = new SimplePurchaseOrderResponseDto
            {
                codigoAutorizacion = contentParse.codigoAutorizacion,
                fechaRegistro = DateHelper.ParseDate(contentParse.fechaRegistro),
                horaRegistro = DateHelper.ParseDate(contentParse.horaRegistro)
            };

            return result;
        }
        #endregion

        #region (M-3) Consultar Orden de Pedido Simple por Codigo de Autorizacion
        public async Task<SimpleOrderResponseDto> GetSimplePurchaseByScopAsync(SimpleOrderRequestDto simplePurchaseOrder)
        {
            var soapRequest = new SoapGetOrderByScopRequestDto
            {
                loginUsuario = simplePurchaseOrder.UserLogin,
                claveUsuario = simplePurchaseOrder.UserPassword,
                codigoAutorizacion = simplePurchaseOrder.Scop
            };

            var xmlBody = XmBuilder.GetSimpleOrderByScopXml(soapRequest);

            var soapEnvelope = $@"
                <soapenv:Envelope xmlns:soapenv=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ser=""http://services.webservices.scop.osinergmin.com"">
                    <soapenv:Header/>
                    <soapenv:Body>
                        <ser:getOrdenPedidoByCodigoAutorizacion>
                            {xmlBody}
                        </ser:getOrdenPedidoByCodigoAutorizacion>
                    </soapenv:Body>
                </soapenv:Envelope>";


            var request = new HttpRequestMessage(HttpMethod.Post, "scopws/diensten/MayoristasService")
            {
                Content = new StringContent(soapEnvelope, Encoding.UTF8, "application/soap+xml")
            };

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var contentParse = SoapResponseParser.SimpleOrderParser(content);

            if (contentParse.CodigoAutorizacion == "" || string.IsNullOrEmpty(contentParse.CodigoAutorizacion))
                throw new OsinergminException(
                    message:$"No se encontro ningun scop para la terminal indicada");

            var result = new SimpleOrderResponseDto
            {
                CodigoAutorizacion = contentParse.CodigoAutorizacion,
                CodigoDghCliente = contentParse.CodigoDGHCliente,
                CodigoEstado = contentParse.CodigoEstado,
                CodigoMayoristaEquivalente = contentParse.CodigoMayoristaEquivalente,
                CodigoOsinergCliente = contentParse.CodigoOsinergCliente,
                CodigoPlantaEquivalente = contentParse.CodigoPlantaEquivalente,
                DescripcionEstado = contentParse.DescripcionEstado,
                Detalles = contentParse.Detalles.Select(e => new SimpleOrderDetailResponseDto
                {
                    CantidadDespachada = e.CantidadDespachada,
                    CantidadSolicitada = e.CantidadSolicitada,
                    CantidadVendida = e.CantidadVendida,
                    CodigoEstado = e.CodigoEstado,
                    CodigoProducto = e.CodigoProducto,
                    DetallePedido = e.DetallePedido,
                    PlacaTransporte = e.PlacaTransporte,
                    FactorAPI = e.FactorAPI,
                    Temperatura = e.Temperatura
                }).ToList()
            };

            return result;
        }
        #endregion

        #region (M-4) Atención de Ordenes - Mayorista
        public async Task<AttentionOrderResponseDto> AttentionOrderAsync(AttentionOrderRequestDto attentionOrder)
        {
            var soapRequest = new SoapAttentionOrderRequestDto
            {
                loginUsuario = attentionOrder.UserLogin,
                claveUsuario = attentionOrder.UserPassword,
                codigoAutorizacion = attentionOrder.Scop,
                codigoMayoristaEquivalente = attentionOrder.CodeWhosaleEquivalent,
                codigoPlantaEquivalente = attentionOrder.CodePlantEquivalent,
                numeroFactura = attentionOrder.NumberInvoice,
                fechaFactura = attentionOrder.DateInvoice,
                detalles = attentionOrder.Details.Select(e => new SoapAttentionDetailOrderRequestDto
                {
                    detallePedido = e.CodeDetail,
                    codigoProducto = e.CodeProduct,
                    cantidadVendida = e.AmountSoul,
                    placaTransporte = e.Plate
                }).ToList()
            };

            var xmlBody = XmBuilder.AttentionOrderXml(soapRequest);

            var soapEnvelope = $@"
                <soapenv:Envelope xmlns:soapenv=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ser=""http://services.webservices.scop.osinergmin.com"">
                    <soapenv:Header/>
                    <soapenv:Body>
                        <ser:atencionOrdenes>
                            {xmlBody}
                        </ser:atencionOrdenes>
                    </soapenv:Body>
                </soapenv:Envelope>";


            var request = new HttpRequestMessage(HttpMethod.Post, "scopws/diensten/MayoristasService")
            {
                Content = new StringContent(soapEnvelope, Encoding.UTF8, "application/soap+xml")
            };

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var contentParse = SoapResponseParser.AttentionOrderParser(content);

            if (contentParse.Resultado ==  "0")
                throw new OsinergminException(message: null ,codeError: contentParse.CodigoError);

            var result = new AttentionOrderResponseDto
            {
                CodigoAutorizacion = contentParse.CodigoAutorizacion,
                CodigoError = contentParse.CodigoError,
                Resultado = contentParse.Resultado,
                DescripcionEstado = "VENDIDO"
            };

            return result;
        }
        #endregion
    }
}
