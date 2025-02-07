using NUnit.Framework;
using Assignment2; 

namespace Assignment2.Tests
{
    [TestFixture]
    public class ProductTests
    {
        #region ProdID Tests

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

        [Test]
        public void TestDecreaseStock_TooMuch()
        {
            // Arrange
            var product = new Product(123, "Sample Product", 100, 50);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(60));
            Assert.That(ex.Message, Is.EqualTo("Stock cannot be negative."));
        }

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