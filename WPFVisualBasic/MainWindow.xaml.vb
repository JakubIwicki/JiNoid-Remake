Imports System.ComponentModel
Imports System.Configuration
Imports System.Linq.Expressions
Imports System.Threading
Imports System.Windows.Threading

Class MainWindow
    Private Property ViewModel As MainWindowViewModel
    Public Sub New()
        InitializeComponent()

        'Hack for better performance
        AddHandler CompositionTarget.Rendering, Sub(s, e)
                                                    ViewModel.DrawManager.Draw()
                                                End Sub

        ViewModel = New MainWindowViewModel(Dispatcher)

        DataContext = ViewModel
    End Sub
End Class


Class MainWindowViewModel : Inherits BindableObject

    Private _gameManager As GameManager
    Public Property GameManager As GameManager
        Get
            Return _gameManager
        End Get
        Set
            _gameManager = Value
            OnPropertyChanged(NameOf(GameManager))
        End Set
    End Property

    Public Property Map As Map
        Get
            Return _gameManager.GameMap
        End Get
        Set
            _gameManager.GameMap = Value
            OnPropertyChanged(NameOf(Map))
        End Set
    End Property

    Public Property DrawManager As DrawManager

    Public Sub New(ByRef dispatcher As Dispatcher)
        Dim initMap = New Map(400, 800)

        Dim physicsManager = New PhysicsManager(initMap) _
                        .WithBalls(GenerateRandomBalls(2, initMap)) _
                        .WithRackets(GenerateMainRacket(initMap))

        Dim userInputObjects = physicsManager.PhysicalObjects.OfType(Of IUserInput).ToList()
        Dim drawableObjects = physicsManager.PhysicalObjects.OfType(Of DrawableObject).ToList()

        Dim inputManager = New InputManager(userInputObjects)
        Dim drawingManager = New DrawManager(dispatcher, drawableObjects, initMap)
        Dim levelManager = New LevelManager()

        Dim gm = New GameBuilder().
                WithPhysicsManager(physicsManager).
                WithInputManager(inputManager).
                WithDrawManager(drawingManager).
                WithLevelManager(levelManager).
                WithMap(initMap).
                Build()

        Me.GameManager = gm
        Me.DrawManager = drawingManager
    End Sub

    Public ReadOnly Property StartCommand As ICommand
        Get
            Return New RelayCommand(Sub()
                                        If _gameManager.IsRunning Then
                                            _gameManager.OnStop()
                                        Else
                                            _gameManager.Start()
                                        End If
                                    End Sub)
        End Get
    End Property

End Class



