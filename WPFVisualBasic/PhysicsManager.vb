Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Threading

Public Class PhysicsManager : Inherits BindableObject
    Implements IGameObject
    Public Map As Map

    Public Property PhysicalObjects As New List(Of PhysicalObject)
    Public Property IsRunning As Boolean Implements IGameObject.IsRunning

    Private ReadOnly _gameTimer As DispatcherTimer

    Public Sub New(ByRef map As Map)
        Me.Map = map

        _gameTimer = New DispatcherTimer With {
            .Interval = TimeSpan.FromMilliseconds(20)
        }
        AddHandler _gameTimer.Tick, Sub() Update()
    End Sub


    Public Sub Start() Implements IGameObject.Start
        IsRunning = True
        _gameTimer.Start()
    End Sub

    Public Sub Update() Implements IGameObject.Update
        For Each obj In PhysicalObjects
            obj.Move(Map)
            obj.Collide(PhysicalObjects)
        Next
    End Sub

    Public Sub OnStop() Implements IGameObject.OnStop
        IsRunning = False
        _gameTimer.Stop()
    End Sub

End Class


'???
Module PhysicsManagerExtensions

    <Extension>
    Public Function WithBalls(ByRef gm As PhysicsManager, ParamArray balls() As Ball) As PhysicsManager
        gm.PhysicalObjects.AddRange(balls)
        Return gm
    End Function

    <Extension>
    Public Function WithRackets(ByRef gm As PhysicsManager, ParamArray rackets() As Racket) As PhysicsManager
        gm.PhysicalObjects.AddRange(rackets)
        Return gm
    End Function

End Module
