using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArch.Domain.Tests
{
    public class CategoryunitTest1
    {

        [Fact]
        public void CategoryConstructor_ValidName_ShouldInitialize()
        {
            string validName = "Electronics";
            var category = new Category(validName);
            Assert.Equal(validName, category.Name);
        }

        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact]
        public void Category_WithIdAndValidName_ShouldInitialize()
        {
            int validId = 1;
            string validName = "Electronics";

            var category = new Category(validId, validName);

            Assert.Equal(validId, category.Id);
            Assert.Equal(validName, category.Name);
        }

        [Fact]
        public void Category_WithNegativeId_ShouldThrowException()
        {
            // Arrange
            int invalidId = -1;
            string validName = "Electronics";

            Action action = () => new Category(invalidId, validName);
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Category_NullOrEmptyName_ShouldThrowException(string invalidName)
        {
            Action action = () => new Category(invalidName);
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Theory]
        [InlineData("AB")]
        [InlineData("A")]
        public void Category_ShortName_ShouldThrowException(string invalidName)
        {
            Action action = () => new Category(invalidName);
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Update_NullOrEmptyName_ShouldThrowException(string invalidName)
        {
            // Arrange
            Action action = () => new Category(invalidName);

            action.Should().Throw<DomainExceptionValidation>();
        }

        [Theory]
        [InlineData("AB")]
        [InlineData("A")]
        public void Update_ShortName_ShouldThrowException(string invalidName)
        {
            // Arrange
            Action action = () => new Category(invalidName);

            action.Should().Throw<DomainExceptionValidation>();
        }

    }
}