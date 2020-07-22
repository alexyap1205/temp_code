namespace Pilot.MoveStrategies
{
    public class MoveLeftStrategy : IMoveStrategy
    {
        private readonly Robot _robot;

        public MoveLeftStrategy(Robot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            var currentPosition = _robot.CurrentPosition;
            _robot.PositionAt(currentPosition.x - 1, currentPosition.y, currentPosition.facing);
        }
    }
}