class_name CanvasHelper

static func draw_arc(node: Node2D, center: Vector2, point_count: int, radius: float, 
	start_angle: float, end_angle: float, color: Color):
	var points = PackedVector2Array()
	points.push_back(center)
	
	for i in range(point_count + 1):
		var angle_point = start_angle + i * (end_angle - start_angle) / point_count
		points.push_back(center + Vector2(cos(angle_point), sin(angle_point)) * radius)
	node.draw_colored_polygon(points, color)
