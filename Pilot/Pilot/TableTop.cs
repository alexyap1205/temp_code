using System;
using System.Security.Permissions;

namespace Pilot
{
    public class TableTop : ISurface
    {
        private readonly int _width;
        private readonly int _height;

        public TableTop(int width, int height)
        {
            _width = width;
            _height = height;
        }
        
        public bool IsValidPosition(int x, int y)
        {
            return !(x < 0 || y < 0 || x > this._width || y > this._height);
        }
    }
}