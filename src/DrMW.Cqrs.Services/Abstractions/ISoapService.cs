using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrMW.Cqrs.Service.Abstractions
{
    public interface ISoapService
    {
        Task<string> NumberToDollars(decimal num);

        Task<string> NumberToWords(ulong num);
    }
}
