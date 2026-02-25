using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTesting.APIs.Domain;

namespace WebApiTesting.UnitTests.Domain
{
    public class ParkingLotTests
    {
        [Fact]
        public void Constructor_ShouldSetTotalSpots_WhenTotalSpotsIsPositive()
        {
            // Arrange
            int totalSpots = 10;

            // Act
            var lot = new ParkingLot(totalSpots);

            // Assert
            Assert.Equal(10, lot.TotalSpots);
        }

        [Fact]
        public void Constructor_ShouldSetOccupiedSpotsToZero_WhenCreated()
        {
            // Arrange
            int totalSpots = 10;

            // Act
            var lot = new ParkingLot(totalSpots);

            // Assert
            Assert.Equal(0, lot.OccupiedSpots);
        }

        [Fact]
        public void Constructor_ShouldHaveAllSpotsAvailable_WhenCreated()
        {
            // Arrange
            int totalSpots = 10;

            // Act
            var lot = new ParkingLot(totalSpots);

            // Assert
            Assert.Equal(10, lot.AvailableSpots);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenTotalSpotsIsZero()
        {
            // Arrange
            int totalSpots = 0;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => new ParkingLot(totalSpots));

            // Assert
            Assert.Equal("Total spots must be greater than zero.", ex.Message);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenTotalSpotsIsNegative()
        {
            // Arrange
            int totalSpots = -5;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => new ParkingLot(totalSpots));

            // Assert
            Assert.Equal("Total spots must be greater than zero.", ex.Message);
        }

        [Fact]
        public void ParkVehicle_ShouldIncreaseOccupiedSpots_ByOne()
        {
            // Arrange
            var lot = new ParkingLot(5);

            // Act
            lot.ParkVehicle();

            // Assert
            Assert.Equal(1, lot.OccupiedSpots);
        }

        [Fact]
        public void ParkVehicle_ShouldDecreaseAvailableSpots_ByOne()
        {
            // Arrange
            var lot = new ParkingLot(5);

            // Act
            lot.ParkVehicle();

            // Assert
            Assert.Equal(4, lot.AvailableSpots);
        }

        [Fact]
        public void ParkVehicle_ShouldThrowInvalidOperationException_WhenLotIsFull()
        {
            // Arrange
            var lot = new ParkingLot(2);
            lot.ParkVehicle();
            lot.ParkVehicle();

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => lot.ParkVehicle());

            // Assert
            Assert.Equal("Parking lot is full.", ex.Message);
        }

        [Fact]
        public void ParkVehicle_ShouldNotChangeOccupiedSpots_WhenParkFailsBecauseLotIsFull()
        {
            // Arrange
            var lot = new ParkingLot(1);
            lot.ParkVehicle();

            // Act
            try
            {
                lot.ParkVehicle();
            }
            catch (InvalidOperationException)
            {
                // swallow for test
            }

            // Assert
            Assert.Equal(1, lot.OccupiedSpots);
        }

        [Fact]
        public void RemoveVehicle_ShouldDecreaseOccupiedSpots_ByOne()
        {
            // Arrange
            var lot = new ParkingLot(5);
            lot.ParkVehicle();

            // Act
            lot.RemoveVehicle();

            // Assert
            Assert.Equal(0, lot.OccupiedSpots);
        }

        [Fact]
        public void RemoveVehicle_ShouldIncreaseAvailableSpots_ByOne()
        {
            // Arrange
            var lot = new ParkingLot(5);
            lot.ParkVehicle();

            // Act
            lot.RemoveVehicle();

            // Assert
            Assert.Equal(5, lot.AvailableSpots);
        }

        [Fact]
        public void RemoveVehicle_ShouldThrowInvalidOperationException_WhenLotIsEmpty()
        {
            // Arrange
            var lot = new ParkingLot(3);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => lot.RemoveVehicle());

            // Assert
            Assert.Equal("Parking lot is already empty.", ex.Message);
        }

        [Fact]
        public void RemoveVehicle_ShouldNotChangeOccupiedSpots_WhenRemoveFailsBecauseLotIsEmpty()
        {
            // Arrange
            var lot = new ParkingLot(3);

            // Act
            try
            {
                lot.RemoveVehicle();
            }
            catch (InvalidOperationException)
            {
                // swallow for test
            }

            // Assert
            Assert.Equal(0, lot.OccupiedSpots);
        }

        [Fact]
        public void AvailableSpots_ShouldBeZero_WhenLotIsFull()
        {
            // Arrange
            var lot = new ParkingLot(2);
            lot.ParkVehicle();
            lot.ParkVehicle();

            // Act
            var available = lot.AvailableSpots;

            // Assert
            Assert.Equal(0, available);
        }
    }
}
