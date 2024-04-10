using LST.Infrastructure.Messaging;
using LST.Model.Model.Api;
using LST.Model.Model.Messaging;
using LST.Repository.EF.All;
using LST.Service.Common;
using LST.Service.Implementations;
using LST.Service.Interfaces;
using LST.UnitTest.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using System;

namespace LST.UnitTest
{
    [TestFixture]
    public class LeetSpeakConverterTests
    {
        private ServiceProvider _serviceProvider;
        private static IConfiguration _configuration;
        private DbContextOptions<LSTContext> _options;

        public LeetSpeakConverterTests() { }

        [SetUp]
        public void Setup()
        {
            //_serviceProvider = DependencyConfig.ConfigureServices();
            // Configure the in-memory database options
            _options = new DbContextOptionsBuilder<LSTContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            // Setup DI container
            var services = new ServiceCollection();

            // Register DbContext with DI container
            services.AddDbContext<LSTContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));

            // Register ITransactionService and TransactionService with DI container
            services.AddTransient<ITransactionService, TransactionService>();

            // Other dependencies can be registered here if needed

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Resolve DbContext and other dependencies from the service provider
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var dbContext = scopedServices.GetRequiredService<LSTContext>();

                // Perform any additional setup or seeding of data in the in-memory database
                // dbContext.Seed(); // Example method for seeding data
            }
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    _serviceProvider.Dispose();
        //}

        [Test]
        public async Task ConvertToLeetSpeak_ConvertsTextCorrectly()
        {

            // Arrange
            SubmitQueryRequest request = new SubmitQueryRequest()
            {
                Text = "Master Obiwan has lost a planet",
            };

            var contextMock = Substitute.For<LSTContext>();
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            var configurationMock = Substitute.For<IConfiguration>();
            var loggerMock = Substitute.For<ILogger<ServiceBase>>();

            var transactionService = new TransactionService(
                contextMock,
                httpClientFactoryMock,
                configurationMock,
                loggerMock
            );

            //Act
            ApiResponseView response = null;
            string expected = "Lost a planet,master obiwan has";

            
            response = await transactionService!.UnitTestQuery(request);

            //Assert
            //Assert.AreEqual(expected, response.contents!.translated!);
            Assert.That(expected.Replace(" ",""), Is.EqualTo(response.contents!.translated!.Replace(" ","")));

            Assert.Pass();
        }
    }
}