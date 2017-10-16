using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{

    public class Customer { public string Name { get; set; } }
    public class PrivateCustomer : Customer { public string PrivateTel { get; set; } }
    public class BusinessCustomer : Customer { public string BusinessTel { get; set; } }

    [TestClass]
    public class TestAnything
    {
        [TestMethod]
        public void OperatorKw_Is()
        {//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/is

            //ARRANGE
            PrivateCustomer pc = new PrivateCustomer();
            Customer cust = new BusinessCustomer { Name = "Stefan", BusinessTel = "+4498347" };

            //ACT
            bool isPrivateCustomerACustomer = (pc is Customer) ? true : false;
            bool isCustomerABusinessCustomer = (cust is BusinessCustomer) ? true : false;

            //ASSERT -  Überprüfen ob Instanz eines Objektes von bestimmtem Typ ist
            isPrivateCustomerACustomer.Should().Be(true, "expr is an instance of a type that derives from type");
            isCustomerABusinessCustomer.Should().Be(true);
        }

        [TestMethod]
        public void OperatorKw_As()
        {
            //ARRANGE
            BusinessCustomer cust = new BusinessCustomer { Name = "Stefan", BusinessTel = "+4498347" };
            Customer customer = new Customer();

            //ACT
            Customer bcCastAble = cust as Customer;
            PrivateCustomer custNotCastAble = customer as PrivateCustomer;

            //ASSERT - Versucht eine Instanz zu Casten. Ist null im Fehlerfall. (Besonderheit: Es wird keine Exception geworfen)
            bcCastAble.Should().NotBeNull("BusinessCustomer should be castable to Customer");
            custNotCastAble.Should().BeNull("Customer can not be casted to PrivateCustomer but the other way round");
        }
    }

}
