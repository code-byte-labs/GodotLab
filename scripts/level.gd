extends Node2D

var rect = preload("res://scenes/rect.tscn")

func _ready() -> void:
	var viewport_rect = get_viewport_rect()
	var viewport_size = viewport_rect.size
	var start = Vector2(-viewport_size.x / 2, -viewport_size.y / 2)
	var end = Vector2(viewport_size.x / 2, viewport_size.y / 2)
	for i in range(start.x, end.x, 8):
		var rect_node = rect.instantiate()
		rect_node.position = Vector2(i, start.y)
		add_child(rect_node)
