using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingMallAPI.Repository;
using ShoppingMallAssignmentMVC.Controllers;
using ShoppingMallAssignmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMallTest.TestData
{
    public class ShoppingTest
    {
        public void Index_ReturnsAViewResult_WithAListOfShoppingMalls()
        {
            // Arrange
            var mockRepo = new Mock<IDataRepository<ShoppingMallModelMVC>>();

            //mockRepo.Setup(repo => repo.GetAll()).Returns(ShoppingTest.Get);

            //    var controller = new ShoppingMallModelsController(mockRepo.Object);

            //    // Act
            //    var result = controller.Index();

            //    // Assert

            //    var viewResult = Assert.IsType<ViewResult>(result);

            //    var model = Assert.IsAssignableFrom<List<ShoppingMallModel>>(viewResult.ViewData.Model);

            //    Assert.Equal(2, model.Count());

            //}

            //private static IEnumerable<ShoppingMallModel> GetTestUniversity()
            //{
            //    throw new NotImplementedException();
        }
    }
}

