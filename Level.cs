using Godot;
using System;
using System.Collections.Generic;

namespace world
{
	public partial class Level : Node2D
	{
		private CharacterBody2D _player;
		private PackedScene _boxScene;
		private PackedScene _siteScene;

		public override void _Ready()
		{
			_player = GetNode<CharacterBody2D>("Player");
			_player.Position = _GetPositionOfSquarePosition(0, 0);
			_boxScene = GD.Load<PackedScene>("res://box.tscn");
			_siteScene = GD.Load<PackedScene>("res://site.tscn");

			var startPosition = _GetPositionOfSquarePosition(0, 0) - new Vector2(1f, 1f);
			var endPosition = startPosition + new Vector2(SQUARE_W * (SQUARE_COL), SQUARE_W * (SQUARE_ROW)) +
							  new Vector2(2f, 2f);
			_AddStaticBody(startPosition, new Vector2(endPosition.X, startPosition.Y));
			_AddStaticBody(new Vector2(endPosition.X, startPosition.Y), endPosition);
			_AddStaticBody(endPosition, new Vector2(startPosition.X, endPosition.Y));
			_AddStaticBody(new Vector2(startPosition.X, endPosition.Y), startPosition);
			_AddBox(3, 3);
			_AddBox(1, 1);
			_AddSite(7, 7);
		}

		private void _AddStaticBody(Vector2 start, Vector2 end)
		{
			var staticBody = new StaticBody2D();
			staticBody.Position = start;
			var collision = new CollisionShape2D();
			var segment = new SegmentShape2D();
			segment.SetA(Vector2.Zero);
			segment.SetB(end - start);
			collision.Shape = segment;
			staticBody.AddChild(collision);
			AddChild(staticBody);
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
			return startPosition + new Vector2(SQUARE_W * x, SQUARE_W * y);
		}

		private void _AddBox(int x, int y)
		{
			var box = _boxScene.Instantiate<RigidBody2D>();
			box.Position = _GetPositionOfSquarePosition(x, y);
			AddChild(box);
		}
		
		private void _AddSite(int x, int y)
		{
			var box = _siteScene.Instantiate<Area2D>();
			box.Position = _GetPositionOfSquarePosition(x, y);
			AddChild(box);
		}

		public override void _Draw()
		{
			for (var row = 0; row < SQUARE_ROW; row++)
			{
				for (var col = 0; col < SQUARE_COL; col++)
				{
					Canvas.DrawRoundRect(this,
						new Rect2(_GetPositionOfSquarePosition(row, col), new Vector2(SQUARE_W, SQUARE_W)),
						SQUARE_RADIUS,
						Colors.Azure, true);

					Canvas.DrawRoundRect(this,
						new Rect2(_GetPositionOfSquarePosition(row, col), new Vector2(SQUARE_W, SQUARE_W)),
						SQUARE_RADIUS,
						Colors.Black, false);
				}
			}
		}

		public override void _PhysicsProcess(double delta)
		{
		}

		public static int SQUARE_RADIUS = 15;
		public static int SQUARE_ROW = 8;
		public static int SQUARE_COL = 8;
		public static int SQUARE_W = 50;
	}
}
