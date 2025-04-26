extends CollisionShape2D

func _draw() -> void:
	print(global_position)
	print(position)
	print(shape.get_rect())
	print(Vector2(0, 0).distance_to(Vector2(0, 1)))
	shape.draw(get_canvas_item(), Color.RED)
	
func _ready() -> void:
	var tween = Tween.new()
	tween.set_repeat(true)
