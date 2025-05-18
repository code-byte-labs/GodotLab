using Godot;
using System;
using System.Collections.Generic;

namespace world
{
	public partial class Player : CharacterBody2D
	{
		private ulong _echoMillis = 0;
		private CollisionShape2D _collision;

		public override void _Ready()
		{
			_collision = GetNode<CollisionShape2D>("CollisionShape2D");
		}

		public override void _Draw()
		{
			Canvas.DrawRoundRect(this, new Rect2(Vector2.Zero, new Vector2(Level.SQUARE_W, Level.SQUARE_W)), Level.SQUARE_RADIUS,
				Colors.Black, true);
		}

		public override void _Input(InputEvent @event)
		{
			var millis = Time.GetTicksMsec();
			if (@event is not InputEventKey { Pressed: true } eventKey)
			{
				_echoMillis = 0;
				return;
			}
			var vector = eventKey.Keycode switch
			{
				Key.A => new Vector2(-50, 0),
				Key.Left => new Vector2(-50, 0),
				Key.D => new Vector2(50, 0),
				Key.Right => new Vector2(50, 0),
				Key.W => new Vector2(0, -50),
				Key.Up => new Vector2(0, -50),
				Key.S => new Vector2(0, 50),
				Key.Down => new Vector2(0, 50),
				_ => Vector2.Zero
			};

			if (vector == Vector2.Zero) return;

			if (_echoMillis > 0 && millis - _echoMillis <= 100)
			{
				return;
			}

			_echoMillis = eventKey.Echo ? millis : 0;
			
			var collision = MoveAndCollide(vector, true);
			var collider = collision?.GetCollider();
			if (collider == null)
			{
				MoveAndCollide(vector);
			}
			else if (collider is RigidBody2D rigidBody)
			{
				var c = rigidBody.MoveAndCollide(vector, true);
				if (c != null) return;
				rigidBody.MoveAndCollide(vector);
				Position += vector;
			}
		}
	}
}
