using Godot;
using System;
using System.Collections.Generic;

namespace world
{
    public partial class Level : Node2D
    {
        private CharacterBody2D _player;
        public override void _Ready()
        {
            _player = GetNode<CharacterBody2D>("Player");
            _player.Position = _GetPositionOfSquarePosition(0, 0);
        }

        private Vector2 _GetPositionOfSquarePosition(int x, int y)
        {
            var width = SQUARE_W * SQUARE_COL;
            var height = SQUARE_W * SQUARE_ROW;
            var viewport = GetViewport();
            var viewportRect = GetViewportRect();
            var viewportTransform = viewport.GetCanvasTransform();
            var startPosition = Position * viewportTransform;
            var offset = (viewportRect.Size - new Vector2(width, height)) / 2;
            startPosition += offset;
            return startPosition + new Vector2(SQUARE_W * (x - 1), SQUARE_W * (y - 1));
        }
        
        public override void _Draw()
        {
            var width = SQUARE_W * SQUARE_COL;
            var height = SQUARE_W * SQUARE_ROW;
            var startPosition = _GetPositionOfSquarePosition(0, 0);
            var endPosition = startPosition + new Vector2(width, height);
            for (var row = startPosition.Y; row < endPosition.Y; row += SQUARE_W)
            {
                for (var col = startPosition.X; col < endPosition.X; col += SQUARE_W)
                {
                    Canvas.DrawRoundRect(this, new Rect2(new Vector2(col, row), new Vector2(SQUARE_W, SQUARE_W)), 10,
                        Colors.Azure, true);
                    
                    Canvas.DrawRoundRect(this, new Rect2(new Vector2(col, row), new Vector2(SQUARE_W, SQUARE_W)), 10,
                        Colors.Black, false);
                }
            }
        }

        public override void _PhysicsProcess(double delta)
        {
        }

        public static int SQUARE_ROW = 8;
        public static int SQUARE_COL = 8;
        public static int SQUARE_W = 50;
    }
}