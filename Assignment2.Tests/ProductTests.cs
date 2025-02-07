// Ansh Dave - 8909821
// Baljindar Singh - 8913973
// Varad Krishna Sudhakaran - 

using NUnit.Framework;
using Assignment2;

namespace Assignment2.Tests
{
    [TestFixture]
    public class ProductTests
    {
        #region ProdID Tests

        // Tests if the ProdID property correctly returns the assigned valid value.
        [Test]
        public void TestProdID_ValidValue()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 50);

            // Act
            var result = product.ProdID;

            // Assert
            Assert.That(result, Is.EqualTo(123));
        }

        // Tests if the ProdID property correctly handles the minimum valid value.
        [Test]
        public void TestProdID_MinValue()
        {
            // Arrange
            var product = new Product(5, "Sample Product", 100, 50);

            // Act
            var result = product.ProdID;

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        // Tests if the ProdID property correctly handles the maximum valid value.
        [Test]
        public void TestProdID_MaxValue()
        {
            // Arrange
            var product = new Product(50000, "Sample Product", 100, 50);

            // Act
            var result = product.ProdID;

            // Assert
            Assert.That(result, Is.EqualTo(50000));
        }

        #endregion

        #region ProdName Tests

        // Tests if the ProdName property correctly returns the assigned valid value.
        [Test]
        public void TestProdName_ValidValue()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 50);

            // Act
            var result = product.ProdName;

            // Assert
            Assert.That(result, Is.EqualTo("Sample Product"));
        }

        // Tests if the ProdName property correctly handles an empty string value.
        [Test]
        public void TestProdName_EmptyValue()
        {
            // Arrange
            var product = new Product(123, "", 100, 50);

            // Act
            var result = product.ProdName;

            // Assert
            Assert.That(result, Is.EqualTo(""));
        }

        // Tests if the ProdName property correctly handles a null value.
        [Test]
        public void TestProdName_NullValue()
        {
            // Arrange
            var product = new Product(123, null, 100, 50);

            // Act
            var result = product.ProdName;

            // Assert
            Assert.That(result, Is.Null);
        }

        #endregion

        #region ItemPrice Tests

        // Tests if the ItemPrice property correctly returns the assigned valid value.
        [Test]
        public void TestItemPrice_ValidValue()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 50);

            // Act
            var result = product.ItemPrice;

            // Assert
            Assert.That(result, Is.EqualTo(100));
        }

        // Tests if the ItemPrice property correctly handles the minimum valid value.
        [Test]
        public void TestItemPrice_MinValue()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 5, 50);

            // Act
            var result = product.ItemPrice;

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        // Tests if the ItemPrice property correctly handles the maximum valid value.
        [Test]
        public void TestItemPrice_MaxValue()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 5000, 50);

            // Act
            var result = product.ItemPrice;

            // Assert
            Assert.That(result, Is.EqualTo(5000));
        }

        #endregion

        #region Stock Increase Tests

        // Tests if the IncreaseStock method correctly increases the stock by a valid amount.
        [Test]
        public void TestIncreaseStock_ValidValue()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 50);

            // Act
            product.IncreaseStock(10);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(60));
        }

        // Tests if the IncreaseStock method correctly handles increasing stock when the stock is already at a high value.
        [Test]
        public void TestIncreaseStock_MaxValue()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 500000);

            // Act
            product.IncreaseStock(100);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(500100));
        }

        // Tests if the IncreaseStock method correctly handles increasing stock when the stock is at a low value.
        [Test]
        public void TestIncreaseStock_MinValue()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 5);

            // Act
            product.IncreaseStock(10);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(15));
        }

        #endregion

        #region Stock Decrease Tests

        // Tests if the DecreaseStock method correctly decreases the stock by a valid amount.
        [Test]
        public void TestDecreaseStock_ValidValue()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 50);

            // Act
            product.DecreaseStock(10);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(40));
        }

        // Tests if the DecreaseStock method correctly handles decreasing stock to zero.
        [Test]
        public void TestDecreaseStock_MinValue()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 5);

            // Act
            product.DecreaseStock(5);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(0));
        }

        // Tests if the DecreaseStock method throws an exception when attempting to decrease stock below zero.
        [Test]
        public void TestDecreaseStock_TooMuch()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 50);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(60));
            Assert.That(ex.Message, Is.EqualTo("Stock cannot be negative."));
        }

        // Tests if the DecreaseStock method throws an exception when attempting to decrease stock by a very large amount.
        [Test]
        public void TestDecreaseStock_LargeValueBelowZero()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 50);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(100000));
            Assert.That(ex.Message, Is.EqualTo("Stock cannot be negative."));
        }

        #endregion

        #region Stock Edge Case Tests

        // Tests if the IncreaseStock method correctly handles increasing stock by a very large amount.
        [Test]
        public void TestIncreaseStock_LargeAmount()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 50);

            // Act
            product.IncreaseStock(500000);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(500050));
        }

        // Tests if the DecreaseStock method correctly handles decreasing stock by a very large amount.
        [Test]
        public void TestDecreaseStock_LargeAmount()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 500000);

            // Act
            product.DecreaseStock(100000);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(400000));
        }

        #endregion
    }
}