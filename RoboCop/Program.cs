// See https://aka.ms/new-console-template for more information
using RoboCop.Business;

Robot robot = new Robot();
bool exit = false;
int xAxis = -1, yAxis = -1;
string facing = String.Empty;
Console.WriteLine("Welcome to RoboCop Universe");
do
{
    
    Console.WriteLine("Place a Command:");
    var command = Console.ReadLine();
    if (command.Contains(RoboConstant.PLACE))
    {
        var data = command.Split(' ');
        var stepCount = data[1].Split(",");
        xAxis = Convert.ToInt32(stepCount[0]);
        yAxis = Convert.ToInt32(stepCount[1]);
        facing = stepCount[2];
        command = RoboConstant.PLACE;
    }

    switch (command)
    {
        case RoboConstant.MOVE:
            robot.Move();
            Console.WriteLine("Moved");
            break;
        case RoboConstant.LEFT:
            robot.Left();
            Console.WriteLine("Left Turn");
            break;
        case RoboConstant.RIGHT:
            robot.Right();
            Console.WriteLine("Right Turn");
            break;
        case RoboConstant.REPORT:
            Console.WriteLine("Report Out");
            Console.WriteLine(robot.Report());
            break;
        case RoboConstant.PLACE:
            robot.Place(xAxis, yAxis, facing);
            Console.WriteLine("Placed");
            break;
        default:
            break;
    }

    Console.WriteLine("Type 0 to terminate the game and 1 to continue playing :)");
    string? input = Console.ReadLine();
    if (Convert.ToInt32(input).Equals(RoboConstant.EXIT)) exit = true;

} while (!exit);

