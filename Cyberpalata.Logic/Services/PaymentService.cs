using AuthorizeNet.Api.Controllers.Bases;
using AuthorizeNet.Api.Controllers;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using Cyberpalata.Logic.Models;
using Microsoft.Extensions.Configuration;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.CompilerServices;

namespace Cyberpalata.Logic.Services
{
    internal class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<PaymentService> _logger;
        public PaymentService(IConfiguration configuration, ILogger<PaymentService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        private transactionRequestType GetTransactionRequestType(Card card, decimal price,Guid userId)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _configuration["AuthorizeNetSettings:ApiKey"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _configuration["AuthorizeNetSettings:Name"],
            };

            var creditCard = new creditCardType
            {
                cardNumber = card.CardNumber,
                expirationDate = card.CardDate,
                cardCode = card.CardCvv
            };

            var paymentType = new paymentType { Item = creditCard };
            var lineItems = new lineItemType[1];
           
            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = price,
                payment = paymentType,
            };
            return transactionRequest;
        }

        private Result ReturnResult(createTransactionResponse response)
        {
            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if (response.transactionResponse.messages != null)
                    {
                        string log = $"Successfully created transaction with Transaction ID: {response.transactionResponse.transId}\n" +
                                     $"Response Code: {response.transactionResponse.responseCode}\n" +
                                     $"Message Code: {response.transactionResponse.messages[0].code}\n" +
                                     $"Description: {response.transactionResponse.messages[0].description}\n" +
                                     $"Success, Auth Code : {response.transactionResponse.authCode}";
                        _logger.LogInformation(log);
                    }
                    else
                    {
                        if (response.transactionResponse.errors != null)
                        {
                            string log = $"Error Code: {response.transactionResponse.errors[0].errorCode}\n" +
                                         $"Error message: {response.transactionResponse.errors[0].errorText}";
                            _logger.LogError(log);
                        }
                        return Result.Failure("Failed Transaction. Please, check card info.");
                    }
                }
                else
                {
                    if (response.transactionResponse != null && response.transactionResponse.errors != null)
                    {
                        string log = $"Error Code: {response.transactionResponse.errors[0].errorCode}\n" +
                                           $"Error message: {response.transactionResponse.errors[0].errorText}";
                        _logger.LogError(log);
                    }
                    else
                    {
                        string log = $"Error Code: {response.transactionResponse.errors[0].errorCode}\n" +
                                         $"Error message: {response.transactionResponse.errors[0].errorText}";
                        _logger.LogError(log);
                    }
                    return Result.Failure("Failed Transaction. Please, check card info.");
                }
            }
            else
            {
                return Result.Failure("Failed Transaction. Please, check card info.");
            }
            return Result.Success();
        }

        public Result MakeTransaction(Card card, decimal price, Guid userId)
        {
            var transactionRequest = GetTransactionRequestType(card,price, userId);
            var request = new createTransactionRequest { transactionRequest = transactionRequest };
            var controller = new createTransactionController(request);
            controller.Execute();
            var response = controller.GetApiResponse();
            return ReturnResult(response);
            
        }
    }
}
