using System;
using System.Collections.Generic;
using Pilot.MoveStrategies;

namespace Pilot
{
    public class Robot
    {
        private readonly ISurface _workSurface;
        private int _x;
        private int _y;
        private Direction _direction;

        private Dictionary<Direction, IMoveStrategy> _moveStrategies;

        public Robot(ISurface workSurface)
        {
            _workSurface = workSurface;
            _x = 0;
            _y = 0;
            _direction = Direction.North;
            _moveStrategies = new Dictionary<Direction, IMoveStrategy>
            {
                {Direction.East, new MoveRightStrategy(this)},
                {Direction.North, new MoveUpStrategy(this)},
                {Direction.South, new MoveDownStrategy(this)},
                {Direction.West, new MoveLeftStrategy(this)}
            };
        }

        public void PositionAt(int x, int y, Direction facing)
        {
            if (_workSurface.IsValidPosition(x, y))
            {
                this._x = x;
                this._y = y;
                this._direction = facing;
            }
        }

        public void Move()
        {
            this._moveStrategies[_direction].Execute();
        }

        public (int x, int y, Direction facing) CurrentPosition => (_x, _y, _direction);
    }
}