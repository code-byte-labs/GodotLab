class_name KeyclickHandler

# Declare instance variables at the class level
var _key: int
var _pressed_time: int = 0
var _clicked_time: int = 0
var _clicked_count: int = 0
var _clicked_callables: Array[Callable] = []
var _pressed_callables: Array[Callable] = []

var max_single_click_time: int = 100
var max_double_click_time: int = 150
var min_pressed_time: int = 0

func _init(key: int) -> void:
	_key = key # Initialize the key variable

func on_input_event(event: InputEventKey) -> bool:
	var ms = Time.get_ticks_msec()
	if event.keycode != _key:
		_clicked_count = 0
		return false
	if event.is_pressed():
		if ms - _pressed_time > min_pressed_time:
			_on_pressed(event)
		if not event.is_echo():
			_clicked_count += 1
			var double_click = false
			if _clicked_count == 2:
				if ms - _clicked_time < max_double_click_time:
					double_click = true
					_clicked_count = 0
				else:
					_clicked_count = 1
			_on_clicked(event, double_click)
			_clicked_time = ms
	return true

func _on_pressed(event: InputEventKey) -> void:
	for callable in _pressed_callables:
		callable.call(event)

func _on_clicked(event, double_click: bool) -> void:
	for callable in _clicked_callables:
		callable.call(event, double_click)

func add_press_callable(callable: Callable) -> void:
	if not _pressed_callables.has(callable):
		_pressed_callables.push_back(callable)

func add_click_callable(callable: Callable) -> void:
	if not _clicked_callables.has(callable):
		_clicked_callables.push_back(callable)

func remove_click_callable(callable: Callable) -> void:
	if _clicked_callables.has(callable):
		_clicked_callables.erase(callable)

func remove_press_callable(callable: Callable) -> void:
	if _pressed_callables.has(callable):
		_pressed_callables.erase(callable)
