Public Class Map : Inherits BindableObject

    Private _width As Double
    Public Property Width As Double
        Get
            Return _width
        End Get
        Set
            _width = Value
            OnPropertyChanged(NameOf(Width))
        End Set
    End Property


    Private _height As Double
    Public Property Height As Double
        Get
            Return _height
        End Get
        Set
            _height = Value
            OnPropertyChanged(NameOf(Height))
        End Set
    End Property

    Private _backgroundColor As Brush
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
        BackgroundColor = Brushes.LightGreen
        Width = 400
        Height = 400
    End Sub

End Class
