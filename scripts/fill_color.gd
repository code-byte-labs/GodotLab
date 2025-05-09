extends CollisionShape2D

func _draw() -> void:
	var color = get_meta("color", Color.BLACK)
	shape.draw(get_canvas_item(), color)
