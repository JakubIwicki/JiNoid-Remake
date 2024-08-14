Public NotInheritable Class AppSettings

    Private Shared ReadOnly _instance As New Lazy(Of AppSettings) _
        (Function() New AppSettings(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication)
    Private Sub New()
    End Sub
    Public Shared ReadOnly Property Instance As AppSettings
        Get
            Return _instance.Value
        End Get
    End Property

    Public Property InputSettings As New InputSettings

End Class


Public Class InputSettings
    Public Property RacketMoveLeftKey As Key = Key.A
    Public Property RacketMoveRightKey As Key = Key.D
    Public Property RacketMoveUpKey As Key = Key.W
    Public Property RacketMoveDownKey As Key = Key.S
    Public Property RacketMainKey As Key = Key.Space
    Public Property GameRestartKey As Key = Key.R
    Public Property GamePauseKey As Key = Key.P
    Public Property ActionKey As Key = Key.E

    Public Sub New()
        'TODO: load from file JSON/XML
    End Sub

End Class
