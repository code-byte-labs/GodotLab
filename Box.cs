using Godot;

namespace world;

public partial class Box : RigidBody2D
{
	private CollisionShape2D _collision;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_collision = GetNode<CollisionShape2D>("CollisionShape2D");
	}

	public override void _Draw()
	{
		Canvas.DrawRoundRect(this, new Rect2(Vector2.Zero, new Vector2(Level.SQUARE_W, Level.SQUARE_W)), Level.SQUARE_RADIUS,
			Colors.Gold, true);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
