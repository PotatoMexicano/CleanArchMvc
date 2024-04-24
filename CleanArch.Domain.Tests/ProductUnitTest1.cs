using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void Constructor_WithInvalidId_ShouldThrowException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new Product(-1, "name", "desc", 10, 5, "image"));
        }

        [Fact]
        public void Constructor_WithInvalidName_ShouldThrowException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new Product("ab", "desc", 10, 5, "image"));
        }

        [Fact]
        public void Constructor_WithInvalidDescription_ShouldThrowException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new Product("name", "", 10, 5, "image"));
        }

        [Fact]
        public void Constructor_WithNegativePrice_ShouldThrowException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new Product("name", "desc", -1, 5, "image"));
        }

        [Fact]
        public void Constructor_WithLongImageName_ShouldThrowException()
        {
            string longImageName = new string('a', 251);
            Assert.Throws<DomainExceptionValidation>(() => new Product("name", "desc", 10, 5, longImageName));
        }

        [Fact]
        public void ParameterlessConstructor_WithValidData_ShouldNotThrowException()
        {
            Action action = new Action(() => new Product("name", "descaaaaaaaaaa", 10, 5, "image"));
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void Constructor_WithValidData_ShouldSetProperties()
        {
            Product product = new Product("name", "descaaaaaaaaaa", 10, 5, "image");

            Assert.Equal("name", product.Name);
            Assert.Equal("descaaaaaaaaaa", product.Description);
            Assert.Equal(10, product.Price);
            Assert.Equal(5u, product.Stock);
            Assert.Equal("image", product.Image);
            
        }
    }
}
