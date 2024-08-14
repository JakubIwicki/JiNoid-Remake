Public Class Obstacle : Inherits PhysicalLifeObject
    Public Sub New()
        MyBase.New()
    End Sub

    Public Overrides Sub Move(ByRef map As Map)
    End Sub

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
End Class
