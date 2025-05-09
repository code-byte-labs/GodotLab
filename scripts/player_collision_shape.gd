extends CollisionShape2D

func _draw() -> void:
	CanvasHelper.draw_arc(self, Vector2.ZERO, 270, 64, -(3.0 / 4.0) * PI, (3.0 / 4.0) * PI, Color.ORANGE)