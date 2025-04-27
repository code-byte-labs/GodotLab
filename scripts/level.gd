extends Node2D

@export var cube_scene = preload("res://scenes/cube.tscn")

func _ready() -> void:
	print(get_child_count())
	print(get_viewport_rect())
	get_child(1).queue_free()
	var cube = cube_scene.instantiate()
	cube.position = Vector2(-200, 0)
	add_child(cube)
	
