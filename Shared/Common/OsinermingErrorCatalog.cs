using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Common
{
    public class OsinermingErrorCatalog
    {
        private static readonly Dictionary<string, string> _errors = new()
        {
            { "01", "Error por defecto en la transacción." },
            { "02", "Error al momento de registrar la transacción." },
            { "03", "Parámetros obligatorios nulos o incorrectos." },
            { "04", "Usuario no válido." },
            { "05", "El usuario no puede acceder a la orden de pedido." },
            { "06", "Error en los detalles de la orden." },
            { "07", "Error en las cantidades de los productos." },
            { "08", "Códigos equivalentes de unidades operativas inválidas." },
            { "09", "Error en los transportes." },
            { "10", "Códigos no válidos en los detalles." },
            { "11", "Los códigos de operador y/o mayorista (productor) no son válidos (nulos o no relacionados)"},
            { "12", "La orden ya se encuentra VENDIDA"},
            { "13", "Los productos no corresponden a la lista de productos válidos para las unidades operativas o hay cantidades en exceso."},
            { "14", "El código de mayorista origen no coincide con la unidad operativa del usuario"},
            { "15", "El código del mayorista no coincide con la unidad del usuario.\r\nLos códigos de mayorista origen y destino son iguales o no coinciden con la unidad del usuario.\r\nLos códigos de la Planta origen y destino son iguales.\r\n"},
            { "16", "Error de Bloqueo y Validacion de Capacidad"},
            { "17", "El código de la forma de venta no es valido"},
            { "18", "El código del tipo de medio de transaporte no es valido"},
            { "19", "La sumatoria de los volúmenes divididos es diferente al volumen inicial solicitado."},
            { "20", "No existe detalles para la orden de pedido"},
            { "21", "Existe producto repetido en los detalles."},
            { "22", "No existe producto para el Operador o Mayorista en cuestion."},
            { "23", "No existe el codigode la Aerolínea"},
            { "24", "La Orden de Pedido no se encuentra en Estado Despachada"},
            { "25", "No existe Orden de Pedido con el Codigo de Autorizacion indicado y que esté asociado al usuario"},
            { "26", "El usuario no tiene acceso a la orden para anularla.\r\nEl usuario no tiene acceso a la orden para rechazarla\r\n"},
            { "27", "El tipo De Venta es incorrecto: V (Venta Nacional) ó E (Exportacion)"},
            { "28", "El código del productor proveedor del producto no es válido."},
            { "29", "No coinciden los parámetros del volumen solicitado y código del producto con los registrados por el operador"},
            { "30", "No se ha especificado el origen para generar la orden de pedido de Productos Diferenciados"},
            { "31", "No se puede vender/transferir productos diferenciados, de uso vehicular y normales en una misma orden."},
            { "32", "El producto diferenciado no tiene Factor de Aportación o Compensación"},
            { "33", "El tipo de venta ingresado no existe"},
            { "34", "Producto no tiene codigo clase Bodega asignado"},
            { "35", "El formato de la FACTURA o GUIA es incorrecto"},
            { "36", "No se ha ingresado la forma de venta de los productos diferenciados"},
            { "37", "Error en el ingreso de los factores de aportación/compensación, debe ser CERO"},
            { "38", "La fecha de factura ingresada tiene una antigüedad mayor a la permitida o es mayor a la fecha actual."},
            { "39", "Error en los transportes DIRTEPOL"},
            { "40", "Tamaño de lista de códigos de autorización incorrectos"},
            { "41", "Los códigos de unidad de medida ingresados no existen"},
            { "42", "No se ha especificado la modalidad del cruce del río inambari"},
            { "43", "Error en las cuotas de hidrocarburos"},
            { "44", "El código Osinergmin de la EVP vendedor no es válido o no está autorizado de vender en la zona"},
            { "45", "El Transporte seleccionado no se puede asignar debido a que NO se encuentra EMPADRONADA con GPS"},
            { "46", "El Transporte seleccionado no se puede asignar debido a que se encuentra bloqueado por Ordenes pendientes de Cierre y/o Registro SPIC"},
            { "47", "El usuario no esta autorizado para consumir este servicio"},
            { "48", "No ha transcurrido el tiempo necesario para volver a ejecutar la consulta"},
            { "49", "El tipo de agente vendedor difiere de los tipos válidos (M, E, D) "},
            { "50", "•\tEl Transporte seleccionado no se puede asignar debido a que NO se encuentra VIGENTE su RHO"},
            { "51", "•\tEl Transporte seleccionado no se puede asignar debido a que la Señal de Transmisión de GPS se encuentra Inactiva"},
            { "55", "No estas autorizado a comprar combustible al tipo de agente vendedor ingresado"},
            { "56", "Datos del mayorista/planta vacios o nulos"},
            { "57", "No puede realizar ningun tipo de transacción, se excedió de los días de plazo para cerrar sus ordenes de pedido pendientes"},
            { "58", "No se puede comprar dos o mas productos equivalentes en una misma orden"},
            { "59", "No puede realizar ningun tipo de transacción.\r\nHa acumulado Ordenes de Pedido sin Cerrar y/o pendientes del registro de sus ventas en el SPIC que superan lo permitido\r\n"},
            { "60", "La unidad operativa asociada al usuario no cuenta con el Registro de Hidrocarburos Vigente."},
            { "61", "La orden ya se encuentra CERRADA Estado detalle orden pedido no despachada"},
            { "62", "No ha transcurrido el tiempo necesario para registrar el cierre"},
            { "63", "La orden de pedido no puede ser cerrada hasta que el medio de transporte haya llegado exitosamente al establecimiento del agente comprador según la señal GPS y el combustible sea descargado en su totalidad en el establecimiento del agente comprador"},
            { "64", "El código Osinergmin del establecimiento destino no es válido o no está asociado al agente que genera la orden pedido"},
            { "65", "El establecimiento destino tiene pendiente el registro de sus inventarios diarios de combustibles lóquidos/GLP"},
            { "66", "Tiene pendiente el registro de sus precios de combustibles líquidos/GLP" }
        };

        public static string GetMessage(string code)
        {
            return _errors.TryGetValue(code, out var message)
                ? message
                : "Error desconocido del servicio externo.";
        }
    }
}
