namespace TicTacToo {
    //Game controller class
    class GameController {
        private IPlayer _player1;
        private IPlayer _player2;
        private Board _board;

        // Game run
        public void Run() {
            _board = new Board();
            var b = Confirm("Are you first?:");
            _player1 = b ? new HumanPlayer(Stone.Batu) : new CPUPlayer(Stone.Batu);
            _player2 = b ? new CPUPlayer(Stone.Maru) : new HumanPlayer(Stone.Maru);
            IPlayer player = _player1;
            PrintBoard(_board);
            do {
                PrintInput();
                player.MakeMove(_board);
                PrintBoard(_board);
                player = (player == _player1) ? _player2 : _player1;
            } while (!_board.IsComplete());
            Complete();
        }

        // Return human player
        private IPlayer GetHumanPlayer() =>
             _player1 is HumanPlayer ? _player1 : _player2;

        // Display game board
        private void PrintBoard(Board board) {
            Console.Clear();
            Console.WriteLine("You: {0}\n", GetHumanPlayer().Stone.Value);

            for (int i = 0; i < 9; i++) {
                Console.Write(board[i].Value + "  ");
                if (i % 3 == 2) {
                    // new line per 3
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
            }
        }

        // Display input information
        private void PrintInput() {
            Console.WriteLine("\nPlease input the following index number");
            for (int i = 0; i < 9; i++) {
                Console.Write(i + " ");
                if (i % 3 == 2)
                    // new line per 3
                    Console.WriteLine("");
            }
            Console.Write("\nYour position? (0-8):");
        }

        // Game complete process
        private void Complete() {
            var win = _board.Judge();
            var human = GetHumanPlayer();
            if (win == Stone.Empty)
                Console.WriteLine("Draw");
            else if (win == human.Stone)
                Console.WriteLine("You Win");
            else
                Console.WriteLine("You Lose");
        }

        // Confirmation of user input (y/n)
        public static bool Confirm(string message) {
            Console.Write(message);
            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            try {
                while (true) {
                    var key = Console.ReadKey();
                    if (key.KeyChar == 'y')
                        return true;
                    if (key.KeyChar == 'n')
                        return false;
                    Console.CursorLeft = left;
                    Console.CursorTop = top;
                }
            } finally {
                Console.WriteLine();
            }
        }
    }
}
