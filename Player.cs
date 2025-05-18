using Godot;
using System;
using System.Collections.Generic;

namespace world
{
    public partial class Player : CharacterBody2D
    {
        private CollisionShape2D _collision;

        public override void _Ready()
        {
            _collision = GetNode<CollisionShape2D>("CollisionShape2D");
        }

        public override void _Draw()
        {
            Canvas.DrawRoundRect(this, new Rect2(Vector2.Zero, new Vector2(Level.SQUARE_W, Level.SQUARE_W)), 10,
                Colors.Black, true);
        }

        public override void _Input(InputEvent @event)
        {
            if (@event is InputEventKey eventKey && eventKey.Pressed && !eventKey.Echo)
            {
                switch (eventKey.Keycode)
                {
                    case Key.Left:
                    {
                        MoveAndCollide(new Vector2(-50, 0));
                    }
                        break;
                    case Key.Right:
                    {
                        MoveAndCollide(new Vector2(50, 0));
                        break;
                    }
                    case Key.Up:
                    {
                        MoveAndCollide(new Vector2(0, -50));
                        break;
                    }
                    case Key.Down:
                    {
                        MoveAndCollide(new Vector2(0, 50));
                        break;
                    }
                }
            }
        }

        public override void _PhysicsProcess(double delta)
        {
        }
    }
}