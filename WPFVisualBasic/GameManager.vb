Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Threading

Class GameManager : Inherits BindableObject
    Public Balls As New List(Of Ball)
    Public Rackets As New List(Of Racket)
    Public Map As Map
    Public IsRunning As Boolean = False

    Private _gameThread As Thread
    Private ReadOnly _dispatcher As Dispatcher
    Private ReadOnly _gameTimer As DispatcherTimer

    Public ReadOnly Property BallShapes As IEnumerable(Of Shape)
        Get
            Return Balls.Select(Function(b) b.Shape)
        End Get
    End Property

    Public Sub New(ByRef map As Map, ByRef dispatcher As Dispatcher)
        Me.Map = map
        _dispatcher = dispatcher

        _gameTimer = New DispatcherTimer With {
            .Interval = TimeSpan.FromMilliseconds(60)
        }
        AddHandler _gameTimer.Tick, Sub() Update()

        InitThread()
    End Sub

    Private Sub InitThread()
        _gameThread = New Thread(
            Sub()

                Try
                    _gameTimer.Start()

                    While IsRunning
                    End While

                    _gameTimer.Stop()

                Catch ex As Exception
                    Return
                End Try

                Return

            End Sub) With {.Priority = ThreadPriority.Highest}
    End Sub

    Public Sub Start()
        IsRunning = True
        InitThread()
        _gameThread.Start()
    End Sub

    Private Sub Update()
        For Each ball In Balls
            ball.Move(Map)
        Next
    End Sub

    Public Sub Draw()
        _dispatcher.Invoke(Sub()
                               For Each ball In Balls
                                   ball.Draw(Map)
                               Next
                           End Sub)

        OnPropertyChanged(NameOf(BallShapes))
    End Sub

    Public Sub OnStop()
        IsRunning = False
        'GameThread.Interrupt()
    End Sub

End Class



'Builder pattern
Module GameManagerExtensions

    <Extension>
    Public Function WithBalls(ByRef gm As GameManager, ParamArray balls() As Ball) As GameManager
        gm.Balls.Clear()
        gm.Balls.AddRange(balls)
        Return gm
    End Function

    <Extension>
    Public Function WithRackets(ByRef gm As GameManager, ParamArray rackets() As Racket) As GameManager
        gm.Rackets.Clear()
        gm.Rackets.AddRange(rackets)
        Return gm
    End Function

End Module
