'Builder pattern
Imports System.Windows.Threading

Public Class DrawableObjectBuilder
    Private ReadOnly _obj As DrawableObject

    Public Sub New(ByRef obj As DrawableObject)
        _obj = obj
    End Sub

    Public Function SetLocation(location As Point) As DrawableObjectBuilder
        _obj.X = location.X
        _obj.Y = location.Y
        Return Me
    End Function

    Public Function SetSize(size As Size) As DrawableObjectBuilder
        _obj.Width = size.Width
        _obj.Height = size.Height
        Return Me
    End Function

    Public Function SetVelocity(velocity As Velocity) As DrawableObjectBuilder
        _obj.VelocityX = velocity.X
        _obj.VelocityY = velocity.Y
        Return Me
    End Function

    Public Function SetFillColor(fillColor As Brush) As DrawableObjectBuilder
        _obj.Fill = fillColor
        Return Me
    End Function

    Public Function Build() As DrawableObject
        _obj.Shape = _obj.CreateShape()
        Return _obj
    End Function
End Class


Public Class ObstacleBuilder
    Private ReadOnly _obstacle As Obstacle

    Public Sub New()
        _obstacle = New Obstacle()
    End Sub

    Public Function SetLocation(location As Point) As ObstacleBuilder
        _obstacle.X = location.X
        _obstacle.Y = location.Y
        Return Me
    End Function

    Public Function SetSize(size As Size) As ObstacleBuilder
        _obstacle.Width = size.Width
        _obstacle.Height = size.Height
        Return Me
    End Function

    Public Function SetFillColor(fillColor As Brush) As ObstacleBuilder
        _obstacle.Fill = fillColor
        Return Me
    End Function

    Public Function SetHealth(health As Integer) As ObstacleBuilder
        _obstacle.MaxHealth = health
        _obstacle.Health = health
        Return Me
    End Function

    Public Function Build() As Obstacle
        _obstacle.Shape = _obstacle.CreateShape()
        Return _obstacle
    End Function

End Class


Public Class GameBuilder
    Private ReadOnly _gameManager As GameManager
    Public Sub New()
        _gameManager = New GameManager()
    End Sub

    Public Function WithPhysicsManager(ByRef manager As PhysicsManager) As GameBuilder
        _gameManager.Managers.Add(manager)
        Return Me
    End Function

    Public Function WithInputManager(ByRef inputManager As InputManager) As GameBuilder
        _gameManager.Managers.Add(inputManager)
        Return Me
    End Function

    Public Function WithDrawManager(ByRef drawManager As DrawManager) As GameBuilder
        _gameManager.Managers.Add(drawManager)
        Return Me
    End Function

    Public Function WithLevelManager(ByRef lvlManager As LevelManager) As GameBuilder
        _gameManager.Managers.Add(lvlManager)
        Return Me
    End Function

    Public Function WithMap(ByRef map As Map) As GameBuilder
        _gameManager.GameMap = map
        Return Me
    End Function

    Public Function Build() As GameManager
        Return _gameManager
    End Function

End Class
