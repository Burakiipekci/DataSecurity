using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WhiteBlackList.Web.MiddleWares
{
    public class IPSafeMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IPList _ipList;

        public IPSafeMiddleWare(RequestDelegate next, IOptions<IPList> ipList)
        {
            _next = next;
           this. _ipList = ipList.Value;

        }
        public async Task Invoke(HttpContext context)
        {
            var reqIpAdress = context.Connection.RemoteIpAddress; // Gelen isteklerin adresini almamıza yarıyor

            var isWhiteList = _ipList.WhiteList.Where(x => IPAddress.Parse(x).Equals(reqIpAdress)).Any(); // Gelen istek WhiteList ayarımızın içinde mi değil mi kontrolünü yapıyoruz
            if (!isWhiteList)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;// Yasaklı yer olduğunu yasaklı Ip adres olduğunu söylüyoruz Yani 403 hatası döner
                return;
            }
            await _next(context);
        }
    }
}
