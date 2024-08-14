Imports System.Windows.Threading

Public Class InputManager
    Implements IGameObject

    Private ReadOnly _inputs As List(Of IUserInput)
    Private ReadOnly _inputTimer As DispatcherTimer
    Public Property IsRunning As Boolean Implements IGameObject.IsRunning

    Public Sub New(ByRef inputs As List(Of IUserInput))
        _inputs = inputs

        _inputTimer = New DispatcherTimer With {
            .Interval = TimeSpan.FromMilliseconds(30)
        }
        AddHandler _inputTimer.Tick, Sub() Update()
    End Sub


    Public Sub Start() Implements IGameObject.Start
        _inputTimer.Start()
        IsRunning = True
    End Sub

    Public Sub Update() Implements IGameObject.Update
        For Each userInput In _inputs
            userInput.HandleInput()
        Next
    End Sub

    Public Sub OnStop() Implements IGameObject.OnStop
        _inputTimer.Stop()
        IsRunning = False
    End Sub
End Class
