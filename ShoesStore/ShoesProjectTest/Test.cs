using System;
using Xunit;
using OrderData;
using ShoesStore;
using CustData;

namespace ShoesProjectTest
{
    public class Test
    {

        
        [Fact]
        public void TestSearchCustomer()
        {
            string name = "Emran";
            string expectedName = name;
            CustRepo Name = new CustRepo();
            var cust= Name.GetCustomer(name);
            
            string actualName =cust.C_name;
            Assert.Equal(expectedName, actualName);
        }
        /*[Fact]
        public void TestSearchCustomer1()
        {
            string name = "Abc";
            string expectedName = name;
            CustRepo Name = new CustRepo();
            var cust = Name.GetCustomer(name);

            string actualName = cust.C_name;
            Assert.Equal(expectedName, actualName);
        }*/
        [Fact]
        public void TestAddStore()
        {
            string location= "Dharavi";
            bool expectedstore = true;
            AdminLogin addstore = new AdminLogin();
            //When - Act
            bool actualstore = addstore.AddStore(location);
            //Then - Assert
            Assert.Equal(expectedstore, actualstore);

        }
        /*[Fact]
        public void Quantity()
        {
            string id = "81946";
            bool expectedQuantity = true;
            Orderclass qunatity = new Orderclass();
            //When - Act
            bool actualQuantity = qunatity.QuantityUpdate(id);
            //Then - Assert
            Assert.Equal(expectedQuantity, actualQuantity);

        }
        [Fact]
        public void Quantity1()
        {
            string id = "98765";
            bool expectedQuantity = false;
            Orderclass qunatity = new Orderclass();
            //When - Act
            bool actualQuantity = qunatity.QuantityUpdate(id);
            //Then - Assert
            Assert.Equal(expectedQuantity, actualQuantity);

        }*/

    }
}
 
