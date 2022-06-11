namespace TicTacToo {
    // Human player class
    public class HumanPlayer : IPlayer {
        public Stone Stone { get; private set; }

        // Constructor
        public HumanPlayer(Stone mark) {
            Stone = mark;
        }

        // Next move of game
        public int MakeMove(Board board) {
            while (true) {
                var line = Console.ReadLine();
                if (line == null || line.Length != 1)
                    continue;
                var index = line[0] - '0';
                if (0 <= index && index < 9) {
                    if (board.CanPut(index)) {
                        board[index] = Stone;
                        return index;
                    }
                }
                Console.WriteLine("Please input a valid number (0-8)");
            }
        }
    }
}
