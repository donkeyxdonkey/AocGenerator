using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int YEAR = 2025;

        string assembly = "AdventOfCode" + YEAR.ToString();
        string adventAssembly = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, $"..\\..\\..\\..\\{assembly}"));
        string projectFile = Path.Combine(adventAssembly, assembly + ".csproj");
        string adventPath = Path.Combine(adventAssembly, "Advent");
        string inputPath = Path.Combine(adventAssembly, "Input");
        string testPath = Path.Combine(adventAssembly, "Test");

        CreateAdvent(YEAR, adventPath, inputPath, testPath, projectFile);
    }

    private static void CreateAdvent(int year, string adventPath, string inputPath, string testPath, string projectFile)
    {
        Directory.CreateDirectory(adventPath);
        Directory.CreateDirectory(inputPath);
        Directory.CreateDirectory(testPath);

        string head = "using AdventUtility;\r\n\r\nnamespace AdventOfCode" + year.ToString() + ".Advent;\r\n\r\n" +
            "internal class ";

        string tail = "\r\n{\r\n" +
            "\tprivate static int[] input = [];\r\n\r\n" +
            "\tinternal static void Run(bool test, RunFlag flag, int val)\r\n" +
            "\t{\r\n" +
            "\t\tinput = Utility.ReadInput(test, val).ConvertTo<int>();\r\n\r\n" +
            "\t\tif (flag is RunFlag.All or RunFlag.Part1)\r\n" +
            "\t\t\tPart1();\r\n\r\n" +
            "\t\tif (flag is RunFlag.All or RunFlag.Part2)\r\n" +
            "\t\t\tPart2();\r\n" +
            "\t}\r\n\r\n" +

            "\tprivate static void Part1()\r\n" +
            "\t{\r\n\r\n" +
            "\t}\r\n\r\n" +

            "\tprivate static void Part2()\r\n" +
            "\t{\r\n\r\n" +
            "\t}\r\n" +
            "}\r\n"
            ;

        StringBuilder projInject = new("  <ItemGroup>\r\n    <ProjectReference Include=\"..\\AdventUtility\\AdventUtility.csproj\" />\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n");

        bool inject = false;

        for (int i = 1; i <= 25; i++)
        {
            string nr = i < 10 ? "0" : "";

            string name = "Advent" + nr + i.ToString();
            string fileName = adventPath + "\\" + name + ".cs";

            if (!File.Exists(fileName))
            {
                string data = head + name + tail;
                File.WriteAllText(fileName, data);
            }

            string inputFile = "input" + nr + i.ToString() + ".txt";
            string path = Path.Combine(inputPath, inputFile);

            if (!File.Exists(path))
            {
                inject = true;
                File.Create(path);
                projInject.Append($"  <None Update=\"Input\\{inputFile}\">\r\n    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>\r\n  </None>\r\n");
            }

            path = Path.Combine(testPath, inputFile);
            if (!File.Exists(path))
            {
                inject = true;
                File.Create(path);
                projInject.Append($"  <None Update=\"Test\\{inputFile}\">\r\n    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>\r\n  </None>\r\n");
            }
        }

        if (inject)
        {
            projInject.Length -= 2;
            projInject.Append("\r\n</ItemGroup>");

            string[] temp = File.ReadAllText(projectFile).Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            string projData = string.Join("\r\n", temp.Take(temp.Length - 1)) + "\r\n" + projInject.ToString() + "\r\n" + temp[^1];

            File.WriteAllText(projectFile, projData);
        }
    }
}