Public Class Racket : Inherits DrawableObject
    Implements IUserInput
    Public Sub New()
        MyBase.New()
    End Sub

    Private ReadOnly Property Inputs As InputSettings
        Get
            Return AppSettings.Instance.InputSettings
        End Get
    End Property
    Public Overrides Function CreateShape() As Shape
        Dim rect = New Rectangle With {
                .Width = Width,
                .Height = Height,
                .Fill = Fill,
                .Stroke = Stroke,
                .StrokeThickness = 1
                }
        Return rect
    End Function

    Public Overrides Sub Move(ByRef map As Map)

    End Sub

    Public Overrides Sub Collide(ByRef colliders As IEnumerable(Of PhysicalObject))

    End Sub

    Public Sub HandleInput() Implements IUserInput.HandleInput

        If Keyboard.IsKeyDown(Inputs.RacketMoveLeftKey) Then
            X -= VelocityX
        End If

        If Keyboard.IsKeyDown(Inputs.RacketMoveRightKey) Then
            X += VelocityX
        End If

        If Keyboard.IsKeyDown(Inputs.RacketMoveUpKey) Then
            Y -= VelocityY
        End If

        If Keyboard.IsKeyDown(Inputs.RacketMoveDownKey) Then
            Y += VelocityY
        End If

    End Sub
End Class
