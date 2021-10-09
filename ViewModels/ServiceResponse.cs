using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.ViewModels
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
        public T Data { get; set; } = default!;
    }


    public class ServiceResponse : ServiceResponse<object>
    {
        public ServiceResponse(string msg)
        {
            Message = msg;
        }
    }
}
