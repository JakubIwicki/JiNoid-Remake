Imports System.Windows.Threading

Public Class Ball : Inherits PhysicalObject
    Implements IMapObject, IObjectToShape, IMoveable, ICollide
    Public Sub New()
        MyBase.New()
        X = 100
        Y = 125
        VelocityX = 5
        VelocityY = 5
        Width = 20
        Height = 20
        Shape = CreateShape()
    End Sub

    Public Sub Draw(ByRef map As Map) Implements IMapObject.Draw
        Shape.SetValue(Canvas.LeftProperty, X)
        Shape.SetValue(Canvas.TopProperty, Y)
    End Sub

    Public Function CreateShape() As Shape Implements IObjectToShape.CreateShape
        Dim rect = New Ellipse With {
            .Width = Width,
            .Height = Height,
            .Fill = Brushes.Red,
            .Stroke = Brushes.Black,
            .StrokeThickness = 1
        }
        Canvas.SetLeft(rect, X)
        Canvas.SetTop(rect, Y)
        Return rect
    End Function

    Public Sub Move(ByRef map As Map) Implements IMoveable.Move
        'Collision
        If X < 0 Or X + Width > map.Width Then
            VelocityX *= -1
        End If
        If Y < 0 Or Y + Height > map.Height Then
            VelocityY *= -1
        End If

        'Movement
        X += VelocityX
        Y += VelocityY
    End Sub

    Public Sub Collide(ParamArray colliders As PhysicalObject()) Implements ICollide.Collide
        For Each collider In colliders
            If X < collider.X + collider.Width And
                X + Width > collider.X And
                Y < collider.Y + collider.Height And
                Y + Height > collider.Y Then
                VelocityX *= -1
                VelocityY *= -1
            End If
        Next
    End Sub
End Class



