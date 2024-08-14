Public Module Generator

    Public Function GenerateRandomNumber(min As Integer, max As Integer) As Integer
        Static generator As Random = New Random()
        Return generator.Next(min, max)
    End Function

    Public Function GenerateRandomColor() As Brush
        Dim r = GenerateRandomNumber(0, 255)
        Dim g = GenerateRandomNumber(0, 255)
        Dim b = GenerateRandomNumber(0, 255)
        Return New SolidColorBrush(Color.FromRgb(CByte(r), CByte(g), CByte(b)))
    End Function

    Public Function GenerateRandomPoint(minX As Integer, maxX As Integer, minY As Integer, maxY As Integer) As Point
        Dim x = GenerateRandomNumber(minX, maxX)
        Dim y = GenerateRandomNumber(minY, maxY)
        Return New Point(x, y)
    End Function

    Public Function GenerateRandomVelocity(minX As Integer, maxX As Integer, minY As Integer, maxY As Integer) As Velocity
        Dim x = GenerateRandomNumber(minX, maxX)
        Dim y = GenerateRandomNumber(minY, maxY)
        Return New Velocity(x, y)
    End Function

    Public Function GenerateRandomSize(minWidth As Integer, maxWidth As Integer, minHeight As Integer, maxHeight As Integer) As Size
        Dim width = GenerateRandomNumber(minWidth, maxWidth)
        Dim height = GenerateRandomNumber(minHeight, maxHeight)
        Return New Size(width, height)
    End Function

    'TODO: ball can always have to move in corner direction not flat
    'TODO: ball can spawn inside walls
    Public Function GenerateRandomBall(map As Map) As Ball
        Dim fill = GenerateRandomColor()

        Dim size = GenerateRandomSize(10, 20, 10, 20)

        Dim position = GenerateRandomPoint(0, CInt(map.Width - size.Width), 0, CInt(map.Height - size.Height))

        Dim velocity = GenerateRandomVelocity(-3, 3, -3, 3)

        Dim ball = New DrawableObjectBuilder(New Ball()).
            SetLocation(position).
            SetSize(size).
            SetVelocity(velocity).
            SetFillColor(fill).
            Build()
        Return CType(ball, Ball)
    End Function

    'TODO: validation for not overlapping balls
    Public Function GenerateRandomBalls(count As Integer, map As Map) As Ball()
        Dim balls = New Ball(count - 1) {}
        For i = 0 To count - 1
            balls(i) = GenerateRandomBall(map)
        Next
        Return balls
    End Function

    Public Function GenerateMainRacket(map As Map) As Racket
        Dim fill = Brushes.Black
        Dim size = New Size(100, 10)
        Dim position = New Point((map.Width - size.Width) / 2, map.Height - size.Height - 10)
        Dim velocity = New Velocity(2, 2)
        Dim racket = New DrawableObjectBuilder(New Racket()).
            SetLocation(position).
            SetSize(size).
            SetVelocity(velocity).
            SetFillColor(fill).
            Build()
        Return CType(racket, Racket)

    End Function

    Public Function GenerateObstacle(map As Map) As Obstacle
        Dim fill = GenerateRandomColor()
        Dim size = GenerateRandomSize(20, 40, 20, 40)
        Dim position = GenerateRandomPoint(0, CInt(map.Width - size.Width), 0, CInt(map.Height - size.Height))
        Dim obstacle = New ObstacleBuilder().
            SetLocation(position).
            SetSize(size).
            SetFillColor(fill).
                SetHealth(100).
            Build()
        Return obstacle
    End Function

End Module
