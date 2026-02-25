using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTesting.APIs.Domain;

namespace WebApiTesting.UnitTests.Domain
{
    public class BankAccountTests
    {
        [Fact]
        public void Deposit_ShouldIncreaseBalance_WhenAmountIsPositive()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act
            account.Deposit(50m);

            // Assert
            Assert.Equal(150m, account.Balance);
        }

        [Fact]
        public void Deposit_ShouldThrowArgumentException_WhenAmountIsZero()
        {
            // Arrange
            var account = new BankAccount();

            // Act
            var ex = Assert.Throws<ArgumentException>(() => account.Deposit(0m));

            // Assert
            Assert.Equal("Amount must be greater than zero.", ex.Message);
        }

        [Fact]
        public void Deposit_ShouldThrowArgumentException_WhenAmountIsNegative()
        {
            // Arrange
            var account = new BankAccount();

            // Act
            var ex = Assert.Throws<ArgumentException>(() => account.Deposit(-10m));

            // Assert
            Assert.Equal("Amount must be greater than zero.", ex.Message);
        }

        [Fact]
        public void Withdraw_ShouldDecreaseBalance_WhenAmountIsValidAndWithinBalance()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(200m);

            // Act
            account.Withdraw(50m);

            // Assert
            Assert.Equal(150m, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldAllowWithdrawingFullBalance_WhenAmountEqualsBalance()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act
            account.Withdraw(100m);

            // Assert
            Assert.Equal(0m, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldThrowArgumentException_WhenAmountIsZero()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => account.Withdraw(0m));

            // Assert
            Assert.Equal("Amount must be greater than zero.", ex.Message);
        }

        [Fact]
        public void Withdraw_ShouldThrowArgumentException_WhenAmountIsNegative()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => account.Withdraw(-1m));

            // Assert
            Assert.Equal("Amount must be greater than zero.", ex.Message);
        }

        [Fact]
        public void Withdraw_ShouldThrowInvalidOperationException_WhenAmountExceedsBalance()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => account.Withdraw(150m));

            // Assert
            Assert.Equal("Insufficient balance.", ex.Message);
            Assert.Equal(100m, account.Balance); // balance unchanged (separate behavior)
        }

        [Fact]
        public void Withdraw_ShouldNotChangeBalance_WhenWithdrawalFailsDueToInsufficientBalance()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act
            try
            {
                account.Withdraw(200m);
            }
            catch (InvalidOperationException)
            {
                // swallow for test
            }

            // Assert
            Assert.Equal(100m, account.Balance);
        }

        [Fact]
        public void NewAccount_ShouldStartWithZeroBalance()
        {
            // Arrange
            var account = new BankAccount();

            // Act
            var balance = account.Balance;

            // Assert
            Assert.Equal(0m, balance);
        }
    }
}
