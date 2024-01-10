using Lab2;

namespace Lab2Test;

public class TestTurtle
{
    private Turtle tr = null!;
    
    [SetUp]
    public void Setup()
    {
        tr = new();
    }

    [Test]
    public void AngleCommand_RotatesTurtle()
    {
        tr.Turn(180);
        
        Assert.That(tr.Direction, Is.EqualTo(180));
    }
    
    
    [Test]
    public void AngleCommand_TurnsPast360()
    {
        tr.Turn(361);
        
        Assert.That(tr.Direction, Is.EqualTo(1));
    }
    
    [Test]
    public void MoveCommand_ChangesX()
    {
        tr.Move(1);
        
        Assert.That(tr.X, Is.EqualTo(1));
    }
    
    [Test]
    public void MoveCommand_ChangesY()
    {
        tr.Turn(90);
        tr.Move(1);
        
        Assert.That(tr.Y, Is.EqualTo(1));
    }

    public void MoveCommand_TracksSteps()
    {
        int stepCount = tr.Steps.Count;
        
        tr.Move(1);
        
        Assert.That(tr.Steps, Has.Count.EqualTo(stepCount + 1));
    }
    
    [Test]
    public void MoveCommand_DoesNotCreateLines_WhenPenIsUp()
    {
        int pathLength = tr.Path.Count;
        
        tr.PenUp();
        tr.Move(1);

        Assert.That(tr.Path, Has.Count.EqualTo(pathLength));
    }
    
    [Test]
    public void MoveCommand_CreatesLines_WhenPenIsDown()
    {
        int pathLength = tr.Path.Count;
        
        tr.PenDown();
        tr.Move(1);

        Assert.That(tr.Path, Has.Count.EqualTo(pathLength + 1));
    }
    
    [Test]
    public void DrawingFigure_CreatesFigure()
    {
        int figureCount = tr.Figures.Count;
        
        tr.PenDown();
        tr.Move(1);
        tr.Turn(90);
        tr.Move(1);
        tr.Turn(90);
        tr.Move(1);
        tr.Turn(90);
        tr.Move(1);

        Assert.That(tr.Figures, Has.Count.EqualTo(figureCount + 1));
    }
    
    [Test]
    public void DrawingFigure_ResetsPath()
    {
        tr.PenDown();
        tr.Move(1);
        tr.Turn(90);
        tr.Move(1);
        tr.Turn(90);
        tr.Move(1);
        tr.Turn(90);
        tr.Move(1);

        Assert.That(tr.Path, Is.Empty);
    }
}