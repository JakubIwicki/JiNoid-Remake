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
                                                    ViewModel.GameManager.Draw()
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
            Return _gameManager.Map
        End Get
        Set
            _gameManager.Map = Value
            OnPropertyChanged(NameOf(Map))
        End Set
    End Property

    Public Sub New(ByRef dispatcher As Dispatcher)
        _gameManager = New GameManager(New Map(), dispatcher).WithBalls(New Ball()).WithRackets(New Racket())
    End Sub

    Private _name As String = "Hello World!"
    Public Property Name As String
        Get
            Return _name
        End Get
        Set
            _name = Value
            OnPropertyChanged(NameOf(Name))
        End Set
    End Property

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



