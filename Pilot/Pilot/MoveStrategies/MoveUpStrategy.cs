namespace Pilot.MoveStrategies
{
    public class MoveUpStrategy : IMoveStrategy
    {
        private readonly Robot _robot;

        public MoveUpStrategy(Robot robot)
        {
            _robot = robot;
        }
        
        public void Execute()
        {
            var currentPosition = _robot.CurrentPosition;
            _robot.PositionAt(currentPosition.x, currentPosition.y + 1, currentPosition.facing);
        }
    }
}