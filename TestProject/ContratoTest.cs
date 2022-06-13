using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeuAlunoRepo.Services;
using System.Threading.Tasks;
using Moq;
using System.Net.Http;
using System.Net.Http.Json;
using Moq.Protected;
using System.Threading;

namespace TestProject
{
    [TestClass]
    public class ContratoTest
    {
        private readonly ContratoService _contratoService;

        public ContratoTest(ContratoService contratoService)
        {
            _contratoService = contratoService;
        }

        [TestMethod]
        public async Task GerarContratoPDF()
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            HttpResponseMessage httpResponseMessage = new()
            {
                Content = JsonContent.Create(new
                {
                    activity = "test",
                    type = "music"
                })
            };

            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",ItExpr.IsAny<HttpRequestMessage>(),ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            _contratoService.GerarContratoPDF(1, 2);
        }
    }
}