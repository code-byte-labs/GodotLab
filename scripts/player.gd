extends CharacterBody2D

var speed: int = 300

func _draw() -> void:
	draw_circle(global_position, 64.0, Color.ORANGE)

func _physics_process(delta: float) -> void:
	var input_direction: float = Input.get_axis("ui_up", "ui_down")
	if input_direction != 0:
		velocity.y = speed * input_direction
	else:
		velocity.y = 0
	move_and_slide()
