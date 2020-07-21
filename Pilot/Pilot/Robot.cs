using System;

namespace Pilot
{
    public class Robot
    {
        private readonly ISurface _workSurface;
        private int _x;
        private int _y;
        private Direction _direction;

        public Robot(ISurface workSurface)
        {
            _workSurface = workSurface;
            _x = 0;
            _y = 0;
            _direction = Direction.North;
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

        public (int x, int y, Direction facing) CurrentPosition => (_x, _y, _direction);
    }
}