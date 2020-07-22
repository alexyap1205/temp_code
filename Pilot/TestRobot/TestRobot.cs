using System;
using System.Data;
using Pilot;
using TestStack.BDDfy;
using Xunit;

namespace TestRobot
{
    public class TestRobot
    {
        private Robot _robot;
        
        [Fact]
        public void TestPlaceSuccess()
        {
            this.Given(s => s.SurfaceIsSet())
                .When(s => s.RobotIsPlacedAt(3, 3, Direction.East))
                .Then(s => s.ReportResultsTo(3, 3, Direction.East))
                .BDDfy();
        }

        [Theory]
        [InlineData(-1, 2, Direction.East)]
        [InlineData(2, -1, Direction.East)]
        [InlineData(5, 2, Direction.East)]
        [InlineData(2, 5, Direction.East)]
        public void TestPlaceOutside(int x, int y, Direction facing)
        {
            this.Given(s => s.SurfaceIsSet())
                .When(s => s.RobotIsPlacedAt(x, y, facing))
                .Then(s => s.ReportResultsTo(0, 0, Direction.North))
                .BDDfy();
        }

        [Theory]
        [InlineData(0, 0, Direction.East, 1, 0)]
        [InlineData(0, 0, Direction.North, 0, 1)]
        [InlineData(4, 4, Direction.West, 3, 4)]
        [InlineData(4, 4, Direction.South, 4, 3)]
        public void TestMove(int x, int y, Direction facing, int newX, int newY)
        {
            this.Given(s => s.SurfaceIsSet())
                .And(s => s.RobotIsPlacedAt(x, y, facing))
                .When(s => s.RobotMoves())
                .Then(s => s.ReportResultsTo(newX, newY, facing))
                .BDDfy();
        }

        [Theory]
        [InlineData(0, 0, Direction.West)]
        [InlineData(0, 0, Direction.South)]
        [InlineData(4, 4, Direction.East)]
        [InlineData(4, 4, Direction.North)]
        public void TestMoveOutsideBoundary(int x, int y, Direction facing)
        {
            this.Given(s => s.SurfaceIsSet())
                .And(s => s.RobotIsPlacedAt(x, y, facing))
                .When(s => s.RobotMoves())
                .Then(s => s.ReportResultsTo(x, y, facing))
                .BDDfy();
        }

        private void RobotMoves()
        {
            _robot.Move();
        }
        
        private void ReportResultsTo(int x, int y, Direction facing)
        {
            var report = _robot.CurrentPosition;
            Assert.Equal(x, report.x);
            Assert.Equal(y, report.y);
            Assert.Equal(facing, report.facing);
        }

        private void SurfaceIsSet()
        {
            _robot = new Robot(new TableTop(5, 5));
        }        
        
        private void RobotIsPlacedAt(int x, int y, Direction facing)
        {
            _robot.PositionAt(x, y, facing);
        }
    }
}