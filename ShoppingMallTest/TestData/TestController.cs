using ShoppingMallAssignmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMallTest.TestData
{
    public class TestController
    {
        public static IEnumerable<ShoppingMallModelMVC> GetTestUniversity()
        {
            return new List<ShoppingMallModelMVC>()
            {
                new ShoppingMallModelMVC()
                {
                    ShoppingMallName="Sahara",
                    ShoppingMallCity="Andhra",
                    ShoppingMallState="Andhra",
                    YearBuilt=2007

                },
                 new ShoppingMallModelMVC()
                {
                    ShoppingMallName="Phoenix",
                    ShoppingMallCity="Hyderabad",
                    ShoppingMallState="Telangana",
                    YearBuilt=2007
                },
                  new ShoppingMallModelMVC()
                {
                    ShoppingMallName="ZSquare",
                    ShoppingMallCity="Hyderabad",
                    ShoppingMallState="Telangana",
                    YearBuilt=1980
                },
                   new ShoppingMallModelMVC()
                {
                    ShoppingMallName="VMart",
                    ShoppingMallCity="vizag",
                    ShoppingMallState="Andhra",
                    YearBuilt=1889
                },

                new ShoppingMallModelMVC()
                {
                    
                    ShoppingMallName="OU",
                    ShoppingMallCity="Hyderabad",
                    ShoppingMallState="Telangana",
                    YearBuilt=2007
                }
            };
        }
    }
}

