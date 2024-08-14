Imports System.Windows.Threading

Public Class Level
    Implements ILevel
    Public Property Obstacles As List(Of Obstacle)

    Public Sub New()
    End Sub

    Public Function LoadLevel(level As Integer) As Level Implements ILevelLoader.LoadLevel
        Throw New NotImplementedException
    End Function

    Public Property IsDone As Boolean Implements ILevelStatus.IsDone
End Class

Public Class LevelManager
    Implements IGameObject
    Private ReadOnly _levels As List(Of ILevel)
    Private _currentLevel As ILevel
    Private _levelIndex As Integer

    Private ReadOnly _levelTimer As DispatcherTimer

    Public Property IsRunning As Boolean Implements IGameObject.IsRunning

    Public Sub New()
        _levels = New List(Of ILevel) 'TODO: load from file
        _levelIndex = 0

        'TMP:
        _levels.Add(New Level)
        _currentLevel = _levels(_levelIndex)

        _levelTimer = New DispatcherTimer With {
            .Interval = TimeSpan.FromMilliseconds(60)
        }
        AddHandler _levelTimer.Tick, Sub() IGameObject_Update()

    End Sub

    Public Sub LoadLevel(level As Integer)
        _currentLevel = _levels(level).LoadLevel(level)
    End Sub

    Public Sub Start() Implements IGameObject.Start
        _levelTimer.Start()
        IsRunning = True
    End Sub

    Public Sub IGameObject_Update() Implements IGameObject.Update
        If _currentLevel.IsDone Then
            _levelIndex += 1
            LoadLevel(_levelIndex)
        End If
    End Sub

    Public Sub OnStop() Implements IGameObject.OnStop
        _levelTimer.Stop()
        IsRunning = False
    End Sub
End Class
