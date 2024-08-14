Public Class Map : Inherits BindableObject

    Private _width As Double = 400
    Public Property Width As Double
        Get
            Return _width
        End Get
        Set
            _width = Value
            OnPropertyChanged(NameOf(Width))
        End Set
    End Property


    Private _height As Double = 800
    Public Property Height As Double
        Get
            Return _height
        End Get
        Set
            _height = Value
            OnPropertyChanged(NameOf(Height))
        End Set
    End Property

    Private _backgroundColor As Brush = Brushes.LightGreen
    Public Property BackgroundColor As Brush
        Get
            Return _backgroundColor
        End Get
        Set
            _backgroundColor = Value
            OnPropertyChanged(NameOf(BackgroundColor))
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(width As Double, height As Double)
        Me.Width = width
        Me.Height = height
    End Sub

End Class
