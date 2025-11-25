using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.Common
{
    public class ApiErrorRespons: ApiErrorResponsWithDetails
    {
        public int StatusCode { get; set; }
        public string Error { get; set; }
        //public ApiErrorRespons(int stats, string? massage)
        //{
        //    Stats = stats;
        //    Massage = massage ?? HandleMassage();
        //}
        //private string HandleMassage()
        //{
        //    var message = "";
        //    switch (Stats)
        //    {
        //        case 404:
        //                message = "NotFound";
        //                break;
        //        case 400:
        //            message = "BadRequest";
        //            break;
        //        default:
        //            message = "Internal Server Error";
        //            break;
        //    }
        //    return message;

        //}

        //public int Stats { get; set; }
        //public string? Massage { get; set; }
        //public override string ToString()
        //{
        //    return JsonSerializer.Serialize(this);
        //}
    }

    public class ApiErrorResponsWithDetails 
    {
        public string Details { get; set; }
    }

}
