using AdventOfCode2025;
using AdventOfCode2025.Advent;

internal class Program
{
    private static void Main(string[] args)
    {
        int advent = 1;
        bool test = false;
        RunFlag flag = RunFlag.All;

        switch (advent)
        {
            case 1:
                Advent01.Run(test, flag, advent);
                break;
            case 2:
                Advent02.Run(test, flag, advent);
                break;
            case 3:
                Advent03.Run(test, flag, advent);
                break;
            case 4:
                Advent04.Run(test, flag, advent);
                break;
            case 5:
                Advent05.Run(test, flag, advent);
                break;
            case 6:
                Advent06.Run(test, flag, advent);
                break;
            case 7:
                Advent07.Run(test, flag, advent);
                break;
            case 8:
                Advent08.Run(test, flag, advent);
                break;
            case 9:
                Advent09.Run(test, flag, advent);
                break;
            case 10:
                Advent10.Run(test, flag, advent);
                break;
            case 11:
                Advent11.Run(test, flag, advent);
                break;
            case 12:
                Advent12.Run(test, flag, advent);
                break;
            case 13:
                Advent13.Run(test, flag, advent);
                break;
            case 14:
                Advent14.Run(test, flag, advent);
                break;
            case 15:
                Advent15.Run(test, flag, advent);
                break;
            case 16:
                Advent16.Run(test, flag, advent);
                break;
            case 17:
                Advent17.Run(test, flag, advent);
                break;
            case 18:
                Advent18.Run(test, flag, advent);
                break;
            case 19:
                Advent19.Run(test, flag, advent);
                break;
            case 20:
                Advent20.Run(test, flag, advent);
                break;
            case 21:
                Advent21.Run(test, flag, advent);
                break;
            case 22:
                Advent22.Run(test, flag, advent);
                break;
            case 23:
                Advent23.Run(test, flag, advent);
                break;
            case 24:
                Advent24.Run(test, flag, advent);
                break;
            case 25:
                Advent25.Run(test, flag, advent);
                break;
            default:
                break;
        }
    }
}