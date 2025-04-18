using System.Net;

namespace GuateShop.Frontend.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage responseMessage)
        {
            Response = response;
            Error = error;
            ResponseMessage = responseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage ResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }
            var statusCode = ResponseMessage.StatusCode;
            if (statusCode == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado.";
            }
            if(statusCode == HttpStatusCode.BadRequest)
            {
                return await ResponseMessage.Content.ReadAsStringAsync();
            }
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "No autorizado.";
            }
            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "Acceso denegado.";
            }
            if (statusCode == HttpStatusCode.InternalServerError)
            {
                return "Error interno del servidor.";
            }
            if (statusCode == HttpStatusCode.ServiceUnavailable)
            {
                return "Servicio no disponible.";
            }
            if (statusCode == HttpStatusCode.GatewayTimeout)
            {
                return "Tiempo de espera agotado.";
            }
            return "Error desconocido por favor intenta mas tarde.";
        }
    }
}
