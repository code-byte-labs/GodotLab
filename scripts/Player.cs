using Godot;

namespace Lab.scripts
{
	public partial class Player : CharacterBody2D
	{
		// 移动速度
		private const float Speed = 300.0f;
		
		public override void _Draw()
		{
			var color = Colors.Black;
			color.A = 0.5f;
			DrawCircle(Vector2.Zero, 64, color);
		}
		
		
		public override void _PhysicsProcess(double delta)
		{
			Vector2 velocity = Vector2.Zero;

			// 获取输入方向
			if (Input.IsActionPressed("ui_right"))
				velocity.X += 1;
			if (Input.IsActionPressed("ui_left"))
				velocity.X -= 1;
			if (Input.IsActionPressed("ui_down"))
				velocity.Y += 1;
			if (Input.IsActionPressed("ui_up"))
				velocity.Y -= 1;

			// 标准化速度向量并应用速度
			if (velocity != Vector2.Zero)
			{
				velocity = velocity.Normalized() * Speed;
			}

			// 设置移动速度
			Velocity = velocity;
			
			// 执行移动,包含碰撞检测
			MoveAndSlide();
		}
	}
}
