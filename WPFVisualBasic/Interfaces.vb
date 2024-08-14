Public Interface IObjectToShape
    Function CreateShape() As Shape
End Interface

Public Interface IDrawable
    Sub Draw(ByRef map As Map)
End Interface

Public Interface IMoveable
    Sub Move(ByRef map As Map)
End Interface

Public Interface ICollide
    Sub Collide(ByRef colliders As IEnumerable(Of PhysicalObject))
End Interface

Public Interface IUserInput
    Sub HandleInput()
End Interface

Public Interface IHittable
    Sub Hit(ByVal damage As Integer)
End Interface

Public Interface IShootable
    Sub Shoot()
End Interface

Public Interface IUnitOfLife
    Property Health As Integer
    Property MaxHealth As Integer
    Sub Die()
End Interface

Public Interface ILevelStatus
    Property IsDone As Boolean
End Interface

Public Interface ILevelLoader
    Function LoadLevel(ByVal level As Integer) As Level
End Interface

Public Interface ILevel : Inherits ILevelStatus, ILevelLoader

End Interface

Public Interface IGameObject
    Property IsRunning As Boolean
    Sub Start()
    Sub Update()
    Sub OnStop()

End Interface
