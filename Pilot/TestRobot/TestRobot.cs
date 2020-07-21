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