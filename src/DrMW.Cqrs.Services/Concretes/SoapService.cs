using DrMW.Cqrs.Service.Abstractions;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrMW.Cqrs.Service.Concretes
{
    public class SoapService : ISoapService
    {
        
        public async Task<string> NumberToDollars(decimal num) 
        {
            var client = new NumberConversionSoapTypeClient(NumberConversionSoapTypeClient.EndpointConfiguration.NumberConversionSoap);

            var response = await client.NumberToDollarsAsync(num);


            return response.Body.NumberToDollarsResult;
        }

        public async Task<string> NumberToWords(ulong num)
        {
            var client = new NumberConversionSoapTypeClient(NumberConversionSoapTypeClient.EndpointConfiguration.NumberConversionSoap);

            var response = await client.NumberToWordsAsync(num);


            return response.Body.NumberToWordsResult;
        }


    }
}
