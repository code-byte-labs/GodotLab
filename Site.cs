using Godot;

namespace world;

public partial class Site : Area2D
{
	private CollisionShape2D _collision;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_collision = GetNode<CollisionShape2D>("CollisionShape2D");
		
		// 连接信号
		BodyEntered += OnBodyEntered;
		BodyExited += OnBodyExited;
	}
	
	private void OnBodyEntered(Node2D body)
	{
		if (body is CharacterBody2D player)
		{
			GetTree().ReloadCurrentScene();
		}
	}

	private void OnBodyExited(Node2D body)
	{
		if (body is CharacterBody2D player)
		{
			GD.Print("检测到玩家离开");
		}
	}

	public override void _Draw()
	{
		Canvas.DrawRoundRect(this, new Rect2(Vector2.Zero, new Vector2(Level.SQUARE_W, Level.SQUARE_W)), Level.SQUARE_RADIUS,
			Colors.DeepPink, true);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
