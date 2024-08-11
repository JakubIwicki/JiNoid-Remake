Public Interface IObjectToShape
    Function CreateShape() As Shape
End Interface

Public Interface IMapObject
    Sub Draw(ByRef map As Map)
End Interface

Public Interface IMoveable
    Sub Move(ByRef map As Map)
End Interface

Public Interface ICollide
    Sub Collide(ParamArray colliders As PhysicalObject())
End Interface
