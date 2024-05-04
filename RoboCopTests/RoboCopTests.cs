using RoboCop.Business;

namespace RoboCopTests
{
    public class RoboCopTests
    {
        [Fact]
        public void ShouldPlaceRobot_WhenStartGame()
        {
            // Arrange
            Robot robot = new Robot();
            string actual = "1,1,NORTH";
            // Act
            robot.Place(1, 1, "NORTH");
            // Assert
            string result = robot.Report();
            Assert.Equal(result, actual);
        }

        [Fact]
        public void ShouldIgnoreMovement_WhenStartGame_GivenOtherCommandExceptPlace()
        {
            // Arrange
            Robot robot = new Robot();
            // Act
            robot.Move();
            // Assert
            string result = robot.Report();
            Assert.Null(result);
        }

        [Fact]
        public void ShouldTurnLeft_WhenLeftCommand_GivenPlaceCommandFired()
        {
            // Arrange
            Robot robot = new Robot();
            string actual = "1,1,WEST";
            // Act
            robot.Place(1, 1, "NORTH");
            robot.Left();
            // Assert
            string result = robot.Report();
            Assert.Equal(result, actual);
        }

        [Fact]
        public void ShouldTurnRight_WhenRightCommand_GivenPlaceCommandFired()
        {
            // Arrange
            Robot robot = new Robot();
            string actual = "1,1,EAST";
            // Act
            robot.Place(1, 1, "NORTH");
            robot.Right();
            // Assert
            string result = robot.Report();
            Assert.Equal(result, actual);
        }

        [Fact]
        public void ShouldIgnore_WhenMoveCommand_GivenPlacedInvalid()
        {
            // Arrange
            Robot robot = new Robot();
            // Act
            robot.Place(8, 8, "NORTH");
            robot.Move();
            // Assert
            string result = robot.Report();
            Assert.Null(result);
        }

        [Fact]
        public void ShouldMoveNorth_WhenMoveCommand_GivenPlacedFacingNorth()
        {
            // Arrange
            Robot robot = new Robot();
            string actual = "1,2,NORTH";
            // Act
            robot.Place(1, 1, "NORTH");
            robot.Move();
            // Assert
            string result = robot.Report();
            Assert.Equal(result, actual);
        }

        [Fact]
        public void ShouldMoveEast_WhenMoveCommand_GivenPlacedFacingEast()
        {
            // Arrange
            Robot robot = new Robot();
            string actual = "2,1,EAST";
            // Act
            robot.Place(1, 1, "EAST");
            robot.Move();
            // Assert
            string result = robot.Report();
            Assert.Equal(result, actual);
        }

        [Fact]
        public void ShouldMoveWest_WhenMoveCommand_GivenPlacedFacingWest()
        {
            // Arrange
            Robot robot = new Robot();
            string actual = "0,1,WEST";
            // Act
            robot.Place(1, 1, "WEST");
            robot.Move();
            // Assert
            string result = robot.Report();
            Assert.Equal(result, actual);
        }

        [Fact]
        public void ShouldMoveSouth_WhenMoveCommand_GivenPlacedFacingSouth()
        {
            // Arrange
            Robot robot = new Robot();
            string actual = "1,0,SOUTH";
            // Act
            robot.Place(1, 1, "SOUTH");
            robot.Move();
            // Assert
            string result = robot.Report();
            Assert.Equal(result, actual);
        }
    }
}