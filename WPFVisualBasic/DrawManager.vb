Imports System.ComponentModel
Imports System.Windows.Threading

Public Class DrawManager : Inherits BindableObject
    Implements IGameObject

    Private ReadOnly _map As Map

    Private ReadOnly _dispatcher As Dispatcher
    Public Property IsRunning As Boolean Implements IGameObject.IsRunning

    Public Property Drawables As List(Of DrawableObject)

    Public ReadOnly Property ShapeDrawables As IEnumerable(Of Shape)
        Get
            Return Drawables.Select(Function(c) c.Shape)
        End Get
    End Property

    Public Sub New(ByRef dispatcher As Dispatcher, ByRef drawables As List(Of DrawableObject), ByRef map As Map)
        _dispatcher = dispatcher
        Me.Drawables = drawables
        _map = map
    End Sub

    Public Sub Start() Implements IGameObject.Start
        IsRunning = True
    End Sub

    Public Sub Update() Implements IGameObject.Update
        'attached to rendering Event in wpf window
    End Sub

    Public Sub OnStop() Implements IGameObject.OnStop
        IsRunning = False
    End Sub

    Public Sub Draw()
        _dispatcher.Invoke(Sub()
                               For Each ToDraw In Drawables
                                   ToDraw.Draw(_map)
                               Next
                           End Sub)

        OnPropertyChanged(NameOf(ShapeDrawables))
    End Sub

End Class
