using Moq;
using Saas_Product_Import.Models;
using Saas_Product_Import.Repository;
using Saas_Product_Import.Sources.Source;
using System;
using Xunit;

namespace SaaS_Product_Import_Test
{
    public class CapterraTest
    {
        Capterra capterra;

        [Fact]
        public async void Import_Sucess_ShouldSave()
        {
            //Arrange
            var fakePath = "";
            var mockRepo = new Mock<IBaseRepository>();
            capterra = new Capterra();
            //Act
            await capterra.Import(fakePath, mockRepo.Object);

            //Assert
            mockRepo.Verify(x => x.Create(It.IsAny<Product>()), Times.AtLeastOnce);
        }
    }
}
