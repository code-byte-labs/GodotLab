extends CharacterBody2D

var speed: int = 300

var _keyclick_detector = KeyclickDetector.new()

func _init() -> void:
	_keyclick_detector.add_click_callable(KEY_SPACE, self._on_clicked)
	_keyclick_detector.add_press_callable(KEY_SPACE, self._on_pressed)

func _draw() -> void:
	draw_circle(global_position, 64.0, Color.ORANGE)

func _physics_process(_delta: float) -> void:
	var input_direction: float = Input.get_axis("ui_up", "ui_down")
	if input_direction != 0:
		velocity.y = speed * input_direction
	else:
		velocity.y = 0
	move_and_slide()

func _input(event: InputEvent) -> void:
	if event is InputEventKey:
		_keyclick_detector.on_input_event(event)

func _on_pressed(event: InputEvent) -> void:
	print(event)

func _on_clicked(event: InputEvent, double_click: bool = false) -> void:
	print(event, " ", double_click)
	
