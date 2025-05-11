class_name KeyclickDetector

# 声明成员变量
var _keyclick_handlers: Dictionary[int, KeyclickHandler] = {}

var max_single_click_time: int = 100
var max_double_click_time: int = 150
var min_pressed_time: int = 0

func add_click_callable(key: int, callable: Callable) -> void:
	var handler = _ensure_keyclick_handler(key)
	handler.add_click_callable(callable)

func on_input_event(event: InputEvent) -> void:
	if event is InputEventKey:
		for key in _keyclick_handlers.keys():
			_keyclick_handlers[key].on_input_event(event)

func remove_click_callable(key: int, callable: Callable) -> void:
	if _keyclick_handlers.has(key):
		_keyclick_handlers[key].remove_click_callable(callable)

func _ensure_keyclick_handler(key: int) -> KeyclickHandler:
	if not _keyclick_handlers.has(key):
		_keyclick_handlers[key] = KeyclickHandler.new(key)
		_keyclick_handlers[key].max_single_click_time = max_single_click_time
		_keyclick_handlers[key].max_double_click_time = max_double_click_time
		_keyclick_handlers[key].min_pressed_time = min_pressed_time
	return _keyclick_handlers[key]
