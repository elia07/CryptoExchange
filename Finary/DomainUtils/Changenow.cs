using Finary.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Finary.DomainUtils
{
    public class Changenow
    {
        public async Task<List<AvailableCurrencyModel>> GetAvailableCurrencies(bool fixedRate=false)
        {
            var client = new RestClient("https://api.changenow.io/v1/");
            RestRequest request;
            if(fixedRate)
            {
                request = new RestRequest("currencies?active=true&fixedRate=" + fixedRate.ToString().ToLower(), DataFormat.Json);
            }
            else
            {
                request = new RestRequest("currencies?active=true".ToLower(), DataFormat.Json);
            }
            
            return await client.GetAsync<List<AvailableCurrencyModel>>(request, CancellationToken.None);
        }
        public async Task<AddressValidationModel> AddressValidation(string currency, string address)
        {
            var client = new RestClient("https://api.changenow.io/v2/");
            var request = new RestRequest($"validate/address?currency={currency}&address={address}", DataFormat.Json);
            return await client.GetAsync<AddressValidationModel>(request, CancellationToken.None);
        }
        public async Task<List<AvailableCurrencyModelFor>> GetAvailbleCurrenciesFor(string basePair, bool fixedRate = false)
        {
            var client = new RestClient("https://api.changenow.io/v1/");
            RestRequest request;
            if(fixedRate)
            {
                request = new RestRequest("currencies-to/" + basePair + "?fixedRate=" + fixedRate.ToString().ToLower(), DataFormat.Json);
            }
            else
            {
                request = new RestRequest("currencies-to/" + basePair , DataFormat.Json);
            }

            
            return await client.GetAsync<List<AvailableCurrencyModelFor>>(request, CancellationToken.None);
        }

        public async Task<EstimatedExchangeAmountModel> EstimatedExchangeAmount(double amount, string from_to,bool fixedRate=false)
        {
            EstimatedExchangeAmountModel res;
            if (fixedRate)
            {
                var client = new RestClient("https://api.changenow.io/v1/");
                var request = new RestRequest($"exchange-amount/fixed-rate/{amount.ToString()}/{from_to}?api_key={DomainInfo.ChangenowApiKey}", DataFormat.Json);
                res= await client.GetAsync<EstimatedExchangeAmountModel>(request, CancellationToken.None);
            }
            else
            {
                var client = new RestClient("https://api.changenow.io/v1/");
                var request = new RestRequest($"exchange-amount/{amount.ToString()}/{from_to}?api_key={DomainInfo.ChangenowApiKey}", DataFormat.Json);
                res= await client.GetAsync<EstimatedExchangeAmountModel>(request, CancellationToken.None);
            }

            switch(res.error)
            {
                case "out_of_range":
                    res.error = "امکان تبادل این میزان ارز وجود ندارد";
                    break;
                case "not_valid_fixed_rate_pair":
                    res.error = "در حال حاضر امکان تبادل این جفت ارز مهیا نمی باشد ، ساعاتی بعد مجدد تلاش کنید";
                    break;
            }
            return res;
        }

        public async Task<MinExchangeAmountModel> MinExchangeAmount(string from_to)
        {
            var client = new RestClient("https://api.changenow.io/v1/");
            var request = new RestRequest($"min-amount/{from_to}", DataFormat.Json);
            return await client.GetAsync<MinExchangeAmountModel>(request, CancellationToken.None);
        }

        public async Task<CreateTransactionModel> CreateClassicTransaction(string from,string to,string address,double amount,string refundAddress="",string refundExtraId="", string extraId="",string userId="")
        {
            var client = new RestClient("https://api.changenow.io/v1/");
            var request = new RestRequest($"transactions/{DomainInfo.ChangenowApiKey}", DataFormat.Json);
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            var param = new { from = from, to = to,address=address,amount=amount,extraId=extraId,userId=userId,contactEmail="", refundAddress= refundAddress, refundExtraId= refundExtraId };
            request.AddJsonBody(param);
            return await client.PostAsync<CreateTransactionModel>(request, CancellationToken.None);
        }

        public async Task<TransactionStatusModel> TransactionStatus(string id)
        {
            var client = new RestClient("https://api.changenow.io/v1/");
            var request = new RestRequest($"transactions/{id}/{DomainInfo.ChangenowApiKey}", DataFormat.Json);
            return await client.GetAsync<TransactionStatusModel>(request, CancellationToken.None);
        }

    }
}