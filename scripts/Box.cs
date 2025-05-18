using Godot;

namespace Lab.scripts
{
	public partial class Box : RigidBody2D
	{
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			GravityScale = 0;
		}

		public override void _Draw()
		{
			DrawRect(new Rect2(new Vector2(-10, -10), new Vector2(20, 20)), Colors.Blue);
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}
	}
}
