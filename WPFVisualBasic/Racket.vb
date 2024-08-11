Public Class Racket : Inherits PhysicalObject
    Implements IMapObject
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub Draw(ByRef map As Map) Implements IMapObject.Draw
        Throw New NotImplementedException
    End Sub

End Class
