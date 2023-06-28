void generateChessBoard()
{
    int inputNumberOfRows = 0;
    bool validInput = false;

    while (!validInput)
    {
        Console.Write(
            "Please enter a number. This will be the number of rows on your chess board: "
        );
        string input = Console.ReadLine();

        validInput = int.TryParse(input, out inputNumberOfRows);

        if (!validInput)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    Console.WriteLine();
    Console.WriteLine("Chessboard where 1 represents white square and 0 represents black square:");
    for (int i = 0; i < inputNumberOfRows; i++)
    {
        for (int j = 0; j < inputNumberOfRows; j++)
        {
            Console.Write((j + i) % 2 == 0 ? "1" : "0");
        }
        Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine("Try code again? \n1 - yes \nany key - close application");
    ConsoleKeyInfo tryAgainInput = Console.ReadKey(intercept: true);
    if (tryAgainInput.KeyChar == '1')
    {
        Console.WriteLine();
        generateChessBoard();
    }
    else
    {
        Environment.Exit(0);
    }
}

generateChessBoard();
