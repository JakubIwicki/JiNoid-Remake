Public Class PhysicalObject
    Implements IMoveable, ICollide
    Public X As Double = 0
    Public Y As Double = 0
    Public VelocityX As Double = 2
    Public VelocityY As Double = 2
    Public Width As Double = 0
    Public Height As Double = 0
    Public Sub New()

    End Sub

    Public Sub New(location As Point, size As Size, velocity As Point)
        X = location.X
        Y = location.Y
        Width = size.Width
        Height = size.Height
        VelocityX = velocity.X
        VelocityY = velocity.Y
    End Sub

    Public Property Top As Double
        Get
            Return Y
        End Get
        Set
            Y = Value
        End Set
    End Property

    Public Property Left As Double
        Get
            Return X
        End Get
        Set
            X = Value
        End Set
    End Property

    Public Property Right As Double
        Get
            Return X + Width
        End Get
        Set
            X = Value - Width
        End Set
    End Property

    Public Property Bottom As Double
        Get
            Return Y + Height
        End Get
        Set
            Y = Value - Height
        End Set
    End Property

    Public Property TopLeftPoint As Point
        Get
            Return New Point(X, Y)
        End Get
        Set
            X = Value.X
            Y = Value.Y
        End Set
    End Property

    Public Property TopRightPoint As Point
        Get
            Return New Point(X + Width, Y)
        End Get
        Set
            X = Value.X - Width
            Y = Value.Y
        End Set
    End Property

    Public Property BottomLeftPoint As Point
        Get
            Return New Point(X, Y + Height)
        End Get
        Set
            X = Value.X
            Y = Value.Y - Height
        End Set
    End Property

    Public Property BottomRightPoint As Point
        Get
            Return New Point(X + Width, Y + Height)
        End Get
        Set
            X = Value.X - Width
            Y = Value.Y - Height
        End Set
    End Property




    Public Overridable Sub Move(ByRef map As Map) Implements IMoveable.Move
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

    'TODO: better colliders
    'TODO: on collide it can get stuck in wall
    Public Overridable Sub Collide(ByRef colliders As IEnumerable(Of PhysicalObject)) Implements ICollide.Collide

        For Each collider In colliders

            If collider Is Me Then
                Continue For
            End If

            If Right > collider.Left And Left < collider.Right And Bottom > collider.Top And Top < collider.Bottom Then
                VelocityX *= -1
                VelocityY *= -1
            End If

        Next
    End Sub
End Class


Public Class DrawableObject : Inherits PhysicalObject
    Implements IDrawable, IObjectToShape
    Public Shape As Shape
    Public Fill As Brush = Brushes.White
    Public Stroke As Brush = Brushes.Black

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(location As Point, size As Size, velocity As Point, fillColor As Brush)
        MyBase.New(location, size, velocity)
        Fill = fillColor
        Shape = CreateShape()
    End Sub

    Public Sub Draw(ByRef map As Map) Implements IDrawable.Draw
        Shape.SetValue(Canvas.LeftProperty, X)
        Shape.SetValue(Canvas.TopProperty, Y)
    End Sub
    Public Overridable Function CreateShape() As Shape Implements IObjectToShape.CreateShape
        Dim rect = New Ellipse With {
                .Width = Width,
                .Height = Height,
                .Fill = Fill,
                .Stroke = Stroke,
                .StrokeThickness = 1
                }
        Return rect
    End Function

End Class


Public Class PhysicalLifeObject : Inherits DrawableObject
    Implements IUnitOfLife, IHittable

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub Hit(ByVal damage As Integer) Implements IHittable.Hit
        Health -= damage
    End Sub

    'TODO: jakoś inaczej?
    Public Sub Die() Implements IUnitOfLife.Die
        X = -9999
        Y = -9999
    End Sub

    Public Property Health As Integer Implements IUnitOfLife.Health
    Public Property MaxHealth As Integer Implements IUnitOfLife.MaxHealth
End Class

