Imports System.Threading

'Composite Pattern
Public Class GameManager
    Implements IGameObject

    Public Property GameMap As Map
    Public Property IsRunning As Boolean Implements IGameObject.IsRunning
    Public Property Managers As New List(Of IGameObject)

    Private _gameThread As Thread
    Public Sub New()

    End Sub

    Public Sub New(ParamArray gameObjects As IGameObject())
        Managers = New List(Of IGameObject)(gameObjects)
    End Sub
    Private Sub InitThread()
        _gameThread = New Thread(
            Sub()

                Try
                    For Each manager In Managers
                        manager.Start()
                    Next

                    While IsRunning
                    End While

                    For Each manager In Managers
                        manager.OnStop()
                    Next

                Catch ex As Exception
                    Return
                End Try

                Return

            End Sub) With {.Priority = ThreadPriority.Highest}
    End Sub

    Public Sub Start() Implements IGameObject.Start
        IsRunning = True
        InitThread()
        _gameThread.Start()
    End Sub

    Public Sub Update() Implements IGameObject.Update
        '
    End Sub

    Public Sub OnStop() Implements IGameObject.OnStop
        IsRunning = False
        For Each manager In Managers
            manager.OnStop()
        Next
    End Sub

End Class
