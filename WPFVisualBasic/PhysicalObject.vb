Public Class PhysicalObject : Inherits DrawableObject
    Public X As Double = 0
    Public Y As Double = 0
    Public VelocityX As Double = 0
    Public VelocityY As Double = 0
    Public Width As Double = 0
    Public Height As Double = 0

    Public Sub New()

    End Sub

    Public Sub New(x As Double, y As Double)
        Me.X = x
        Me.Y = y
    End Sub

    Public Sub CalculatePhysics()

    End Sub

End Class


Public Class DrawableObject
    Public Shape As Shape
End Class
